using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Unidadmedidum
{
    public int Id { get; set; }

    public string Unidad { get; set; } = null!;

    public string? Abreviatura { get; set; }

    public int? TenantId { get; set; }
}
