using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Recepcionmercaderium
{
    public int Id { get; set; }

    public int? IdCompra { get; set; }

    public DateTime? FechaRecepcion { get; set; }

    public int? IdEmpleadoRecepcion { get; set; }

    public string? Notas { get; set; }

    public int? TenantId { get; set; }
}
