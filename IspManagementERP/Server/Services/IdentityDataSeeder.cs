using IspManagementERP.Server.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IspManagementERP.Server.Service
{
    public class IdentityDataSeeder
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<IdentityDataSeeder> _logger;

        public IdentityDataSeeder(
            RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager,
            ILogger<IdentityDataSeeder> logger)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _logger = logger;
        }

        public async Task SeedAsync(string adminEmail, string adminPassword, bool createAdmin = false)
        {
            // Define roles
            string[] roles = new[] { "Admin", "Manager", "User", "ReadOnly" };
            foreach (var role in roles)
            {
                if (!await _roleManager.RoleExistsAsync(role))
                {
                    var res = await _roleManager.CreateAsync(new IdentityRole(role));
                    if (!res.Succeeded)
                        _logger.LogError("Error creando rol {role}: {errors}", role, string.Join(", ", res.Errors.Select(e => e.Description)));
                }
            }

            if (!createAdmin) return;

            // Crea el admin solo si se solicita (dev)
            var admin = await _userManager.FindByEmailAsync(adminEmail);
            if (admin == null)
            {
                admin = new ApplicationUser { UserName = adminEmail, Email = adminEmail, EmailConfirmed = true };
                var create = await _userManager.CreateAsync(admin, adminPassword);
                if (!create.Succeeded)
                {
                    _logger.LogError("Error creando admin: {errors}", string.Join(", ", create.Errors.Select(e => e.Description)));
                    return;
                }
                await _userManager.AddToRoleAsync(admin, "Admin");
                await _userManager.AddClaimAsync(admin, new Claim("permission", "users.manage"));
                await _userManager.AddClaimAsync(admin, new Claim("permission", "invoices.create"));
                await _userManager.AddClaimAsync(admin, new Claim("permission", "reports.view"));
            }
        }
    }
}
