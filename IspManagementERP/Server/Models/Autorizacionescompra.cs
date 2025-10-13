using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Autorizacionescompra
{
    public int Id { get; set; }

    public int? IdSolicitudCompra { get; set; }

    public int? IdEmpleadoAutorizador { get; set; }

    public DateTime? FechaAutorizacion { get; set; }

    public string? Notas { get; set; }

    public int? TenantId { get; set; }
}
