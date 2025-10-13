using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Categoriasproducto
{
    public int Id { get; set; }

    public string? Categoria { get; set; }

    public string? Descripcion { get; set; }

    public int? TenantId { get; set; }
}
