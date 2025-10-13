using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Movimientoalmacengeneral
{
    public int Id { get; set; }

    public int? AlmacenId { get; set; }

    public int? NumOperacion { get; set; }

    public int? TipoMovimientoId { get; set; }

    public int? SubAlmacenDestinoId { get; set; }

    public int? EmpleadoId { get; set; }

    public DateTime? FechaMovimiento { get; set; }

    public string? Observaciones { get; set; }

    public string? Estado { get; set; }

    public int? TenantId { get; set; }
}
