using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Monedum
{
    public int Id { get; set; }

    public string? Moneda { get; set; }

    public string? Simbolo { get; set; }

    public int? TenantId { get; set; }
}
