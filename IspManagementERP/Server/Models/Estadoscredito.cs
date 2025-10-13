using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Estadoscredito
{
    public int Id { get; set; }

    public string EstadoCredito { get; set; } = null!;

    public int? TenantId { get; set; }
}
