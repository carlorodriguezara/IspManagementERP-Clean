using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Telefono
{
    public int Id { get; set; }

    public string? TelefonoCelular { get; set; }

    public int? Activo { get; set; }

    public int? SujetoId { get; set; }

    public string? Tabla { get; set; }

    public int? TenantId { get; set; }

    public string? Referencia { get; set; }

    public string? TipoTelefono { get; set; }

    public string? UsuarioId { get; set; }
}
