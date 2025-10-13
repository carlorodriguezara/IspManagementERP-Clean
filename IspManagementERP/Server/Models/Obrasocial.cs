using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Obrasocial
{
    public int Id { get; set; }

    public string? NombreObraSocial { get; set; }

    public string? TipoPlan { get; set; }

    public string? Cobertura { get; set; }

    public string? ContactoNombre { get; set; }

    public string? ContactoTelefono { get; set; }

    public string? ContactoEmail { get; set; }

    public string? Direccion { get; set; }

    public int? TenantId { get; set; }
}
