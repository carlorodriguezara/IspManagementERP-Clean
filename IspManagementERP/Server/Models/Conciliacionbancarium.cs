using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Conciliacionbancarium
{
    public int Id { get; set; }

    public DateTime? FechaConciliacion { get; set; }

    public decimal? SaldoLibroBancario { get; set; }

    public decimal? SaldoLibroContable { get; set; }

    public bool? Conciliado { get; set; }

    public string? Notas { get; set; }

    public int? CuentaId { get; set; }

    public int? TenantId { get; set; }
}
