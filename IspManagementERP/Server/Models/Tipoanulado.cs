using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Tipoanulado
{
    public int Id { get; set; }

    public string? DetalleTipoAnulado { get; set; }

    public int? TenantId { get; set; }
}
