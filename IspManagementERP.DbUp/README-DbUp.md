```markdown
# IspManagement_DbUp

Proyecto pequeño que ejecuta scripts SQL versionados con DbUp.
Objetivo: mantener el esquema de Azure SQL sincronizado desde CI/CD.

Cómo usar (local)
1. Compilar:
   dotnet restore
   dotnet build -c Release

2. Ejecutar localmente (necesitas una connection string local):
   Windows PowerShell:
     $env:ConnectionStrings__Default = "Server=...;Initial Catalog=Isp_Solutions;User ID=...;Password=...;Encrypt=True;TrustServerCertificate=False;"
     dotnet run --project IspManagement_DbUp/IspManagement_DbUp.csproj -c Release

3. Estructura de scripts:
   - Coloca scripts en IspManagement_DbUp/Scripts
   - Nómbralos con prefijo numérico para orden (001_, 002_, ...)
   - DbUp registrará los scripts aplicados en la tabla SchemaVersions

Precauciones
- Hacer backup (bacpac) antes de ejecutar en producción
- Probar el workflow en DB de staging primero
- No editar scripts ya aplicados (crear script de corrección si hace falta)

Integración en GitHub Actions
- Ver .github/workflows/dbup-isp.yml
- Crear secret AZURE_SQL_CONNECTION en repo settings con la connection string completa
```