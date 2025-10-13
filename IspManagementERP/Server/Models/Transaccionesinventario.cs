using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Transaccionesinventario
{
    public int Id { get; set; }

    public int? IdProducto { get; set; }

    public int? IdUsuario { get; set; }

    public string? TipoTransaccion { get; set; }

    public int? Cantidad { get; set; }

    public DateTime? FechaHoraTransaccion { get; set; }

    public string? Notas { get; set; }

    public int? TenantId { get; set; }
}
