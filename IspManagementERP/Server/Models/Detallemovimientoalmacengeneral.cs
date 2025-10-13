using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Detallemovimientoalmacengeneral
{
    public int Id { get; set; }

    public int? MovimientoId { get; set; }

    public int? NumOperacion { get; set; }

    public int? ProductoId { get; set; }

    public decimal? Cantidad { get; set; }

    public decimal? PrecioUnitario { get; set; }

    public string? Estado { get; set; }

    public DateTime? FechaMovimiento { get; set; }

    public int? TenantId { get; set; }
}
