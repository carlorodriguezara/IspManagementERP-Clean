using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Detallesolicitudmateriale
{
    public int Id { get; set; }

    public int? SubAlmacenId { get; set; }

    public int SolicitudId { get; set; }

    public int ProductoId { get; set; }

    public decimal CantidadSolicitada { get; set; }

    public string? Estado { get; set; }

    public int TenantId { get; set; }
}
