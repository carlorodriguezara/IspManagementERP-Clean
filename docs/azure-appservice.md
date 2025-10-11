# Configuración de App Service y cadena de conexión en Azure

## Pasos

1. Entra a tu App Service en Azure > Configuración > Configuración de la aplicación.
2. Agrega la cadena de conexión `DefaultConnection` con el valor de tu Azure SQL Database y tipo SQLAzure.
3. Agrega el setting `ASPNETCORE_ENVIRONMENT = Production`.
4. En el SQL Server de Azure, permite el acceso desde servicios Azure y/o tu IP pública para desarrollo.
5. (Opcional) Para pruebas locales, puedes usar temporalmente la cadena de Azure en tu appsettings.Development.json.
6. No subas nunca el usuario/contraseña de Azure a GitHub.

---