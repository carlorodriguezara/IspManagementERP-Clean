using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Caja
{
    public int Id { get; set; }

    public string? NombreCaja { get; set; }

    public string? Descripcion { get; set; }

    public DateTime? FCreacion { get; set; }

    public int? TipocajaId { get; set; }

    public int? EstadoId { get; set; }

    public int? UbicacionId { get; set; }

    public int? ResponsableId { get; set; }

    public int? CtaBcriaAsociadaId { get; set; }

    public int? MonedaId { get; set; }

    public decimal SaldoIncial { get; set; }

    public decimal? SaldoActual { get; set; }

    public int? TenantId { get; set; }
}
