using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Detallescredito
{
    public int Id { get; set; }

    public int? CreditoId { get; set; }

    public int? CajaId { get; set; }

    public string? DestinoCredito { get; set; }

    public DateTime? FechaDeposito { get; set; }

    public string? Notas { get; set; }
}
