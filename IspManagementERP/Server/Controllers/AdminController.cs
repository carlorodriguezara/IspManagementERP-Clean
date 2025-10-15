using IspManagementERP.Server.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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

        public AdminController(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ILogger<AdminController> logger)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
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
        public async Task<IActionResult> CreateRole([FromQuery] string role)
        {
            if (string.IsNullOrWhiteSpace(role)) return BadRequest("Role is required");
            if (await _roleManager.RoleExistsAsync(role)) return BadRequest("Role already exists");

            var res = await _roleManager.CreateAsync(new IdentityRole(role));
            return res.Succeeded ? Ok() : BadRequest(res.Errors);
        }

        [HttpPost("assign-role")]
        public async Task<IActionResult> AssignRole([FromQuery] string userId, [FromQuery] string role)
        {
            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(role))
                return BadRequest("userId and role required");

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return NotFound("User not found");

            if (!await _roleManager.RoleExistsAsync(role))
                await _roleManager.CreateAsync(new IdentityRole(role));

            var res = await _userManager.AddToRoleAsync(user, role);
            return res.Succeeded ? Ok() : BadRequest(res.Errors);
        }

        [HttpPost("remove-role")]
        public async Task<IActionResult> RemoveRole([FromQuery] string userId, [FromQuery] string role)
        {
            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(role))
                return BadRequest("userId and role required");

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return NotFound("User not found");

            var res = await _userManager.RemoveFromRoleAsync(user, role);
            return res.Succeeded ? Ok() : BadRequest(res.Errors);
        }

        [HttpPost("add-claim")]
        public async Task<IActionResult> AddClaim([FromQuery] string userId, [FromQuery] string type, [FromQuery] string value)
        {
            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(type) || string.IsNullOrWhiteSpace(value))
                return BadRequest("userId, type and value required");

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return NotFound("User not found");

            var claim = new Claim(type, value);
            var res = await _userManager.AddClaimAsync(user, claim);
            return res.Succeeded ? Ok() : BadRequest(res.Errors);
        }

        [HttpPost("remove-claim")]
        public async Task<IActionResult> RemoveClaim([FromQuery] string userId, [FromQuery] string type, [FromQuery] string value)
        {
            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(type) || string.IsNullOrWhiteSpace(value))
                return BadRequest("userId, type and value required");

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return NotFound("User not found");

            var claim = new Claim(type, value);
            var res = await _userManager.RemoveClaimAsync(user, claim);
            return res.Succeeded ? Ok() : BadRequest(res.Errors);
        }
    }
}
