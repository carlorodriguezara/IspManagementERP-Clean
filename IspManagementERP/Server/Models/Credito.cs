using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Credito
{
    public int Id { get; set; }

    public decimal? MontoTotal { get; set; }

    public int? EntidadPrestamistaId { get; set; }

    public decimal? TasaInteresAnual { get; set; }

    public int? PlazoMeses { get; set; }

    public DateTime? FechaDesembolso { get; set; }

    public DateTime? FechaInicioPago { get; set; }

    public string? DestinoCredito { get; set; }

    public int? CajaDesembolsoId { get; set; }

    public int? EstadoCreditoId { get; set; }

    public string? Notas { get; set; }

    public int? TenantId { get; set; }
}
