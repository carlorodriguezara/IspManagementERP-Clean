using Dapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IspManagementERP.Shared.Identity;

namespace IspManagementERP.Repositories.Identity
{
    // Implementación Dapper — inyecta IDbConnection (consistente con tu proyecto ProductoRepository)
    public class IdentityAdminRepository : IIdentityAdminRepository
    {
        private readonly IDbConnection _db;
        private readonly ILogger<IdentityAdminRepository> _logger;

        public IdentityAdminRepository(IDbConnection db, ILogger<IdentityAdminRepository> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task<int> CountUsersAsync(string? q = null)
        {
            var sql = @"SELECT COUNT(1) FROM AspNetUsers u
                        WHERE (@q IS NULL OR u.Email LIKE @q OR u.UserName LIKE @q);";
            return await _db.ExecuteScalarAsync<int>(sql, new { q = string.IsNullOrWhiteSpace(q) ? null : $"%{q}%" });
        }

        public async Task<IEnumerable<UserWithRolesClaimsDto>> GetUsersPagedAsync(int page, int pageSize, string? q = null)
        {
            var offset = (page - 1) * pageSize;

            var usersSql = @"
                SELECT Id, Email, UserName
                FROM AspNetUsers
                WHERE (@q IS NULL OR Email LIKE @q OR UserName LIKE @q)
                ORDER BY Email
                OFFSET @offset ROWS FETCH NEXT @pageSize ROWS ONLY;
            ";

            var users = (await _db.QueryAsync(usersSql, new { q = string.IsNullOrWhiteSpace(q) ? null : $"%{q}%", offset, pageSize })).ToList();
            if (!users.Any()) return Enumerable.Empty<UserWithRolesClaimsDto>();

            var ids = users.Select(u => (string)u.Id).ToArray();

            var rolesSql = @"
                SELECT ur.UserId, r.Name
                FROM AspNetUserRoles ur
                JOIN AspNetRoles r ON r.Id = ur.RoleId
                WHERE ur.UserId IN @ids;
            ";
            var roles = (await _db.QueryAsync<(string UserId, string Name)>(rolesSql, new { ids })).ToList();

            var claimsSql = @"
                SELECT UserId, ClaimType, ClaimValue
                FROM AspNetUserClaims
                WHERE UserId IN @ids;
            ";
            var claims = (await _db.QueryAsync<(string UserId, string ClaimType, string ClaimValue)>(claimsSql, new { ids })).ToList();

            var result = new List<UserWithRolesClaimsDto>();
            foreach (var u in users)
            {
                var id = (string)u.Id;
                result.Add(new UserWithRolesClaimsDto
                {
                    Id = id,
                    Email = (string?)u.Email ?? "",
                    UserName = (string?)u.UserName ?? "",
                    Roles = roles.Where(r => r.UserId == id).Select(r => r.Name).ToList(),
                    Claims = claims.Where(c => c.UserId == id)
                                   .Select(c => new KeyValuePair<string, string>(c.ClaimType, c.ClaimValue))
                                   .ToList()
                });
            }
            return result;
        }

        public async Task<IEnumerable<RoleDto>> GetRolesAsync()
        {
            var sql = "SELECT Id, Name FROM AspNetRoles ORDER BY Name;";
            return await _db.QueryAsync<RoleDto>(sql);
        }

        public async Task<IEnumerable<string>> GetAllRoleNamesAsync()
        {
            var sql = "SELECT Name FROM AspNetRoles ORDER BY Name;";
            return await _db.QueryAsync<string>(sql);
        }

        public async Task<IEnumerable<string>> GetUserRolesAsync(string userId)
        {
            var sql = @"SELECT r.Name FROM AspNetUserRoles ur JOIN AspNetRoles r ON r.Id = ur.RoleId WHERE ur.UserId = @userId;";
            return await _db.QueryAsync<string>(sql, new { userId });
        }

        public async Task<IEnumerable<(string Type, string Value)>> GetAllClaimsAsync()
        {
            var sql = @"SELECT DISTINCT ClaimType, ClaimValue
                FROM AspNetUserClaims
                ORDER BY ClaimType, ClaimValue;";
            var rows = await _db.QueryAsync<(string ClaimType, string ClaimValue)>(sql);
            return rows.Select(r => (r.ClaimType, r.ClaimValue));
        }

        public async Task<IEnumerable<(string Type, string Value)>> GetUserClaimsAsync(string userId)
        {
            var sql = @"SELECT ClaimType, ClaimValue FROM AspNetUserClaims WHERE UserId = @userId;";
            var rows = await _db.QueryAsync<(string ClaimType, string ClaimValue)>(sql, new { userId });
            return rows.Select(r => (r.ClaimType, r.ClaimValue));
        }

        public async Task<IEnumerable<ClaimDefinitionDTO>> GetClaimDefinitionsAsync()
        {
            var sql = @"SELECT Id, Type AS Type, Value AS Value, Description, CreatedAt
                        FROM ClaimDefinitions
                        ORDER BY Type, Value;";
            var rows = await _db.QueryAsync(sql);
            var list = new List<ClaimDefinitionDTO>();
            foreach (var r in rows)
            {
                list.Add(new ClaimDefinitionDTO
                {
                    Id = (int)r.Id,
                    Type = (string)r.Type,
                    Value = (string)r.Value,
                    Description = r.Description,
                    CreatedAt = r.CreatedAt
                });
            }
            return list;
        }

        public async Task<ClaimDefinitionDTO> CreateClaimDefinitionAsync(ClaimDefinitionDTO item)
        {
            // Para SQL Server usamos SCOPE_IDENTITY; si usas otro proveedor, ajusta la query.
            var insertSql = @"
                INSERT INTO ClaimDefinitions ([Type], [Value], [Description], [CreatedAt])
                VALUES (@Type, @Value, @Description, @CreatedAt);
                SELECT CAST(SCOPE_IDENTITY() as int);
            ";
            var id = await _db.ExecuteScalarAsync<int>(insertSql, new { item.Type, item.Value, item.Description, item.CreatedAt });
            item.Id = id;
            return item;
        }

        public async Task DeleteClaimDefinitionAsync(int id)
        {
            var sql = "DELETE FROM ClaimDefinitions WHERE Id = @Id";
            await _db.ExecuteAsync(sql, new { Id = id });
        }
    }
}
