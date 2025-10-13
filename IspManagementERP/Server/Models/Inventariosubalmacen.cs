using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Inventariosubalmacen
{
    public int Id { get; set; }

    public int? SubAlmacenId { get; set; }

    public int? ProductoId { get; set; }

    public int? CompraId { get; set; }

    public decimal? CantidadTotal { get; set; }

    public decimal? PrecioUnitario { get; set; }

    public DateTime? FechaUltimaActualizacion { get; set; }

    public int? Estado { get; set; }

    public int? TenantId { get; set; }
}
