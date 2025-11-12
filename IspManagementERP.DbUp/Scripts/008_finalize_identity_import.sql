-- 008_finalize_identity_import.sql
-- Finaliza la importación: crea tablas "finales" (si no existen) y copia datos desde las tablas *_Import
-- Corregido: removida la SELECT inválida que intentaba usar dbo.[@tbl] directamente;
--          ahora se usa sp_executesql dinámico para contar filas.

SET XACT_ABORT ON;
GO

DECLARE @tablesToFinalize TABLE (TableName sysname);
INSERT INTO @tablesToFinalize (TableName) VALUES
('AspNetRoles'),
('AspNetRoleClaims'),
('AspNetUsers'),
('AspNetUserClaims'),
('AspNetUserLogins'),
('AspNetUserRoles'),
('AspNetUserTokens'),
('AuditEntries'),
('ClaimDefinitions'),
('DeviceCodes'),
('Keys'),
('PersistedGrants'),
('TenantGuidMapping'),
('Tenants')
;

IF OBJECT_ID('tempdb..#FinalizeResults') IS NOT NULL DROP TABLE #FinalizeResults;
CREATE TABLE #FinalizeResults
(
  TableName sysname,
  ActionTaken nvarchar(200),
  RowsInserted int NULL,
  ErrorMessage nvarchar(max) NULL,
  ExecutedAt datetime2 DEFAULT SYSUTCDATETIME()
);

DECLARE @tbl sysname;
DECLARE @importName sysname;
DECLARE @existsImport bit;
DECLARE @existsTarget bit;

DECLARE cur CURSOR LOCAL FAST_FORWARD FOR
SELECT TableName FROM @tablesToFinalize ORDER BY TableName;

OPEN cur;
FETCH NEXT FROM cur INTO @tbl;
WHILE @@FETCH_STATUS = 0
BEGIN
  SET @importName = @tbl + '_Import';

  SELECT @existsImport = CASE WHEN OBJECT_ID(@importName,'U') IS NOT NULL THEN 1 ELSE 0 END;
  SELECT @existsTarget = CASE WHEN OBJECT_ID(@tbl,'U') IS NOT NULL THEN 1 ELSE 0 END;

  IF @existsImport = 0
  BEGIN
    INSERT INTO #FinalizeResults(TableName, ActionTaken, ErrorMessage)
    VALUES (@tbl, 'SKIPPED', CONCAT('No existe tabla import: ', @importName));
    FETCH NEXT FROM cur INTO @tbl;
    CONTINUE;
  END

  BEGIN TRY
    BEGIN TRAN;

    IF @existsTarget = 0
    BEGIN
      DECLARE @createSql nvarchar(max) = N'SELECT TOP 0 * INTO dbo.' + QUOTENAME(@tbl) + N' FROM dbo.' + QUOTENAME(@importName) + N';';
      EXEC sp_executesql @createSql;
      INSERT INTO #FinalizeResults(TableName, ActionTaken)
      VALUES (@tbl, 'CREATED_TABLE_FROM_IMPORT');
    END
    ELSE
    BEGIN
      INSERT INTO #FinalizeResults(TableName, ActionTaken)
      VALUES (@tbl, 'TABLE_EXISTS_WILL_MERGE');
    END

    DECLARE @cols nvarchar(max);
    SELECT @cols = STUFF((
      SELECT ',' + QUOTENAME(name)
      FROM sys.columns
      WHERE object_id = OBJECT_ID(@importName)
      ORDER BY column_id
      FOR XML PATH(''), TYPE).value('.', 'nvarchar(max)'
    ,1,1,'');

    IF @cols IS NULL OR LEN(@cols)=0
    BEGIN
      RAISERROR('No se pudieron obtener columnas para %s',16,1,@importName);
    END

    DECLARE @identityCol sysname = NULL;
    SELECT TOP 1 @identityCol = c.name
    FROM sys.columns c
    WHERE c.object_id = OBJECT_ID(@importName) AND COLUMNPROPERTY(c.object_id, c.name, 'IsIdentity') = 1;

    DECLARE @pkCols nvarchar(max) = NULL;
    SELECT @pkCols = STUFF((
      SELECT ',' + QUOTENAME(kc.name)
      FROM sys.indexes i
      JOIN sys.index_columns ic ON i.object_id = ic.object_id AND i.index_id = ic.index_id
      JOIN sys.columns kc ON kc.object_id = ic.object_id AND kc.column_id = ic.column_id
      WHERE i.object_id = OBJECT_ID(@tbl) AND i.is_primary_key = 1
      ORDER BY ic.key_ordinal
      FOR XML PATH(''), TYPE).value('.', 'nvarchar(max)'
    ,1,1,'');

    IF @existsTarget = 0
    BEGIN
      -- Insertar todo desde la import a la tabla nueva (usando dynamic SQL si hay identity)
      IF @identityCol IS NOT NULL
      BEGIN
        DECLARE @sqlId nvarchar(max) = N'SET IDENTITY_INSERT dbo.' + QUOTENAME(@tbl) + N' ON; ' +
          N'INSERT INTO dbo.' + QUOTENAME(@tbl) + N' (' + @cols + N') SELECT ' + @cols + N' FROM dbo.' + QUOTENAME(@importName) + N'; ' +
          N'SET IDENTITY_INSERT dbo.' + QUOTENAME(@tbl) + N' OFF;';
        EXEC sp_executesql @sqlId;
      END
      ELSE
      BEGIN
        DECLARE @sqlNoId nvarchar(max) = N'INSERT INTO dbo.' + QUOTENAME(@tbl) + N' (' + @cols + N') SELECT ' + @cols + N' FROM dbo.' + QUOTENAME(@importName) + N';';
        EXEC sp_executesql @sqlNoId;
      END

      -- Reseed identity if applicable
      IF @identityCol IS NOT NULL
      BEGIN
        DECLARE @maxId int;
        DECLARE @maxIdSql nvarchar(max) = N'SELECT @maxIdOut = ISNULL(MAX(' + QUOTENAME(@identityCol) + N'),0) FROM dbo.' + QUOTENAME(@tbl) + N';';
        EXEC sp_executesql @maxIdSql, N'@maxIdOut int OUTPUT', @maxIdOut=@maxId OUTPUT;
        IF @maxId IS NULL SET @maxId = 0;
        DECLARE @reseed nvarchar(max) = N'DBCC CHECKIDENT (''' + QUOTENAME('dbo') + N'.' + QUOTENAME(@tbl) + N''', RESEED, ' + CAST(@maxId AS nvarchar(20)) + N');';
        EXEC sp_executesql @reseed;
      END

      -- Obtener conteo final (usando dynamic)
      DECLARE @countSql nvarchar(max) = N'SELECT @c = COUNT(1) FROM dbo.' + QUOTENAME(@tbl) + N';';
      DECLARE @c int;
      EXEC sp_executesql @countSql, N'@c int OUTPUT', @c=@c OUTPUT;

      UPDATE #FinalizeResults SET RowsInserted = @c WHERE TableName = @tbl AND RowsInserted IS NULL;
    END
    ELSE
    BEGIN
      IF @pkCols IS NOT NULL AND LEN(@pkCols)>0
      BEGIN
        -- Construir condición NOT EXISTS por PK (usando dynamic)
        -- Normalizamos pkCols para extraer nombres sin [] y luego construir la condición
        DECLARE @pkNoBrackets nvarchar(max) = REPLACE(REPLACE(@pkCols, '[', ''), ']', '');
        DECLARE @pkList TABLE (pos int IDENTITY(1,1), col sysname);
        DECLARE @xml xml = N'<r>' + REPLACE(@pkNoBrackets, ',', '</r><r>') + N'</r>';
        INSERT INTO @pkList(col)
        SELECT r.value('.', 'nvarchar(100)') FROM @xml.nodes('/r') as x(r);

        DECLARE @notExistCond nvarchar(max) = N'NOT EXISTS(SELECT 1 FROM dbo.' + QUOTENAME(@tbl) + N' t WHERE 1=1';
        DECLARE @i int = 1;
        DECLARE @pkColName sysname;
        WHILE @i <= (SELECT COUNT(1) FROM @pkList)
        BEGIN
          SELECT @pkColName = col FROM @pkList WHERE pos=@i;
          SET @notExistCond = @notExistCond + N' AND t.' + QUOTENAME(@pkColName) + N' = s.' + QUOTENAME(@pkColName);
          SET @i = @i + 1;
        END
        SET @notExistCond = @notExistCond + N')';

        DECLARE @insertSql nvarchar(max);
        IF @identityCol IS NOT NULL
        BEGIN
          SET @insertSql = N'SET IDENTITY_INSERT dbo.' + QUOTENAME(@tbl) + N' ON; ' +
            N'INSERT INTO dbo.' + QUOTENAME(@tbl) + N' (' + @cols + N') ' +
            N'SELECT ' + @cols + N' FROM dbo.' + QUOTENAME(@importName) + N' s WHERE ' + @notExistCond + N'; ' +
            N'SET IDENTITY_INSERT dbo.' + QUOTENAME(@tbl) + N' OFF;';
        END
        ELSE
        BEGIN
          SET @insertSql = N'INSERT INTO dbo.' + QUOTENAME(@tbl) + N' (' + @cols + N') ' +
            N'SELECT ' + @cols + N' FROM dbo.' + QUOTENAME(@importName) + N' s WHERE ' + @notExistCond + N';';
        END

        EXEC sp_executesql @insertSql;

        IF @identityCol IS NOT NULL
        BEGIN
          DECLARE @maxId2 int;
          DECLARE @maxIdSql2 nvarchar(max) = N'SELECT @maxIdOut = ISNULL(MAX(' + QUOTENAME(@identityCol) + N'),0) FROM dbo.' + QUOTENAME(@tbl) + N';';
          EXEC sp_executesql @maxIdSql2, N'@maxIdOut int OUTPUT', @maxIdOut=@maxId2 OUTPUT;
          IF @maxId2 IS NULL SET @maxId2 = 0;
          DECLARE @reseed2 nvarchar(max) = N'DBCC CHECKIDENT (''' + QUOTENAME('dbo') + N'.' + QUOTENAME(@tbl) + N''', RESEED, ' + CAST(@maxId2 AS nvarchar(20)) + N');';
          EXEC sp_executesql @reseed2;
        END

        DECLARE @afterCount int;
        DECLARE @countSql2 nvarchar(max) = N'SELECT @c = COUNT(1) FROM dbo.' + QUOTENAME(@tbl) + N';';
        EXEC sp_executesql @countSql2, N'@c int OUTPUT', @c=@afterCount OUTPUT;

        UPDATE #FinalizeResults SET RowsInserted = @afterCount WHERE TableName = @tbl AND RowsInserted IS NULL;
      END
      ELSE
      BEGIN
        INSERT INTO #FinalizeResults(TableName, ActionTaken, ErrorMessage)
        VALUES (@tbl, 'SKIPPED_NO_PK', 'La tabla final ya existe y no se pudo determinar PK para un merge seguro. Se omite para evitar duplicados.');
      END
    END

    COMMIT TRAN;
  END TRY
  BEGIN CATCH
    IF XACT_STATE() <> 0 ROLLBACK TRAN;
    DECLARE @errMsg nvarchar(max) = ERROR_MESSAGE() + ' Line: ' + CAST(ERROR_LINE() AS nvarchar(10));
    INSERT INTO #FinalizeResults(TableName, ActionTaken, ErrorMessage)
    VALUES (@tbl, 'ERROR', @errMsg);
  END CATCH;

  FETCH NEXT FROM cur INTO @tbl;
END

CLOSE cur;
DEALLOCATE cur;

SELECT * FROM #FinalizeResults ORDER BY ExecutedAt, TableName;
GO
