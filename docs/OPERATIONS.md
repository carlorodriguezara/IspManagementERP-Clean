```markdown
# OPERATIONS (DEV) - IspManagementERP

Resumen rápido para desarrollo:

- Ejecutar local:
  - Establecer environment:
    - Windows PowerShell:
      $Env:ASPNETCORE_ENVIRONMENT = "Development"
      $Env:ISP_DEFAULT_CONNECTION = "Server=localhost;Database=Isp_Solutions_Dev;Integrated Security=True;TrustServerCertificate=True;"
  - Aplicar migraciones (local):
    .\scripts\apply-migrations-dev.ps1

- CI:
  - .github/workflows/ci.yml: build & test.
  - CD a Azure se implementará cuando configuremos secrets/az login.

- Secrets / configuración:
  - No guardar connection strings en repo.
  - Para despliegues usar GitHub Secrets o Key Vault.

- Admin role:
  - En DEV se puede seedear manualmente o vía script SQL.
  - En PROD: crear Admin vía runbook / CLI (no seed automático).

- Backup:
  - Implementar backup con az sql db export o sqlpackage antes de migraciones en PROD.
```
