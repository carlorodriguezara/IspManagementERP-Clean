using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Modelo
{
    public int Id { get; set; }

    public string? NombreModelo { get; set; }

    public int? MarcaId { get; set; }

    public int? TenantId { get; set; }
}
