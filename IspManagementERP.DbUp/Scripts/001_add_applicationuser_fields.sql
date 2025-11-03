-- 001_add_applicationuser_fields.sql
-- Agrega columnas que espera ApplicationUser en tu código

IF COL_LENGTH('dbo.AspNetUsers','FirstName') IS NULL
BEGIN
  ALTER TABLE dbo.AspNetUsers ADD FirstName nvarchar(256) NULL;
END;

IF COL_LENGTH('dbo.AspNetUsers','LastName') IS NULL
BEGIN
  ALTER TABLE dbo.AspNetUsers ADD LastName nvarchar(256) NULL;
END;

IF COL_LENGTH('dbo.AspNetUsers','ProfilePicture') IS NULL
BEGIN
  ALTER TABLE dbo.AspNetUsers ADD ProfilePicture varbinary(max) NULL;
END;

IF COL_LENGTH('dbo.AspNetUsers','IsEnabled') IS NULL
BEGIN
  ALTER TABLE dbo.AspNetUsers ADD IsEnabled bit NULL;
END;

IF COL_LENGTH('dbo.AspNetUsers','UsernameChangeLimit') IS NULL
BEGIN
  ALTER TABLE dbo.AspNetUsers ADD UsernameChangeLimit int NULL;
END;