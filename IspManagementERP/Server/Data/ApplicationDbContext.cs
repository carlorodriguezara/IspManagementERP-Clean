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
        private readonly ITenantProvider _tenantProvider;
        public ApplicationDbContext(
             DbContextOptions<ApplicationDbContext> options,
             IOptions<OperationalStoreOptions> operationalStoreOptions,
             ITenantProvider tenantProvider)
             : base(options, operationalStoreOptions)
        {
            _tenantProvider = tenantProvider;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>(b =>
            {
                b.ToTable("AspNetUsers");
                b.Property(u => u.TenantId).HasColumnName("Tenant_Id").HasDefaultValue(1);
                b.Property(u => u.ProfilePicture).HasColumnType("varbinary(max)").IsRequired(false);
                b.Property(u => u.FechaRegistro).HasColumnName("Fecha_Registro");

                // Si prefieres NO aplicar filtro automático ahora, comenta la línea siguiente.
                b.HasQueryFilter(u => _tenantProvider.IsSuperAdmin || u.TenantId == _tenantProvider.CurrentTenantId);
            });

            // index único por Type+Value para evitar duplicados
            builder.Entity<ClaimDefinition>()
                .HasIndex(c => new { c.Type, c.Value })
                .IsUnique();
        }
        public DbSet<AuditEntry> AuditEntries { get; set; }
        public DbSet<ClaimDefinition> ClaimDefinitions { get; set; } = null!;
    }
}
