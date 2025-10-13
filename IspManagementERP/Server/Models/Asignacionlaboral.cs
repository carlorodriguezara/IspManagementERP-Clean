using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Asignacionlaboral
{
    public int Id { get; set; }

    public int? EmpleadoId { get; set; }

    public int? TipoAsignacionId { get; set; }

    public int? EstadoId { get; set; }

    public int? TenantId { get; set; }
}
