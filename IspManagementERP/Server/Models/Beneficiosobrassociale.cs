using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Beneficiosobrassociale
{
    public int Id { get; set; }

    public int? ObraSocialId { get; set; }

    public string? TipoBeneficio { get; set; }

    public string? DescripcionBeneficio { get; set; }

    public int? TenantId { get; set; }
}
