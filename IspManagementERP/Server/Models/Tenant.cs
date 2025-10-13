using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Tenant
{
    public int Id { get; set; }

    public string? NombreTenant { get; set; }

    public string? DireccionTenant { get; set; }

    public string? RegistroTributario { get; set; }

    public string? Telefono { get; set; }

    public string? EmailTenant { get; set; }

    public string? SitoWebTenant { get; set; }

    public byte[]? LogoTenant { get; set; }

    public string? Facebook { get; set; }

    public string? Instagram { get; set; }

    public string? Rubro { get; set; }

    public int? PaisId { get; set; }

    public int? ProvinciaId { get; set; }

    public int? LocalidadId { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public bool? Estado { get; set; }

    public int? PlanSuscripcion { get; set; }

    public int? EspacioAlmacenamiento { get; set; }

    public int? LimiteUsuarios { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaExpiracion { get; set; }

    public int? ContactoId { get; set; }

    public string? Observaciones { get; set; }
}
