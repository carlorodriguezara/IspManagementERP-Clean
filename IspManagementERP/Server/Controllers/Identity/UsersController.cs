using IspManagementERP.Server.Data;
using IspManagementERP.Server.Models;
using IspManagementERP.Shared.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace IspManagementERP.Server.Controllers
{
    [ApiController]
    [Route("api/admin/users")]
    [Authorize(Policy = "CanManageUsers")]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITenantProvider _tenantProvider;

        public UsersController(UserManager<ApplicationUser> userManager, ITenantProvider tenantProvider)
        {
            _userManager = userManager;
            _tenantProvider = tenantProvider;
        }

        // GET api/admin/users
        [HttpGet("Todos")]
        public async Task<IActionResult> GetAllUsers()
        {
           
            // Nota: UserManager.Users devuelve IQueryable<ApplicationUser>
            var query = _userManager.Users.AsQueryable();

            // Aplicar filtro por tenant si no es SuperAdmin
            if (!_tenantProvider.IsSuperAdmin)
            {
                query = query.Where(u => u.TenantId == _tenantProvider.CurrentTenantId);
            }

            var users = query.ToList();

            var results = new List<UserDto>();
            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                // No cargar claims aquí para perf; puedes añadir si lo necesitas
                results.Add(new UserDto
                {
                    Id = user.Id,
                    Email = user.Email,
                    UserName = user.UserName,
                    PhoneNumber = user.PhoneNumber,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Address = user.Address,
                    IsEnabled = user.IsEnabled,
                    TenantId = user.TenantId,
                    FechaRegistro = user.FechaRegistro,
                    Roles = roles?.ToList()
                });
            }

            return Ok(results);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserDetails(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            if (!_tenantProvider.IsSuperAdmin && user.TenantId != _tenantProvider.CurrentTenantId)
                return Forbid();

            var dto = new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber,
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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] UpdateUserModel model)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            if (!_tenantProvider.IsSuperAdmin && user.TenantId != _tenantProvider.CurrentTenantId)
                return Forbid();

            if (model.TenantId.HasValue && _tenantProvider.IsSuperAdmin)
            {
                user.TenantId = model.TenantId.Value;
            }

            if (!string.IsNullOrWhiteSpace(model.Email)) user.Email = model.Email;
            if (!string.IsNullOrWhiteSpace(model.UserName)) user.UserName = model.UserName;
            if (!string.IsNullOrWhiteSpace(model.PhoneNumber)) user.PhoneNumber = model.PhoneNumber;

            user.Address = model.Address;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            if (model.IsEnabled.HasValue) user.IsEnabled = model.IsEnabled.Value;

            // NUEVO: guardar ProfilePictureBase64 en user.ProfilePicture (byte[])
            if (!string.IsNullOrWhiteSpace(model.ProfilePictureBase64))
            {
                try
                {
                    var base64 = model.ProfilePictureBase64;
                    // soportar data URL "data:image/png;base64,...."
                    var comma = base64.IndexOf(',');
                    if (comma >= 0) base64 = base64.Substring(comma + 1);
                    user.ProfilePicture = Convert.FromBase64String(base64);
                }
                catch (FormatException)
                {
                    return BadRequest("ProfilePictureBase64 no es Base64 válido.");
                }
            }

            var res = await _userManager.UpdateAsync(user);
            if (!res.Succeeded) return BadRequest(string.Join("; ", res.Errors.Select(e => e.Description)));
            return NoContent();
        }

        [HttpPost("{id}/suspend")]
        public async Task<IActionResult> SuspendUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            if (!_tenantProvider.IsSuperAdmin && user.TenantId != _tenantProvider.CurrentTenantId) return Forbid();

            user.IsEnabled = false;
            user.LockoutEnabled = true;
            user.LockoutEnd = System.DateTimeOffset.MaxValue;

            var res = await _userManager.UpdateAsync(user);
            if (!res.Succeeded) return BadRequest(string.Join("; ", res.Errors.Select(e => e.Description)));
            return NoContent();
        }

        [HttpPost("{id}/enable")]
        public async Task<IActionResult> EnableUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            if (!_tenantProvider.IsSuperAdmin && user.TenantId != _tenantProvider.CurrentTenantId) return Forbid();

            user.IsEnabled = true;
            user.LockoutEnd = null;

            var res = await _userManager.UpdateAsync(user);
            if (!res.Succeeded) return BadRequest(string.Join("; ", res.Errors.Select(e => e.Description)));
            return NoContent();
        }
    }
}