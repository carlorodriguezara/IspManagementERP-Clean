using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Cuentasbancaria
{
    public int Id { get; set; }

    public string? NombreCuenta { get; set; }

    public int? TipoCuentaId { get; set; }

    public string? NumeroCuenta { get; set; }

    public decimal? SaldoActual { get; set; }

    public int? BancoId { get; set; }

    public string? SucursalBancaria { get; set; }

    public DateTime? FechaApertura { get; set; }

    public string? EstadoCuenta { get; set; }

    public int? TenantId { get; set; }
}
