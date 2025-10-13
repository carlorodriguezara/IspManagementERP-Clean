using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Empleado
{
    public int Id { get; set; }

    public string? Usuario { get; set; }

    public string? Nombre { get; set; }

    public DateTime? FNacimiento { get; set; }

    public int? TipodocumentoId { get; set; }

    public long? NumDocumento { get; set; }

    public int? Localidad { get; set; }

    public int? Provincia { get; set; }

    public int? Pais { get; set; }

    public int? Direccion { get; set; }

    public int? Num { get; set; }

    public string? Email { get; set; }

    public string? LicenciaConducir { get; set; }

    public DateTime? FVencLicConducir { get; set; }

    public int? EstadoCivilId { get; set; }

    public int? CantidadHijos { get; set; }

    public int? PuestoId { get; set; }

    public DateTime? FIngreso { get; set; }

    public int? ObraSocialId { get; set; }

    public int? CtaBancariaId { get; set; }

    public int? OcupProfId { get; set; }

    public byte[]? Foto { get; set; }

    public int? TenantId { get; set; }

    public int? AreaId { get; set; }
}
