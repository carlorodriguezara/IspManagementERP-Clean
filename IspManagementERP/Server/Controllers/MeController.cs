using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using IspManagementERP.Server.Models;

namespace IspManagementERP.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class MeController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public MeController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet("permissions")]
        public async Task<IActionResult> GetPermissions()
        {
            var userId = User.FindFirst("sub")?.Value ?? User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null) return Unauthorized();

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return Unauthorized();

            var roles = await _userManager.GetRolesAsync(user);
            var claims = await _userManager.GetClaimsAsync(user);

            return Ok(new
            {
                UserId = user.Id,
                Email = user.Email,
                Roles = roles,
                Claims = claims.Select(c => new { c.Type, c.Value })
            });
        }
    }
}
