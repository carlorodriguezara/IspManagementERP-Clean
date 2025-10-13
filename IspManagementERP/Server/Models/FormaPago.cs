using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class FormaPago
{
    public int Id { get; set; }

    public string? FormaPago1 { get; set; }

    public int? TenantId { get; set; }
}
