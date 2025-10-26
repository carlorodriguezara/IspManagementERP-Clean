using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IspManagementERP.Shared.Identity
{
    public class UserDto
    {
        public string Id { get; set; } = "";
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? PhoneNumber { get; set; }

        // Campos extras usados por UI
        public string? Address { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool IsEnabled { get; set; }
        public int TenantId { get; set; }
        public DateTime? FechaRegistro { get; set; }

        // Para preview de imagen en cliente (base64)
        public string? ProfilePictureBase64 { get; set; }

        // Lista de roles (puede venir vacía)
        public List<string>? Roles { get; set; }

        // Helper: cantidad de roles (útil en la tabla)
        public int RolesCount => Roles?.Count ?? 0;
        // NUEVO: lista de claims del usuario (Type/Value)
        public List<ClaimDto>? Claims { get; set; }
    }
}
