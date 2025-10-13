using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Pagosproveedore
{
    public int Id { get; set; }

    public int? CompraId { get; set; }

    public DateTime? FechaPago { get; set; }

    public decimal? Monto { get; set; }

    public int? TipoPagoId { get; set; }

    public string? DetallePago { get; set; }

    public int? FormaPagoId { get; set; }

    public string? EstadoPago { get; set; }

    public int? TenantId { get; set; }
}
