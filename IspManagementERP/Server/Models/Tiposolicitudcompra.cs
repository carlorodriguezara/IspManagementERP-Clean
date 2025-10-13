using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Tiposolicitudcompra
{
    public int Id { get; set; }

    public string? TipoSolicictud { get; set; }

    public int? TenantId { get; set; }
}
