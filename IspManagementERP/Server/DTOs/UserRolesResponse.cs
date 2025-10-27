namespace IspManagementERP.Server.DTOs
{
    public class UserRolesResponse
    {
        public UserDto? User { get; set; }
        public IEnumerable<string>? Roles { get; set; }
    }
}
