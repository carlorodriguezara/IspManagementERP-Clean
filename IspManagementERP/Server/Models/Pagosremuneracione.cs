using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Pagosremuneracione
{
    public int Id { get; set; }

    public int? RemuneracionId { get; set; }

    public DateTime? FechaPago { get; set; }

    public decimal? Monto { get; set; }

    public int? TipoPagoId { get; set; }

    public string? DetallePago { get; set; }

    public int? FormaPagoId { get; set; }

    public int EstadoPagoId { get; set; }

    public int? CajaId { get; set; }

    public int? PagoAnuladoId { get; set; }

    public string? UsuarioRegistroId { get; set; }

    public int? TenantId { get; set; }
}
