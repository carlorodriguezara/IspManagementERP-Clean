using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Tipopago
{
    public int Id { get; set; }

    public string? DetalleTipoPago { get; set; }

    public string? Grupo { get; set; }

    public int? TenantId { get; set; }
}
