using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Remuneracione
{
    public int Id { get; set; }

    public int? TipoRemuneracionId { get; set; }

    public DateTime? FechaProgramada { get; set; }

    public bool? AutorizaFecha { get; set; }

    public int? AutorizaUsuId { get; set; }

    public DateTime? FechaPago { get; set; }

    public decimal? Monto { get; set; }

    public string? ConceptoRemuneracion { get; set; }

    public int? FormaPago { get; set; }

    public bool? EstadoRemuneracion { get; set; }

    public int? EmpleadoId { get; set; }

    public int? ContratistaId { get; set; }

    public int? CajaAsociadaId { get; set; }

    public bool? CuentaAutoriza { get; set; }

    public int? CuentaUsuarioId { get; set; }

    public string? UsuarioRegistraId { get; set; }

    public int? TenantId { get; set; }
}
