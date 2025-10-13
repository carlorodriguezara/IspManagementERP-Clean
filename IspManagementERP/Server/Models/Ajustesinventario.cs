using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Ajustesinventario
{
    public int Id { get; set; }

    public int? IdProducto { get; set; }

    public int? CantidadAnterior { get; set; }

    public int? CantidadNueva { get; set; }

    public DateTime? FechaHoraAjuste { get; set; }

    public string? Notas { get; set; }

    public int? TenantId { get; set; }
}
