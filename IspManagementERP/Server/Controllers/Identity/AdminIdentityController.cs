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

namespace IspManagementERP.Server.Controllers.Identity
{
    [ApiController]
    [Route("api/admin/identity")]
    [Authorize(Policy = "CanManageUsers")]
    public class AdminIdentityController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITenantProvider _tenantProvider;
        private readonly ILogger<AdminIdentityController> _logger;

        public AdminIdentityController(
            UserManager<ApplicationUser> userManager,
            ITenantProvider tenantProvider,
            ILogger<AdminIdentityController> logger)
        {
            _userManager = userManager;
            _tenantProvider = tenantProvider;
            _logger = logger;
        }

        

        // GET: api/admin/identity/users/{id}
        [HttpGet("users/{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id);
                if (user == null) return NotFound();

                // tenant check
                if (!_tenantProvider.IsSuperAdmin && user.TenantId != _tenantProvider.CurrentTenantId)
                    return Forbid();

                var roles = (await _userManager.GetRolesAsync(user)).ToList();

                var claims = (await _userManager.GetClaimsAsync(user))
                    .Select(c => new ClaimDto { Type = c.Type, Value = c.Value })
                    .ToList();

                var dto = new UserDto
                {
                    Id = user.Id,
                    Email = user.Email ?? "",
                    UserName = user.UserName ?? "",
                    PhoneNumber = user.PhoneNumber,
                    Roles = roles,
                    Claims = claims,
                    Address = user.Address,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    IsEnabled = user.IsEnabled,
                    TenantId = user.TenantId,
                    FechaRegistro = user.FechaRegistro,
                    ProfilePictureBase64 = user.ProfilePicture != null ? Convert.ToBase64String(user.ProfilePicture) : null
                };

                return Ok(dto);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error en GetUser id={UserId}", id);
                return StatusCode(500, new { error = "Error interno del servidor", detail = ex.Message });
            }
        }

        // ... otros endpoints del controller ...
    }
}