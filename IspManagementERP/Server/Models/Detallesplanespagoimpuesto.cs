using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Detallesplanespagoimpuesto
{
    public int Id { get; set; }

    public int? PlanPagoImpuestoId { get; set; }

    public int? PagoId { get; set; }

    public int? Cuota { get; set; }

    public decimal? MontoCuota { get; set; }

    public DateTime? FechaVencimiento { get; set; }

    public int? EstadoCuota { get; set; }
}
