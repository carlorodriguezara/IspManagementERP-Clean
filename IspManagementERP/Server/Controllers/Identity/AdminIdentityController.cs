using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using IspManagementERP.Server.Models;
using IspManagementERP.Shared.Identity;
using IspManagementERP.Server.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace IspManagementERP.Server.Controllers.Identity
{
    [ApiController]
    [Route("api/admin/identity")]
    [Authorize(Policy = "CanManageUsers")]
    public class AdminIdentityController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _db;
        private readonly ITenantProvider _tenantProvider;
        private readonly ILogger<AdminIdentityController> _logger;

        public AdminIdentityController(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext db,
            ITenantProvider tenantProvider,
            ILogger<AdminIdentityController> logger)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _db = db;
            _tenantProvider = tenantProvider;
            _logger = logger;
        }

        // existing GetUser and GetUserWithRoles (keep them)...

        // ROLES
        [HttpGet("roles")]
        public async Task<IActionResult> GetRoles()
        {
            var roles = await _roleManager.Roles.OrderBy(r => r.Name).Select(r => r.Name).ToListAsync();
            return Ok(roles);
        }

        [HttpPost("roles")]
        public async Task<IActionResult> CreateRole([FromBody] string role)
        {
            if (string.IsNullOrWhiteSpace(role))
                return BadRequest("Role name is required.");

            role = role.Trim();

            if (await _roleManager.RoleExistsAsync(role))
                return BadRequest("Role already exists.");

            var res = await _roleManager.CreateAsync(new IdentityRole(role));
            if (!res.Succeeded)
                return BadRequest(string.Join("; ", res.Errors.Select(e => e.Description)));

            return Ok(new { role = role });
        }

        [HttpDelete("roles/{role}")]
        public async Task<IActionResult> DeleteRole(string role)
        {
            var r = await _roleManager.FindByNameAsync(role);
            if (r == null) return NotFound();
            var res = await _roleManager.DeleteAsync(r);
            if (!res.Succeeded) return BadRequest(string.Join("; ", res.Errors.Select(e => e.Description)));
            return NoContent();
        }

        // USER ROLES
        [HttpGet("users/{id}/roles")]
        public async Task<IActionResult> GetUserRoles(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            if (!_tenantProvider.IsSuperAdmin && user.TenantId != _tenantProvider.CurrentTenantId) return Forbid();
            var roles = await _userManager.GetRolesAsync(user);
            return Ok(roles);
        }

        [HttpPost("users/{id}/roles")]
        public async Task<IActionResult> AddUserRole(string id, [FromBody] RoleAssignModel model)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            if (!_tenantProvider.IsSuperAdmin && user.TenantId != _tenantProvider.CurrentTenantId) return Forbid();

            if (string.IsNullOrWhiteSpace(model?.Role)) return BadRequest("Role required");
            if (!await _roleManager.RoleExistsAsync(model.Role)) return BadRequest("Role does not exist");

            var res = await _userManager.AddToRoleAsync(user, model.Role);
            if (!res.Succeeded) return BadRequest(string.Join("; ", res.Errors.Select(e => e.Description)));
            return Ok();
        }

        [HttpDelete("users/{id}/roles/{role}")]
        public async Task<IActionResult> RemoveUserRole(string id, string role)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            if (!_tenantProvider.IsSuperAdmin && user.TenantId != _tenantProvider.CurrentTenantId) return Forbid();

            var res = await _userManager.RemoveFromRoleAsync(user, role);
            if (!res.Succeeded) return BadRequest(string.Join("; ", res.Errors.Select(e => e.Description)));
            return NoContent();
        }

        // CLAIM DEFINITIONS (global)
        [HttpGet("claimdefinitions")]
        public async Task<IActionResult> GetClaimDefinitions()
        {
            var rows = await _db.ClaimDefinitions.OrderBy(c => c.Type).ThenBy(c => c.Value).ToListAsync();
            return Ok(rows);
        }

        [HttpPost("claimdefinitions")]
        public async Task<IActionResult> CreateClaimDefinition([FromBody] ClaimDefinition dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.Type) || string.IsNullOrWhiteSpace(dto.Value))
                return BadRequest("Type and Value are required.");

            dto.Type = dto.Type.Trim();
            dto.Value = dto.Value.Trim();

            // Avoid duplicates Type+Value
            var exists = await _db.ClaimDefinitions
                .AnyAsync(c => c.Type == dto.Type && c.Value == dto.Value);
            if (exists) return BadRequest("Claim definition with same Type+Value already exists.");

            dto.CreatedAt = dto.CreatedAt == default ? System.DateTime.UtcNow : dto.CreatedAt;
            _db.ClaimDefinitions.Add(dto);
            await _db.SaveChangesAsync();

            return Ok(dto);
        }

        [HttpDelete("claimdefinitions/{id:int}")]
        public async Task<IActionResult> DeleteClaimDefinition(int id)
        {
            var item = await _db.ClaimDefinitions.FindAsync(id);
            if (item == null) return NotFound();
            _db.ClaimDefinitions.Remove(item);
            await _db.SaveChangesAsync();
            return NoContent();
        }

        // USER CLAIMS
        [HttpGet("users/{id}/claims")]
        public async Task<IActionResult> GetUserClaims(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            if (!_tenantProvider.IsSuperAdmin && user.TenantId != _tenantProvider.CurrentTenantId) return Forbid();

            var claims = (await _userManager.GetClaimsAsync(user))
                .Select(c => new { type = c.Type, value = c.Value })
                .ToList();
            return Ok(claims);
        }

        [HttpPost("users/{id}/claims")]
        public async Task<IActionResult> AddUserClaim(string id, [FromBody] ClaimDto dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.Type)) return BadRequest("Invalid claim");
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            if (!_tenantProvider.IsSuperAdmin && user.TenantId != _tenantProvider.CurrentTenantId) return Forbid();

            var res = await _userManager.AddClaimAsync(user, new System.Security.Claims.Claim(dto.Type, dto.Value ?? ""));
            if (!res.Succeeded) return BadRequest(string.Join("; ", res.Errors.Select(e => e.Description)));
            return Ok();
        }

        [HttpDelete("users/{id}/claims")]
        public async Task<IActionResult> RemoveUserClaim(string id, [FromQuery] string type, [FromQuery] string value)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            if (!_tenantProvider.IsSuperAdmin && user.TenantId != _tenantProvider.CurrentTenantId) return Forbid();

            var claim = new System.Security.Claims.Claim(type, value ?? "");
            var res = await _userManager.RemoveClaimAsync(user, claim);
            if (!res.Succeeded) return BadRequest(string.Join("; ", res.Errors.Select(e => e.Description)));
            return NoContent();
        }

        // PUT api/admin/identity/roles/{role}
        [HttpPut("roles/{role}")]
        public async Task<IActionResult> UpdateRole(string role, [FromBody] string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
                return BadRequest("New role name is required.");

            var existingTarget = await _roleManager.FindByNameAsync(newName);
            if (existingTarget != null)
            {
                return BadRequest("A role with the new name already exists.");
            }

            var r = await _roleManager.FindByNameAsync(role);
            if (r == null) return NotFound();

            // update name
            r.Name = newName;
            var res = await _roleManager.UpdateAsync(r);
            if (!res.Succeeded) return BadRequest(string.Join("; ", res.Errors.Select(e => e.Description)));
            return Ok();
        }

        // NEW: Update ClaimDefinition (PUT)
        // PUT api/admin/identity/claimdefinitions/{id}
        [HttpPut("claimdefinitions/{id:int}")]
        public async Task<IActionResult> UpdateClaimDefinition(int id, [FromBody] ClaimDefinition dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.Type) || string.IsNullOrWhiteSpace(dto.Value))
                return BadRequest("Type and Value are required.");

            var item = await _db.ClaimDefinitions.FindAsync(id);
            if (item == null) return NotFound();

            // check duplication (another row with same Type+Value)
            var dup = await _db.ClaimDefinitions
                .Where(c => c.Id != id && c.Type == dto.Type && c.Value == dto.Value)
                .AnyAsync();
            if (dup) return BadRequest("A claim definition with the same type+value already exists.");

            item.Type = dto.Type;
            item.Value = dto.Value;
            item.Description = dto.Description;
            // keep CreatedAt as is

            await _db.SaveChangesAsync();
            return Ok(item);
        }

        // small DTOs used by endpoints
        public class RoleAssignModel { public string? Role { get; set; } }
    }
}