using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Paise
{
    public int Id { get; set; }

    public string? Pais { get; set; }

    public string? Gentilicio { get; set; }

    public string? IsoNac { get; set; }

    public int? TenantId { get; set; }
}
