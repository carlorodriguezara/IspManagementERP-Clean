-- Crea la tabla Bitacora si no existe
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Bitacora' AND xtype='U')
BEGIN
    CREATE TABLE dbo.Bitacora (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Evento NVARCHAR(200) NOT NULL,
        Usuario NVARCHAR(100) NULL,
        Nivel NVARCHAR(50) NULL,       -- INFO, WARN, ERROR...
        Detalle NVARCHAR(MAX) NULL,
        Origen NVARCHAR(200) NULL,
        FechaRegistro DATETIME2 NOT NULL DEFAULT (SYSDATETIME())
    );
END
GO

-- Inserta un registro inicial si no existe
IF NOT EXISTS (SELECT 1 FROM dbo.Bitacora WHERE Evento = 'Prueba inicial')
BEGIN
    INSERT INTO dbo.Bitacora (Evento, Usuario, Nivel, Detalle, Origen)
    VALUES ('Prueba inicial', 'ci/cd', 'INFO', 'Registro inicial creado por CI', 'dbup');
END
GO