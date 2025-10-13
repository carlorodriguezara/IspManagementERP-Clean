using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Cuotascredito
{
    public int Id { get; set; }

    public int? CreditoId { get; set; }

    public int? NumeroCuota { get; set; }

    public decimal? MontoCuota { get; set; }

    public DateTime? FechaVencimiento { get; set; }

    public int? EstadoCuotaId { get; set; }

    public string? Notas { get; set; }
}
