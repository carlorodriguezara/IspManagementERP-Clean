using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Contratistum
{
    public int Id { get; set; }

    public string? Nombrecontratista { get; set; }

    public int? TipodocumentoId { get; set; }

    public int? NumDocumento { get; set; }

    public string? Direccion { get; set; }

    public int? Localidad { get; set; }

    public int? Provincia { get; set; }

    public int? Pais { get; set; }

    public string? Email { get; set; }

    public int? CelularId { get; set; }

    public int? CtaBancariaId { get; set; }

    public int? TipotrabajoId { get; set; }

    public int? OcupProfId { get; set; }

    public int TenantId { get; set; }
}
