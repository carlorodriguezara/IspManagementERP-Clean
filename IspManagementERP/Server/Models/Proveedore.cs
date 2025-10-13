using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Proveedore
{
    public int Id { get; set; }

    public string? NombreFiscal { get; set; }

    public string? NombreEmpresa { get; set; }

    public string? RegTributario { get; set; }

    public int? CondPagoId { get; set; }

    public int? CategProveedor { get; set; }

    public string? NombreContacto { get; set; }

    public int? Direccion { get; set; }

    public int? Num { get; set; }

    public string? Email { get; set; }

    public string? SitioWeb { get; set; }

    public int? LocalidadId { get; set; }

    public int? ProvinciaId { get; set; }

    public int? PaisId { get; set; }

    public DateTime? FechaAlta { get; set; }

    public int? RegimenImpositivoId { get; set; }

    public int? Estado { get; set; }

    public int? TenantId { get; set; }
}
