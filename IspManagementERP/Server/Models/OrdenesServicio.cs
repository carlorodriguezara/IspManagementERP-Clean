using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class OrdenesServicio
{
    public int IdOrden { get; set; }

    public int IdCliente { get; set; }

    public string? Descripcion { get; set; }

    public string? Estado { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;
}
