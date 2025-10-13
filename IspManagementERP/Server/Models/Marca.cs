using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Marca
{
    public int Id { get; set; }

    public string? NombreMarca { get; set; }

    public int? TenantId { get; set; }
}
