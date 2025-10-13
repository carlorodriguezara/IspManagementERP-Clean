using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Tiposmovimiento
{
    public int Id { get; set; }

    public string? TipoMovimiento { get; set; }

    public int? TenantId { get; set; }
}
