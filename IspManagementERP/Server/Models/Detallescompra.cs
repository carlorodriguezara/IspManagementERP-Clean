using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Detallescompra
{
    public int Id { get; set; }

    public int? CompraId { get; set; }

    public int? CoticazionId { get; set; }

    public int? ProductoServicioId { get; set; }

    public int? Cantidad { get; set; }

    public string? UnidadMedida { get; set; }

    public decimal? PrecioUnitario { get; set; }

    public decimal? Subtotal { get; set; }

    public decimal? Descuento { get; set; }

    public decimal? Tasa { get; set; }

    public string? Observaciones { get; set; }

    public decimal? SubtotalIva { get; set; }

    public int? TenantId { get; set; }
}
