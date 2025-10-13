using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Estadocuotum
{
    public int Id { get; set; }

    public string EstadoPago { get; set; } = null!;

    public int? TenantId { get; set; }
}
