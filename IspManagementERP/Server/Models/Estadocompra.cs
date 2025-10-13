using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Estadocompra
{
    public int Id { get; set; }

    public string? DetalleEstado { get; set; }

    public int? TenantId { get; set; }
}
