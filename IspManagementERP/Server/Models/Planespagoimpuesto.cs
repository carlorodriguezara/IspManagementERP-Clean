using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Planespagoimpuesto
{
    public int Id { get; set; }

    public int? ImpuestoId { get; set; }

    public string? NombrePlan { get; set; }

    public string? DescripcionPlan { get; set; }
}
