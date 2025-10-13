using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Categoriaservicio
{
    public int Id { get; set; }

    public string? NombreCategoria { get; set; }

    public string? Descripcion { get; set; }

    public int? TenantId { get; set; }
}
