using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class TransaccionProveedor
{
    public int Id { get; set; }

    public DateTime? Fecha { get; set; }

    public int? TipoTransaccion { get; set; }

    public int? CajaId { get; set; }

    public decimal? Monto { get; set; }

    public string? Descripcion { get; set; }

    public int? ProveedorId { get; set; }

    public int? ProductoId { get; set; }

    public int? NumRecibo { get; set; }

    public int? UsuarioId { get; set; }

    public int? FormapagoId { get; set; }

    public int? FacturacompraId { get; set; }

    public int? MonedaId { get; set; }

    public int? TenantId { get; set; }
}
