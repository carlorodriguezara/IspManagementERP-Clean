using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Saldosporpagar
{
    public int Id { get; set; }

    public int? CreditoId { get; set; }

    public decimal? MontoPendiente { get; set; }

    public string? Notas { get; set; }
}
