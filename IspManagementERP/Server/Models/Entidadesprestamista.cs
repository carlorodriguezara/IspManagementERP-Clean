using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Entidadesprestamista
{
    public int Id { get; set; }

    public string? NombreEntidad { get; set; }

    public string? Direccion { get; set; }

    public int? LocalidadId { get; set; }

    public int? ProvinciaId { get; set; }

    public int? PaisId { get; set; }

    public string? CodigoPostal { get; set; }

    public int? TelefonoId { get; set; }

    public string? CorreoElectronico { get; set; }

    public string? Notas { get; set; }

    public int? TenantId { get; set; }
}
