using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Detallemovimientosubalmacen
{
    public int Id { get; set; }

    public int? MovimientoId { get; set; }

    public int? ProductoId { get; set; }

    public decimal? Cantidad { get; set; }

    public decimal? PrecioUnitario { get; set; }

    public int? Estado { get; set; }

    public int? TenantId { get; set; }
}
