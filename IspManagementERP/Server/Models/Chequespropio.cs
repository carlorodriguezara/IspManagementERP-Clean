using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Chequespropio
{
    public int Id { get; set; }

    public int? CuentaBancariaId { get; set; }

    public string? NumeroCheque { get; set; }

    public string? Beneficiario { get; set; }

    public decimal? Monto { get; set; }

    public DateTime? FechaEmision { get; set; }

    public DateTime? FechaVencimiento { get; set; }

    public int? EstadoChequeId { get; set; }

    public string? MotivoAnulacion { get; set; }

    public int? TenantId { get; set; }
}
