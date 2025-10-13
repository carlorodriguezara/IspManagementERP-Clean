using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Tipoproducto
{
    public int Id { get; set; }

    public string? TipoProducto1 { get; set; }

    public string? Descripcion { get; set; }

    public int? TenantId { get; set; }
}
