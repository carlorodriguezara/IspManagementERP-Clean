using IspManagementERP.Server.Models;
using IspManagementERP.Server.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace IspManagementERP.Server.Controllers
{
    [Authorize(Policy = "CanManageUsers")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<AdminController> _logger;
        private readonly ApplicationDbContext _db;

        public AdminController(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ILogger<AdminController> logger,
            ApplicationDbContext db)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
            _db = db;
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetUsers()
        {
            var baseUsers = _userManager.Users
                .Select(u => new { u.Id, u.UserName, u.Email })
                .ToList();

            var result = new List<object>();
            foreach (var u in baseUsers)
            {
                var user = await _userManager.FindByIdAsync(u.Id);
                var roles = (await _userManager.GetRolesAsync(user)).ToArray();
                var claims = (await _userManager.GetClaimsAsync(user)).Select(c => new { c.Type, c.Value }).ToArray();

                result.Add(new
                {
                    user.Id,
                    user.UserName,
                    user.Email,
                    Roles = roles,
                    Claims = claims
                });
            }

            return Ok(result);
        }

        [HttpGet("roles")]
        public IActionResult GetRoles()
        {
            var roles = _roleManager.Roles.Select(r => new { r.Id, r.Name }).ToList();
            return Ok(roles);
        }

        [HttpPost("create-role")]
        public async Task<IActionResult> CreateRole([FromBody] AssignRoleDto dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.Role)) return BadRequest("Role is required");
            if (await _roleManager.RoleExistsAsync(dto.Role)) return BadRequest("Role already exists");

            var res = await _roleManager.CreateAsync(new IdentityRole(dto.Role));
            if (!res.Succeeded) return BadRequest(res.Errors);

            _logger.LogInformation("Role {Role} created by {Actor}", dto.Role, User?.Identity?.Name);
            _db.AuditEntries.Add(new AuditEntry
            {
                Actor = User?.Identity?.Name ?? "unknown",
                TargetUserId = "",
                Action = "CreateRole",
                Detail = dto.Role
            });
            await _db.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("assign-role")]
        public async Task<IActionResult> AssignRole([FromBody] AssignRoleDto dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.UserId) || string.IsNullOrWhiteSpace(dto.Role))
                return BadRequest("userId and role required");

            var user = await _userManager.FindByIdAsync(dto.UserId);
            if (user == null) return NotFound("User not found");

            if (!await _roleManager.RoleExistsAsync(dto.Role))
                await _roleManager.CreateAsync(new IdentityRole(dto.Role));

            var res = await _userManager.AddToRoleAsync(user, dto.Role);
            if (!res.Succeeded) return BadRequest(res.Errors);

            _logger.LogInformation("User {UserId} assigned role {Role} by {Actor}", dto.UserId, dto.Role, User?.Identity?.Name);
            _db.AuditEntries.Add(new AuditEntry
            {
                Actor = User?.Identity?.Name ?? "unknown",
                TargetUserId = dto.UserId,
                Action = "AssignRole",
                Detail = dto.Role
            });
            await _db.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("remove-role")]
        public async Task<IActionResult> RemoveRole([FromBody] AssignRoleDto dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.UserId) || string.IsNullOrWhiteSpace(dto.Role))
                return BadRequest("userId and role required");

            var user = await _userManager.FindByIdAsync(dto.UserId);
            if (user == null) return NotFound("User not found");

            var res = await _userManager.RemoveFromRoleAsync(user, dto.Role);
            if (!res.Succeeded) return BadRequest(res.Errors);

            _logger.LogInformation("User {UserId} removed from role {Role} by {Actor}", dto.UserId, dto.Role, User?.Identity?.Name);
            _db.AuditEntries.Add(new AuditEntry
            {
                Actor = User?.Identity?.Name ?? "unknown",
                TargetUserId = dto.UserId,
                Action = "RemoveRole",
                Detail = dto.Role
            });
            await _db.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("add-claim")]
        public async Task<IActionResult> AddClaim([FromBody] AddClaimDto dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.UserId) || string.IsNullOrWhiteSpace(dto.Type) || string.IsNullOrWhiteSpace(dto.Value))
                return BadRequest("userId, type and value required");

            var user = await _userManager.FindByIdAsync(dto.UserId);
            if (user == null) return NotFound("User not found");

            var claim = new Claim(dto.Type, dto.Value);
            var res = await _userManager.AddClaimAsync(user, claim);
            if (!res.Succeeded) return BadRequest(res.Errors);

            _logger.LogInformation("Claim {Type}:{Value} added to user {UserId} by {Actor}", dto.Type, dto.Value, dto.UserId, User?.Identity?.Name);
            _db.AuditEntries.Add(new AuditEntry
            {
                Actor = User?.Identity?.Name ?? "unknown",
                TargetUserId = dto.UserId,
                Action = "AddClaim",
                Detail = $"{dto.Type}={dto.Value}"
            });
            await _db.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("remove-claim")]
        public async Task<IActionResult> RemoveClaim([FromBody] AddClaimDto dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.UserId) || string.IsNullOrWhiteSpace(dto.Type) || string.IsNullOrWhiteSpace(dto.Value))
                return BadRequest("userId, type and value required");

            var user = await _userManager.FindByIdAsync(dto.UserId);
            if (user == null) return NotFound("User not found");

            var claim = new Claim(dto.Type, dto.Value);
            var res = await _userManager.RemoveClaimAsync(user, claim);
            if (!res.Succeeded) return BadRequest(res.Errors);

            _logger.LogInformation("Claim {Type}:{Value} removed from user {UserId} by {Actor}", dto.Type, dto.Value, dto.UserId, User?.Identity?.Name);
            _db.AuditEntries.Add(new AuditEntry
            {
                Actor = User?.Identity?.Name ?? "unknown",
                TargetUserId = dto.UserId,
                Action = "RemoveClaim",
                Detail = $"{dto.Type}={dto.Value}"
            });
            await _db.SaveChangesAsync();

            return Ok();
        }
    }
}