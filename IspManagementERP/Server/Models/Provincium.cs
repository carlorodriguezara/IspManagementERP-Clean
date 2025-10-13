using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Provincium
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Codigo31662 { get; set; }

    public int? PaisId { get; set; }

    public int? TenantId { get; set; }
}
