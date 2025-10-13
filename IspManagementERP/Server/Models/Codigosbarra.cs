using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Codigosbarra
{
    public int Id { get; set; }

    public string? CodigoBarras { get; set; }

    public int? ProductoId { get; set; }

    public int? AlmacenId { get; set; }

    public int? SubAlmacenId { get; set; }

    public int? MovimientoId { get; set; }

    public DateTime? FechaAsignacion { get; set; }

    public int? TenantId { get; set; }
}
