namespace IspManagementERP.Server.DTOs
{
    public class UpdateUserModel
    {
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool? IsEnabled { get; set; }
        public int? TenantId { get; set; } // solo para superadmins
    }
}
