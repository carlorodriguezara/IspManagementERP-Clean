using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Estadocheque
{
    public int Id { get; set; }

    public string? EstadoCheque1 { get; set; }

    public int? TenantId { get; set; }
}
