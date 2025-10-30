param(
  [string]$ConnectionString = $env:AZURE_SQL_CONNECTIONSTRING_DEV
)

if (-not $ConnectionString) {
  Write-Host "AZURE_SQL_CONNECTIONSTRING_DEV not set. Trying ISP_DEFAULT_CONNECTION..."
  $ConnectionString = $env:ISP_DEFAULT_CONNECTION
}

if (-not $ConnectionString) {
  Write-Error "No connection string found. Set AZURE_SQL_CONNECTIONSTRING_DEV or ISP_DEFAULT_CONNECTION."
  exit 1
}

Write-Host "Applying EF migrations for ApplicationDbContext and IspSolutionsContext..."
dotnet tool install --global dotnet-ef --version 7.* -v q
$env:PATH = "$env:USERPROFILE\.dotnet\tools;$env:PATH"
dotnet ef database update --context ApplicationDbContext --project IspManagementERP/Server/IspManagementERP.Server.csproj --startup-project IspManagementERP/Server/IspManagementERP.Server.csproj --connection "$ConnectionString"
dotnet ef database update --context IspSolutionsContext --project IspManagementERP/Server/IspManagementERP.Server.csproj --startup-project IspManagementERP/Server/IspManagementERP.Server.csproj --connection "$ConnectionString"

Write-Host "Migrations applied."
