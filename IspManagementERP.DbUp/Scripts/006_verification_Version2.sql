USE ispdb_clean;
GO

-- 04_verification.sql: verificaciones después de import + mapping

-- Counts
SELECT 'AspNetUsers_Import' AS Tabla, COUNT(*) AS Filas FROM dbo.AspNetUsers_Import
UNION ALL
SELECT 'AspNetRoles_Import', COUNT(*) FROM dbo.AspNetRoles_Import
UNION ALL
SELECT 'AspNetUserClaims_Import', COUNT(*) FROM dbo.AspNetUserClaims_Import
UNION ALL
SELECT 'AspNetUserLogins_Import', COUNT(*) FROM dbo.AspNetUserLogins_Import
UNION ALL
SELECT 'AspNetUserRoles_Import', COUNT(*) FROM dbo.AspNetUserRoles_Import
UNION ALL
SELECT 'AspNetUserTokens_Import', COUNT(*) FROM dbo.AspNetUserTokens_Import
UNION ALL
SELECT 'AspNetRoleClaims_Import', COUNT(*) FROM dbo.AspNetRoleClaims_Import
UNION ALL
SELECT 'AuditEntries_Import', COUNT(*) FROM dbo.AuditEntries_Import
UNION ALL
SELECT 'ClaimDefinitions_Import', COUNT(*) FROM dbo.ClaimDefinitions_Import
UNION ALL
SELECT 'DeviceCodes_Import', COUNT(*) FROM dbo.DeviceCodes_Import
UNION ALL
SELECT 'Keys_Import', COUNT(*) FROM dbo.Keys_Import
UNION ALL
SELECT 'PersistedGrants_Import', COUNT(*) FROM dbo.PersistedGrants_Import;
GO

-- TOP5 usuarios
SELECT TOP(5) Id, UserName, Tenant_Id FROM dbo.AspNetUsers_Import ORDER BY Id;
GO

-- Comprobar Tenant_Id sin mapping (debe ser 0)
SELECT COUNT(*) AS UnmappedCount FROM dbo.AspNetUsers_Import WHERE Tenant_Id IS NOT NULL AND Tenant_Id NOT IN (SELECT AzureTenantGuid FROM dbo.TenantGuidMapping);
GO