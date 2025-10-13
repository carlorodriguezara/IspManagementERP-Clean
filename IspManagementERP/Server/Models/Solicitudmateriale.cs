using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Solicitudmateriale
{
    public int Id { get; set; }

    public int? SubAlmacenId { get; set; }

    public int? AlmacenGId { get; set; }

    public DateTime? FechaSolicitud { get; set; }

    public DateTime? FechaRequerida { get; set; }

    public DateTime? FechaEntrega { get; set; }

    public string? EstadoSolicitud { get; set; }

    public string? Observaciones { get; set; }

    public int TenantId { get; set; }
}
