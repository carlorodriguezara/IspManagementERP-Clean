using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Compra
{
    public int Id { get; set; }

    public int? CotizacionId { get; set; }

    public DateTime? FechaCompra { get; set; }

    public int? ProveedorId { get; set; }

    public int? AutorizaId { get; set; }

    public int? EncargadoComprasId { get; set; }

    public string? NumFactura { get; set; }

    public int? FormaPagoId { get; set; }

    public int? EstadoCompraId { get; set; }

    public int? MonedaId { get; set; }

    public decimal? ExentoNoGrav { get; set; }

    public decimal? RegimenesEspeciales { get; set; }

    public string? Observaciones { get; set; }

    public int? TenantId { get; set; }
}
