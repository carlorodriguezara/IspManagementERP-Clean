using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Servicio
{
    public int Id { get; set; }

    public string? NombreServicio { get; set; }

    public string? Descripcion { get; set; }

    public decimal? Precio { get; set; }

    public int? ProveedorPreferidoId { get; set; }

    public int? DuracionHoras { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaFin { get; set; }

    public int? CategoriaServicioId { get; set; }

    public bool? Activo { get; set; }

    public int? TenantId { get; set; }
}
