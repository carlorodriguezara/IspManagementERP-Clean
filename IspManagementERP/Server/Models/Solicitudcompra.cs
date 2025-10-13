using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Solicitudcompra
{
    public int Id { get; set; }

    public DateTime? FechaSolicitud { get; set; }

    public string? SolicitanteId { get; set; }

    public int? EstadoSolicitudId { get; set; }

    public DateTime? FechaRequerida { get; set; }

    public string? MotivoSolicitud { get; set; }

    public int? EncargadoComprasId { get; set; }

    public int? TenantId { get; set; }
}
