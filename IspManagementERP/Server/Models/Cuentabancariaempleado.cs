using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Cuentabancariaempleado
{
    public int Id { get; set; }

    public int? EmpleadoId { get; set; }

    public string? NumeroCuenta { get; set; }

    public int? TipoCuentaId { get; set; }

    public string? BancoId { get; set; }

    public string? SucursalBanco { get; set; }

    public DateTime? FechaApertura { get; set; }

    public bool? EstadoCuenta { get; set; }

    public int? TenantId { get; set; }
}
