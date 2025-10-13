using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Almacengeneral
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int? Direccion { get; set; }

    public int? Num { get; set; }

    public int? Localidad { get; set; }

    public int? Provincia { get; set; }

    public int? Pais { get; set; }

    public DateTime? FechaApertura { get; set; }

    public decimal? AreaTotalM2 { get; set; }

    public int? Responsable { get; set; }

    public string? Observaciones { get; set; }

    public int? Estado { get; set; }

    public int? TenantId { get; set; }
}
