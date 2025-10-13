using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Detallepagoscompra
{
    public int Id { get; set; }

    public int? PagoCompraId { get; set; }

    public int? ProductoId { get; set; }

    public int? ProveedorId { get; set; }

    public int? EmpleadoId { get; set; }

    public string? ConceptoPago { get; set; }
}
