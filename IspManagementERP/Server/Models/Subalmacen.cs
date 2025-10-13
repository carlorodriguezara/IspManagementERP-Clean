using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Subalmacen
{
    public int Id { get; set; }

    public int? AlmacenGId { get; set; }

    public string Nombre { get; set; } = null!;

    public int? Direccion { get; set; }

    public int? Num { get; set; }

    public int? Localidad { get; set; }

    public int? Provincia { get; set; }

    public int? Pais { get; set; }

    public int? Responsable { get; set; }

    public string? TipoSubAlmacen { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public string? Observaciones { get; set; }

    public int? Estado { get; set; }

    public int? TenantId { get; set; }
}
