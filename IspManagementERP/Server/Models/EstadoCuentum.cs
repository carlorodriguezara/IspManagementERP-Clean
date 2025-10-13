using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class EstadoCuentum
{
    public int Id { get; set; }

    public string? EstadoCuenta { get; set; }

    public int? TenantId { get; set; }
}
