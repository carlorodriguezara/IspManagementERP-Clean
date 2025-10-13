using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Pagosanuladosremun
{
    public int Id { get; set; }

    public int? PagoRemunId { get; set; }

    public DateTime? FechaAnulado { get; set; }

    public decimal? Monto { get; set; }

    public int? TipoAnuladoId { get; set; }

    public string? DetalleAnulado { get; set; }

    public int? CajaId { get; set; }

    public int? UsuarioId { get; set; }

    public bool? Autorizado { get; set; }

    public int? AutorizaUsuId { get; set; }

    public int? TenantId { get; set; }
}
