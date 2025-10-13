using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Tiporemuneracion
{
    public int Id { get; set; }

    public string? DetalleRemuneracion { get; set; }

    public int? TenantId { get; set; }
}
