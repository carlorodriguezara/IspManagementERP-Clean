using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Tipoimpuesto
{
    public int Id { get; set; }

    public string? DetalleImpuesto { get; set; }

    public decimal? TasaImpuesto { get; set; }

    public int? TenantId { get; set; }
}
