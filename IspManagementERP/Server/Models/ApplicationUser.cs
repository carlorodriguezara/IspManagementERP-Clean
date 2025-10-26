using Microsoft.AspNetCore.Identity;

namespace IspManagementERP.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Campos perfiles / negocio
        public string? Address { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        // Guardar imagen en varbinary(max)
        public byte[]? ProfilePicture { get; set; }

        public int UsernameChangeLimit { get; set; } = 0;

        // control lógico de habilitado/suspendido
        public bool IsEnabled { get; set; } = true;

        // Fecha de registro (si no se provee, se puede setear al crear)
        public DateTime? FechaRegistro { get; set; } = DateTime.UtcNow;

        // Código empleado (según tu CSV)
        public string? Empleado { get; set; }

        // Tenant: importante para multitenancy (por ahora default = 1)
        public int TenantId { get; set; } = 1;
    }
}
