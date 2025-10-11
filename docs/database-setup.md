# Configuración de base de datos y migraciones automáticas

## Cadena de conexión local

En `appsettings.json`:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=Isp_Solutions;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

## Cadena de conexión en Azure

Se configura como variable de entorno en el App Service (Azure Portal), no en el código fuente.

## Migraciones automáticas

En `Program.cs` de IspManagementERP.Server:
```csharp
// Apply pending migrations at startup
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate();
}
```

## Crear y aplicar migraciones

```bash
dotnet ef migrations add InitialCreate --project IspManagementERP.Server/IspManagementERP.Server.csproj --startup-project IspManagementERP.Server/IspManagementERP.Server.csproj
dotnet ef database update --project IspManagementERP.Server/IspManagementERP.Server.csproj --startup-project IspManagementERP.Server/IspManagementERP.Server.csproj
```

---