using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class TipoTransaccion
{
    public int Id { get; set; }

    public string? TipoTransaccion1 { get; set; }

    public int? TenantId { get; set; }
}
