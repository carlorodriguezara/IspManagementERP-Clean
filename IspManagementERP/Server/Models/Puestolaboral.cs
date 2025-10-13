using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Puestolaboral
{
    public int Id { get; set; }

    public string? PuestoLaboral1 { get; set; }

    public int? AreaId { get; set; }

    public int? TenantId { get; set; }
}
