using IspManagementERP.Shared.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IspManagementERP.Repositories.Identity
{
    // Repositorio orientado a lecturas (Dapper) para Identity
    public interface IIdentityAdminRepository
    {
        Task<int> CountUsersAsync(string? q = null);
        Task<IEnumerable<UserWithRolesClaimsDto>> GetUsersPagedAsync(int page, int pageSize, string? q = null);

        Task<IEnumerable<RoleDto>> GetRolesAsync();
        Task<IEnumerable<string>> GetAllRoleNamesAsync();

        Task<IEnumerable<string>> GetUserRolesAsync(string userId);
        Task<IEnumerable<(string Type, string Value)>> GetAllClaimsAsync();
        Task<IEnumerable<(string Type, string Value)>> GetUserClaimsAsync(string userId);
        Task<IEnumerable<ClaimDefinitionDTO>> GetClaimDefinitionsAsync();
        Task<ClaimDefinitionDTO> CreateClaimDefinitionAsync(ClaimDefinitionDTO item);
        Task DeleteClaimDefinitionAsync(int id);
    }

    
}
