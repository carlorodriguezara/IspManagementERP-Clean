using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Detallespagosimpuesto
{
    public int Id { get; set; }

    public int? PagoId { get; set; }

    public int? ImpuestoId { get; set; }

    public decimal? MontoImpuesto { get; set; }
}
