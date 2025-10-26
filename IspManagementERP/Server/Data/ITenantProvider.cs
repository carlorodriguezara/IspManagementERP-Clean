namespace IspManagementERP.Server.Data
{
    // Servicio que expone el tenant actual
    public interface ITenantProvider
    {
        int CurrentTenantId { get; }
        bool IsSuperAdmin { get; }
    }
}
