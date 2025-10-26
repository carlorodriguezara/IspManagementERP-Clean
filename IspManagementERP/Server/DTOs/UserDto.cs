using System;

namespace IspManagementERP.Server.DTOs
{
    public class UserDto
    {
        public string Id { get; set; } = "";
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? PhoneNumber { get; set; }

        // Campos extras
        public string? Address { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool IsEnabled { get; set; }
        public int TenantId { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
