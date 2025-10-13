using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Afiliacionobrasocial
{
    public int Id { get; set; }

    public int? EmpleadoId { get; set; }

    public int? ObraSocialId { get; set; }

    public DateTime? FechaAfiliacion { get; set; }

    public string? NumeroAfiliado { get; set; }

    public int? TenantId { get; set; }
}
