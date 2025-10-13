using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Tasaiva
{
    public int Id { get; set; }

    public decimal? TasaIva1 { get; set; }

    public int? TenantId { get; set; }
}
