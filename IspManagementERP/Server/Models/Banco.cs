using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Banco
{
    public int Id { get; set; }

    public string? NombreBanco { get; set; }

    public string? Direccion { get; set; }

    public int? LocalidadId { get; set; }

    public int? ProvinciaId { get; set; }

    public int? Pais { get; set; }

    public int? TelefonosId { get; set; }

    public int? TenantId { get; set; }
}
