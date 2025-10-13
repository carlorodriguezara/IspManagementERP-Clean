using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Detallesolicitudcompra
{
    public int Id { get; set; }

    public int? SolicitudCompraId { get; set; }

    public int? ProductoServicioId { get; set; }

    public int? UnidadMedidaId { get; set; }

    public int Cantidad { get; set; }

    public decimal? PrecioUnitario { get; set; }

    public decimal? Subtotal { get; set; }

    public string? Observacion { get; set; }

    public string? TipoProductoServicio { get; set; }

    public int? TenantId { get; set; }
}
