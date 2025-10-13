using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Documento { get; set; }

    public string? Email { get; set; }

    public string? Telefono { get; set; }

    public DateTime? FechaAlta { get; set; }

    public virtual ICollection<Ont> Onts { get; set; } = new List<Ont>();

    public virtual ICollection<OrdenesServicio> OrdenesServicios { get; set; } = new List<OrdenesServicio>();
}
