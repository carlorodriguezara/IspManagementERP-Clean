using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Detallepagosremuneracione
{
    public int Id { get; set; }

    public int? PagoId { get; set; }

    public int? RemuneracionId { get; set; }

    public string? ConceptoPago { get; set; }
}
