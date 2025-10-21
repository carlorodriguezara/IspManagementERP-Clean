using Duende.IdentityServer.EntityFramework.Options;
using IspManagementERP.Server.Models;
using IspManagementERP.Shared.Identity;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace IspManagementERP.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // index único por Type+Value para evitar duplicados
            builder.Entity<ClaimDefinition>()
                .HasIndex(c => new { c.Type, c.Value })
                .IsUnique();
        }
        public DbSet<AuditEntry> AuditEntries { get; set; }
        public DbSet<ClaimDefinition> ClaimDefinitions { get; set; } = null!;
    }
}
