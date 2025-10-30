param(
  [string]$ResourceGroup = $env:AZURE_RESOURCE_GROUP,
  [string]$ServerName = $env:AZURE_SQL_SERVER_NAME,
  [string]$DatabaseName = $env:AZURE_SQL_DB_NAME,
  [string]$StorageAccount = $env:AZURE_STORAGE_ACCOUNT,
  [string]$StorageContainer = "backups"
)

Write-Host "This script exports a bacpac or calls az sql db export. Configure parameters before use."
Write-Host "ResourceGroup: $ResourceGroup"
Write-Host "Server: $ServerName"
Write-Host "Database: $DatabaseName"

# Placeholder: implement az sql db export or sqlpackage call when ready and secrets are set.
# Example (requires az login and proper permissions):
# az sql db export --admin-user <user> --admin-password <pwd> -g $ResourceGroup -s $ServerName -n $DatabaseName --storage-key <key> --storage-key-type StorageAccessKey --storage-uri "https://$StorageAccount.blob.core.windows.net/$StorageContainer/$DatabaseName.bacpac"
