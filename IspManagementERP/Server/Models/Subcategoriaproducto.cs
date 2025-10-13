using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Subcategoriaproducto
{
    public int Id { get; set; }

    public string? SubCategoria { get; set; }

    public string? Descripcion { get; set; }

    public int? CategoriaId { get; set; }

    public int? TenantId { get; set; }
}
