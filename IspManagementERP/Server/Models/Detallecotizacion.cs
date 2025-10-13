using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Detallecotizacion
{
    public int Id { get; set; }

    public int? CotizacionId { get; set; }

    public int? SolicitudCompraId { get; set; }

    public int? ProductoServicioId { get; set; }

    public int Cantidad { get; set; }

    public string? UnidadMedida { get; set; }

    public decimal? PrecioUnitario { get; set; }

    public decimal? Subtotal { get; set; }

    public decimal? Descuento { get; set; }

    public decimal? Tasa { get; set; }

    public string? Observacion { get; set; }

    public decimal? SubtotalIva { get; set; }

    public int? TenantId { get; set; }
}
