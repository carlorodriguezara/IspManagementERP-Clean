using System;
using System.Collections.Generic;

namespace IspManagementERP.Server.Models;

public partial class Producto
{
    public int Id { get; set; }

    public string? NombreProducto { get; set; }

    public string? Descripcion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public decimal? PrecioUnitario { get; set; }

    public int? UnidadMedidaId { get; set; }

    public int? ProveedorPreferidoId { get; set; }

    public int? CategoriaId { get; set; }

    public int? SubCategoriaId { get; set; }

    public int? MarcaId { get; set; }

    public int? ModeloId { get; set; }

    public int? TipoProducto { get; set; }

    public int? Estado { get; set; }

    public int? TasaIva { get; set; }

    public byte[]? Foto { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public string? Cbarras { get; set; }

    public int? TenantId { get; set; }
}
