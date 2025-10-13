using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Ont
{
    public int IdOnt { get; set; }

    public string SerialNumber { get; set; } = null!;

    public string? Modelo { get; set; }

    public string? Estado { get; set; }

    public int? IdCliente { get; set; }

    public virtual Cliente? IdClienteNavigation { get; set; }
}
