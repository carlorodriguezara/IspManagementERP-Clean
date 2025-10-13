using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Ubicacioncaja
{
    public int Id { get; set; }

    public string? Ubicacion { get; set; }

    public int? TenantId { get; set; }
}
