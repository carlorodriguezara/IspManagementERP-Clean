using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Vencimientoscredito
{
    public int Id { get; set; }

    public int? CreditoId { get; set; }

    public decimal? MontoVencimiento { get; set; }

    public DateTime? FechaVencimiento { get; set; }

    public string? EstadoVencimiento { get; set; }

    public string? Notas { get; set; }

    public int? TenantId { get; set; }
}
