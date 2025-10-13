using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Pagoscredito
{
    public int Id { get; set; }

    public int? CreditoId { get; set; }

    public int? CajaId { get; set; }

    public decimal? MontoPagado { get; set; }

    public DateTime? FechaPago { get; set; }

    public int? FormaPagoId { get; set; }

    public int? NumeroCuota { get; set; }

    public int? EstadoCuotaId { get; set; }

    public string? Descripcion { get; set; }

    public string? Notas { get; set; }
}
