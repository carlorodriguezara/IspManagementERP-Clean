# Integración Roles/Claims (Dapper + Repositorios) — pasos rápidos

1) Añadir paquetes NuGet (ejecutar en la solución / proyecto correcto)
- En proyecto IspManagement.Repositories:
  dotnet add IspManagement.Repositories package Dapper
  dotnet add IspManagement.Repositories package Microsoft.Data.SqlClient

- Si no existe en Repositories, añade referencia a Microsoft.Extensions.Logging.Abstractions si hace falta.

2) Colocar archivos:
- Copia `IIdentityAdminRepository.cs` y `DapperIdentityAdminRepository.cs` en `IspManagement.Repositories/Identity/`
- Copia `IdentityDtos.cs` en `IspManagement.Shared/Identity/`
- Copia `AdminIdentityController.cs` en `IspManagement.Server/Controllers/`
- Copia `RoleAssignModal.razor` en `IspManagement.Client/Shared/`

3) Registrar DI (Server/Program.cs)
- Agrega:
  using System.Data;
  using System.Data.SqlClient;
  using IspManagement.Repositories.Identity;
- Dentro de builder.Services:
  builder.Services.AddTransient<IDbConnection>(sp => new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));
  builder.Services.AddScoped<IIdentityAdminRepository, DapperIdentityAdminRepository>();

4) Asegura que AddIdentity / AddDefaultIdentity / AddIdentityCore y RoleManager están configurados en Program.cs (ya los tienes en tu proyecto).

5) Uso en Client:
- En la página AdminUsers (o donde muestres la lista de usuarios) añade:
  @ref RoleAssignModal roleAssignModal
- Por fila:
  <button class="btn btn-sm" @onclick="() => await roleAssignModal.ShowAsync(user.Id, user.Email, user.UserName, user.FullName, user.ProfilePictureBase64)">Acciones</button>

6) Pruebas:
- Inicia la app.
- GET /api/admin/roles -> devuelve roles.
- GET /api/admin/users?page=1&pageSize=20 -> lista usuarios paginados.
- Prueba UI: abrir modal -> asignar / quitar roles.
- Si aparece error 401/403 revisa la policy "CanManageUsers" o usa [Authorize(Roles="Admin")] temporalmente.

7) Notas de diseño:
- Lecturas: DapperRepository (alto rendimiento).
- Escrituras críticas (crear/assign/remove): UserManager / RoleManager (mantener invariantes Identity).
- DTOs en Shared para que Client pueda modelar responses.
