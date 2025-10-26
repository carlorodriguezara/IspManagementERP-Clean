using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace IspManagementERP.Server.Data
{
    public class TenantProvider : ITenantProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TenantProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        // Por defecto devolvemos 1 si no hay claim
        public int CurrentTenantId
        {
            get
            {
                var ctx = _httpContextAccessor.HttpContext;
                if (ctx?.User?.Identity?.IsAuthenticated == true)
                {
                    var claim = ctx.User.FindFirst("tenant_id") ?? ctx.User.FindFirst("tenant") ?? ctx.User.FindFirst("tenantId");
                    if (claim != null && int.TryParse(claim.Value, out var t))
                        return t;
                }
                return 1; // default temporal
            }
        }

        // Define si usuario es global (super admin). Ajusta el nombre del rol si lo necesitas.
        public bool IsSuperAdmin
        {
            get
            {
                var ctx = _httpContextAccessor.HttpContext;
                if (ctx?.User == null) return false;
                return ctx.User.IsInRole("SuperAdmin") || ctx.User.HasClaim(c => c.Type == "scope" && c.Value == "admin.global");
            }
        }
    }
}
