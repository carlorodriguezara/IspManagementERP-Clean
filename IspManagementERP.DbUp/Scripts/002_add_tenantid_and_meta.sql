-- 002_add_tenantid_and_meta.sql
-- Agrega Tenant_Id, Address, Empleado, Fecha_Registro si faltan

IF COL_LENGTH('dbo.AspNetUsers','Tenant_Id') IS NULL
BEGIN
  ALTER TABLE dbo.AspNetUsers ADD Tenant_Id uniqueidentifier NULL;
END;

IF COL_LENGTH('dbo.AspNetUsers','Address') IS NULL
BEGIN
  ALTER TABLE dbo.AspNetUsers ADD Address nvarchar(1000) NULL;
END;

IF COL_LENGTH('dbo.AspNetUsers','Empleado') IS NULL
BEGIN
  ALTER TABLE dbo.AspNetUsers ADD Empleado nvarchar(200) NULL;
END;

IF COL_LENGTH('dbo.AspNetUsers','Fecha_Registro') IS NULL
BEGIN
  ALTER TABLE dbo.AspNetUsers ADD Fecha_Registro datetime2 NULL;
END;