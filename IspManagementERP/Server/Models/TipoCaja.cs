using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class TipoCaja
{
    public int Id { get; set; }

    public string? TipoCaja1 { get; set; }

    public string? Descripcion { get; set; }

    public int? TenantId { get; set; }
}
