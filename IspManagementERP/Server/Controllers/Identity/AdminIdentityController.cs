using IspManagementERP.Repositories.Identity;
using IspManagementERP.Shared.Identity;
using IspManagementERP.Server.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IspManagementERP.Server.Controllers.Identity
{
    [ApiController]
    [Route("api/admin/identity")]
    [Authorize(Policy = "CanManageUsers")]
    public class AdminIdentityController : ControllerBase
    {
        private readonly IIdentityAdminRepository _repo;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IHostEnvironment _env;
        private readonly ILogger<AdminIdentityController> _logger;

        public AdminIdentityController(
            IIdentityAdminRepository repo,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IHostEnvironment env,
            ILogger<AdminIdentityController> logger)
        {
            _repo = repo;
            _userManager = userManager;
            _roleManager = roleManager; // si hay naming diferente, ajusta; si prefieres consistente, reemplázalo por _roleManager = roleManager;
            _env = env;
            _logger = logger;
        }

        // GET: api/admin/identity/users?page=1&pageSize=20
        [HttpGet("users")]
        public async Task<IActionResult> GetUsers([FromQuery] int page = 1, [FromQuery] int pageSize = 20, [FromQuery] string? q = null)
        {
            try
            {
                var items = await _repo.GetUsersPagedAsync(page, pageSize, q);
                var total = await _repo.CountUsersAsync(q);
                return Ok(new { page, pageSize, total, items });
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error en GetUsers");
                if (_env.IsDevelopment())
                    return StatusCode(500, new { error = ex.Message, stack = ex.StackTrace });
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: api/admin/identity/users/{id}
        [HttpGet("users/{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            var roles = (await _userManager.GetRolesAsync(user)).ToList();
            var claims = (await _userManager.GetClaimsAsync(user)).Select(c => new KeyValuePair<string, string>(c.Type, c.Value)).ToList();

            var dto = new UserDto
            {
                Id = user.Id,
                Email = user.Email ?? "",
                UserName = user.UserName ?? "",
                PhoneNumber = user.PhoneNumber,
                Roles = roles,
                Claims = claims
            };
            return Ok(dto);
        }

        // POST: api/admin/identity/users
        [HttpPost("users")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Password))
                return BadRequest("Password is required for user creation.");

            var user = new ApplicationUser
            {
                UserName = model.UserName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber
            };
            var res = await _userManager.CreateAsync(user, model.Password);
            if (!res.Succeeded) return BadRequest(res.Errors);

            // Optionally add default role(s) or claims.

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, new { id = user.Id });
        }

        // PUT: api/admin/identity/users/{id}
        [HttpPut("users/{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] UpdateUserModel model)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            user.Email = model.Email;
            user.UserName = model.UserName;
            user.PhoneNumber = model.PhoneNumber;

            var res = await _userManager.UpdateAsync(user);
            if (!res.Succeeded) return BadRequest(res.Errors);

            return Ok();
        }

        // DELETE: api/admin/identity/users/{id}
        [HttpDelete("users/{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            var res = await _userManager.DeleteAsync(user);
            if (!res.Succeeded) return BadRequest(res.Errors);

            // Optional: record audit entry in ApplicationDbContext
            return Ok();
        }

        // --- Roles endpoints ---
        [HttpGet("roles")]
        public async Task<IActionResult> GetRoles()
            => Ok(await _repo.GetAllRoleNamesAsync());

        // GET: api/admin/identity/users/{userId}/roles
        [HttpGet("users/{userId}/roles")]
        public async Task<IActionResult> GetUserRoles(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return NotFound();

            var roles = await _userManager.GetRolesAsync(user); // devuelve IEnumerable<string>
            return Ok(roles); // responde JSON: ["Admin","User",...]
        }


        // POST: api/admin/identity/roles
        [HttpPost("roles")]
        public async Task<IActionResult> CreateRole([FromBody] string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName)) return BadRequest("roleName required");
            if (await _roleManager.RoleExistsAsync(roleName)) return Conflict("Role exists");
            var r = await _roleManager.CreateAsync(new IdentityRole(roleName));
            if (!r.Succeeded) return BadRequest(r.Errors);
            return Ok();
        }

        // DELETE: api/admin/identity/roles/{role}
        [HttpDelete("roles/{role}")]
        public async Task<IActionResult> DeleteRole(string role)
        {
            var existing = await _roleManager.FindByNameAsync(role);
            if (existing == null) return NotFound();
            var r = await _roleManager.DeleteAsync(existing);
            if (!r.Succeeded) return BadRequest(r.Errors);
            return Ok();
        }

        // --- Roles assignment already exist: POST users/{userId}/roles and DELETE users/{userId}/roles/{role}
        [HttpPost("users/{userId}/roles")]
        public async Task<IActionResult> AddUserRole(string userId, [FromBody] RoleAssignmentModel model)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return NotFound();
            if (!await _roleManager.RoleExistsAsync(model.Role))
                await _roleManager.CreateAsync(new IdentityRole(model.Role));
            var res = await _userManager.AddToRoleAsync(user, model.Role);
            if (!res.Succeeded) return BadRequest(res.Errors);
            return Ok();
        }

        [HttpDelete("users/{userId}/roles/{role}")]
        public async Task<IActionResult> RemoveUserRole(string userId, string role)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return NotFound();
            var res = await _userManager.RemoveFromRoleAsync(user, role);
            if (!res.Succeeded) return BadRequest(res.Errors);
            return Ok();
        }

        // --- Claims ---
        [HttpGet("users/{userId}/claims")]
        public async Task<IActionResult> GetUserClaims(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return NotFound();
            var claims = (await _userManager.GetClaimsAsync(user)).Select(c => new { c.Type, c.Value });
            return Ok(claims);
        }

        [HttpPost("users/{userId}/claims")]
        public async Task<IActionResult> AddUserClaim(string userId, [FromBody] KeyValuePair<string, string> model)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return NotFound();
            var claim = new Claim(model.Key, model.Value);
            var res = await _userManager.AddClaimAsync(user, claim);
            if (!res.Succeeded) return BadRequest(res.Errors);
            return Ok();
        }

        [HttpDelete("users/{userId}/claims")]
        public async Task<IActionResult> RemoveUserClaim(string userId, [FromQuery] string type, [FromQuery] string value)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return NotFound();
            var res = await _userManager.RemoveClaimAsync(user, new Claim(type, value));
            if (!res.Succeeded) return BadRequest(res.Errors);
            return Ok();
        }
        [HttpGet("claims")]
        public async Task<IActionResult> GetAllClaims()
        {
            try
            {
                var rows = await _repo.GetAllClaimsAsync();
                var dtos = rows.Select(r => new Shared.Identity.ClaimDto { Type = r.Type, Value = r.Value });
                return Ok(dtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en GetAllClaims");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: api/admin/identity/claimdefinitions
        [HttpGet("claimdefinitions")]
        public async Task<IActionResult> GetClaimDefinitions()
        {
            try
            {
                var rows = await _repo.GetClaimDefinitionsAsync();
                return Ok(rows);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetClaimDefinitions");
                return StatusCode(500, "Internal server error");
            }
        }

        // POST: api/admin/identity/claimdefinitions
        [HttpPost("claimdefinitions")]
        public async Task<IActionResult> CreateClaimDefinition([FromBody] ClaimDefinitionDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Type) || string.IsNullOrWhiteSpace(dto.Value))
                return BadRequest("Type and Value are required.");

            try
            {
                dto.CreatedAt = DateTime.UtcNow;
                var created = await _repo.CreateClaimDefinitionAsync(dto);
                return CreatedAtAction(nameof(GetClaimDefinitions), new { id = created.Id }, created);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating ClaimDefinition");
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE: api/admin/identity/claimdefinitions/{id}
        [HttpDelete("claimdefinitions/{id}")]
        public async Task<IActionResult> DeleteClaimDefinition(int id)
        {
            try
            {
                await _repo.DeleteClaimDefinitionAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting ClaimDefinition {Id}", id);
                return StatusCode(500, "Internal server error");
            }
        }
        public class RoleAssignmentModel { public string Role { get; set; } = string.Empty; }
    }
}