using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Movimientoscaja
{
    public int Id { get; set; }

    public int? CajaId { get; set; }

    public int? TipoMovimientoId { get; set; }

    public decimal? Monto { get; set; }

    public DateTime? FechaMovimiento { get; set; }

    public int? RemuneracionId { get; set; }

    public int? ProveedoresId { get; set; }

    public int? EntidadImpuestosId { get; set; }

    public string? Detalles { get; set; }

    public int? TenantId { get; set; }
}
