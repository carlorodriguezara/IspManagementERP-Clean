using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Impuesto
{
    public int Id { get; set; }

    public int? TipoImpuestoId { get; set; }

    public string? NombreImpuesto { get; set; }

    public string? DescripcionImpuesto { get; set; }

    public decimal? TasaImpuesto { get; set; }

    public string? EstadoImpuestoId { get; set; }

    public int? TenantId { get; set; }
}
