using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Tipocuentum
{
    public int Id { get; set; }

    public string? TipoCuenta { get; set; }

    public int? TenantId { get; set; }
}
