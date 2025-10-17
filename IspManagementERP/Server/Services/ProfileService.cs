// name=IspManagementERP.Server/Services/ProfileService.cs
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using IspManagementERP.Server.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace IspManagementERP.Server.Service
{
    public class ProfileService : IProfileService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ProfileService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            // Obtener sub (user id) desde el sujeto
            var subjectId = context.Subject?.FindFirst("sub")?.Value;
            if (string.IsNullOrEmpty(subjectId)) return;

            var user = await _userManager.FindByIdAsync(subjectId);
            if (user == null) return;

            var claims = new List<Claim>();

            // Añadir claims guardadas en DB
            var userClaims = await _userManager.GetClaimsAsync(user);
            claims.AddRange(userClaims);

            // Añadir roles como claim "role"
            var roles = await _userManager.GetRolesAsync(user);
            claims.AddRange(roles.Select(r => new Claim("role", r)));

            // También puedes añadir info básica si quieres:
            claims.Add(new Claim("email", user.Email ?? ""));
            claims.Add(new Claim("preferred_username", user.UserName ?? ""));

            // Añadir sólo las claims que el cliente solicitó o todas
            // context.RequestedClaimTypes contiene las types pedidas por el cliente
            var issued = claims.Where(c => context.RequestedClaimTypes == null || context.RequestedClaimTypes.Contains(c.Type)).ToList();

            context.IssuedClaims = context.Subject.Claims.Concat(issued).ToList();
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var subjectId = context.Subject?.FindFirst("sub")?.Value;
            if (string.IsNullOrEmpty(subjectId))
            {
                context.IsActive = false;
                return;
            }

            var user = await _userManager.FindByIdAsync(subjectId);
            context.IsActive = user != null;
        }
    }
}