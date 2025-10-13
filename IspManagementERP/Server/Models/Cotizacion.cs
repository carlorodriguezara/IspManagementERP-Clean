using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Cotizacion
{
    public int Id { get; set; }

    public string? NroCotizacion { get; set; }

    public DateTime? Fecha { get; set; }

    public DateTime? FechaCotizacion { get; set; }

    public int? AutorizaciónId { get; set; }

    public DateTime? ValidoHasta { get; set; }

    public int? EstadoCotizacionId { get; set; }

    public int? ProveedorId { get; set; }

    public int SolicitudCompraId { get; set; }

    public int? EncargadoComprasId { get; set; }

    public decimal? ExentoNoGrav { get; set; }

    public decimal? RegimenesEspeciales { get; set; }

    public int? FormaPagoId { get; set; }

    public int? MonedaId { get; set; }

    public int? TenantId { get; set; }
}
