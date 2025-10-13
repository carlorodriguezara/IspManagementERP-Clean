using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace IspManagementERP.Server.Models;

public partial class IspSolutionsContext : DbContext
{
    public IspSolutionsContext()
    {
    }

    public IspSolutionsContext(DbContextOptions<IspSolutionsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Afiliacionobrasocial> Afiliacionobrasocials { get; set; }

    public virtual DbSet<Ajustesinventario> Ajustesinventarios { get; set; }

    public virtual DbSet<Almacengeneral> Almacengenerals { get; set; }

    public virtual DbSet<Arealaboral> Arealaborals { get; set; }

    public virtual DbSet<Asignacionlaboral> Asignacionlaborals { get; set; }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<Autorizacionescompra> Autorizacionescompras { get; set; }

    public virtual DbSet<Banco> Bancos { get; set; }

    public virtual DbSet<Beneficiosobrassociale> Beneficiosobrassociales { get; set; }

    public virtual DbSet<Caja> Cajas { get; set; }

    public virtual DbSet<Calle> Calles { get; set; }

    public virtual DbSet<CategoriaProveedor> CategoriaProveedors { get; set; }

    public virtual DbSet<Categoriaservicio> Categoriaservicios { get; set; }

    public virtual DbSet<Categoriasproducto> Categoriasproductos { get; set; }

    public virtual DbSet<Chequespropio> Chequespropios { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Codigosbarra> Codigosbarras { get; set; }

    public virtual DbSet<Compra> Compras { get; set; }

    public virtual DbSet<Conciliacionbancarium> Conciliacionbancaria { get; set; }

    public virtual DbSet<Contratistum> Contratista { get; set; }

    public virtual DbSet<Cotizacion> Cotizacions { get; set; }

    public virtual DbSet<Credito> Creditos { get; set; }

    public virtual DbSet<Cuentabancariacontratistum> Cuentabancariacontratista { get; set; }

    public virtual DbSet<Cuentabancariaempleado> Cuentabancariaempleados { get; set; }

    public virtual DbSet<Cuentasbancaria> Cuentasbancarias { get; set; }

    public virtual DbSet<Cuotascredito> Cuotascreditos { get; set; }

    public virtual DbSet<Detallecotizacion> Detallecotizacions { get; set; }

    public virtual DbSet<Detallemovimientoalmacengeneral> Detallemovimientoalmacengenerals { get; set; }

    public virtual DbSet<Detallemovimientosubalmacen> Detallemovimientosubalmacens { get; set; }

    public virtual DbSet<Detallepagoscompra> Detallepagoscompras { get; set; }

    public virtual DbSet<Detallepagosremuneracione> Detallepagosremuneraciones { get; set; }

    public virtual DbSet<Detallescompra> Detallescompras { get; set; }

    public virtual DbSet<Detallescredito> Detallescreditos { get; set; }

    public virtual DbSet<Detallesolicitudcompra> Detallesolicitudcompras { get; set; }

    public virtual DbSet<Detallesolicitudmateriale> Detallesolicitudmateriales { get; set; }

    public virtual DbSet<Detallespagosimpuesto> Detallespagosimpuestos { get; set; }

    public virtual DbSet<Detallesplanespagoimpuesto> Detallesplanespagoimpuestos { get; set; }

    public virtual DbSet<DeviceCode> DeviceCodes { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Entidadesprestamista> Entidadesprestamistas { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<EstadoCuentum> EstadoCuenta { get; set; }

    public virtual DbSet<Estadocaja> Estadocajas { get; set; }

    public virtual DbSet<Estadocheque> Estadocheques { get; set; }

    public virtual DbSet<Estadocivil> Estadocivils { get; set; }

    public virtual DbSet<Estadocompra> Estadocompras { get; set; }

    public virtual DbSet<Estadocotizacion> Estadocotizacions { get; set; }

    public virtual DbSet<Estadocuotum> Estadocuota { get; set; }

    public virtual DbSet<Estadofactura> Estadofacturas { get; set; }

    public virtual DbSet<Estadoimpuesto> Estadoimpuestos { get; set; }

    public virtual DbSet<Estadopago> Estadopagos { get; set; }

    public virtual DbSet<Estadoremuneracion> Estadoremuneracions { get; set; }

    public virtual DbSet<Estadoscredito> Estadoscreditos { get; set; }

    public virtual DbSet<Estadosolicitud> Estadosolicituds { get; set; }

    public virtual DbSet<FormaPago> FormaPagos { get; set; }

    public virtual DbSet<Impuesto> Impuestos { get; set; }

    public virtual DbSet<Inventarioalmacengeneral> Inventarioalmacengenerals { get; set; }

    public virtual DbSet<Inventariosubalmacen> Inventariosubalmacens { get; set; }

    public virtual DbSet<Key> Keys { get; set; }

    public virtual DbSet<Localidad> Localidads { get; set; }

    public virtual DbSet<Marca> Marcas { get; set; }

    public virtual DbSet<Modelo> Modelos { get; set; }

    public virtual DbSet<Monedum> Moneda { get; set; }

    public virtual DbSet<Movimientoalmacengeneral> Movimientoalmacengenerals { get; set; }

    public virtual DbSet<Movimientoscaja> Movimientoscajas { get; set; }

    public virtual DbSet<Movimientosubalmacen> Movimientosubalmacens { get; set; }

    public virtual DbSet<Obrasocial> Obrasocials { get; set; }

    public virtual DbSet<Ocupacionprofesion> Ocupacionprofesions { get; set; }

    public virtual DbSet<Ont> Onts { get; set; }

    public virtual DbSet<OrdenesServicio> OrdenesServicios { get; set; }

    public virtual DbSet<Pagosanuladosremun> Pagosanuladosremuns { get; set; }

    public virtual DbSet<Pagoscredito> Pagoscreditos { get; set; }

    public virtual DbSet<Pagosimpuesto> Pagosimpuestos { get; set; }

    public virtual DbSet<Pagosproveedore> Pagosproveedores { get; set; }

    public virtual DbSet<Pagosremuneracione> Pagosremuneraciones { get; set; }

    public virtual DbSet<Paise> Paises { get; set; }

    public virtual DbSet<Parentesco> Parentescos { get; set; }

    public virtual DbSet<PersistedGrant> PersistedGrants { get; set; }

    public virtual DbSet<Planespagoimpuesto> Planespagoimpuestos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proveedore> Proveedores { get; set; }

    public virtual DbSet<Provincium> Provincia { get; set; }

    public virtual DbSet<Puestolaboral> Puestolaborals { get; set; }

    public virtual DbSet<Recepcionmercaderium> Recepcionmercaderia { get; set; }

    public virtual DbSet<RegimenImpositivo> RegimenImpositivos { get; set; }

    public virtual DbSet<Remuneracione> Remuneraciones { get; set; }

    public virtual DbSet<Rubro> Rubros { get; set; }

    public virtual DbSet<Saldosporpagar> Saldosporpagars { get; set; }

    public virtual DbSet<SchemaVersion> SchemaVersions { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    public virtual DbSet<Solicitudcompra> Solicitudcompras { get; set; }

    public virtual DbSet<Solicitudmateriale> Solicitudmateriales { get; set; }

    public virtual DbSet<Subalmacen> Subalmacens { get; set; }

    public virtual DbSet<Subcategoriaproducto> Subcategoriaproductos { get; set; }

    public virtual DbSet<Tasaiva> Tasaivas { get; set; }

    public virtual DbSet<Telefono> Telefonos { get; set; }

    public virtual DbSet<Tenant> Tenants { get; set; }

    public virtual DbSet<TipoAsignacion> TipoAsignacions { get; set; }

    public virtual DbSet<TipoCaja> TipoCajas { get; set; }

    public virtual DbSet<TipoDocumento> TipoDocumentos { get; set; }

    public virtual DbSet<TipoTransaccion> TipoTransaccions { get; set; }

    public virtual DbSet<Tipoanulado> Tipoanulados { get; set; }

    public virtual DbSet<Tipocuentum> Tipocuenta { get; set; }

    public virtual DbSet<Tipoimpuesto> Tipoimpuestos { get; set; }

    public virtual DbSet<Tipopago> Tipopagos { get; set; }

    public virtual DbSet<Tipoproducto> Tipoproductos { get; set; }

    public virtual DbSet<Tiporemuneracion> Tiporemuneracions { get; set; }

    public virtual DbSet<Tiposmovimiento> Tiposmovimientos { get; set; }

    public virtual DbSet<Tiposolicitudcompra> Tiposolicitudcompras { get; set; }

    public virtual DbSet<Tipotrabajo> Tipotrabajos { get; set; }

    public virtual DbSet<TransaccionProveedor> TransaccionProveedors { get; set; }

    public virtual DbSet<Transaccionesinventario> Transaccionesinventarios { get; set; }

    public virtual DbSet<Ubicacioncaja> Ubicacioncajas { get; set; }

    public virtual DbSet<Unidadmedidum> Unidadmedida { get; set; }

    public virtual DbSet<Vencimientoscredito> Vencimientoscreditos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:sqlserver-telecom-ispsolutions.database.windows.net,1433;Initial Catalog=Isp_Solutions;Persist Security Info=False;User ID=adminarsitel;Password=20letisra25$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Afiliacionobrasocial>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AFILIACI__3214EC27E37CDCAD");

            entity.ToTable("AFILIACIONOBRASOCIAL");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.EmpleadoId).HasColumnName("Empleado_ID");
            entity.Property(e => e.FechaAfiliacion).HasColumnType("date");
            entity.Property(e => e.NumeroAfiliado).HasMaxLength(20);
            entity.Property(e => e.ObraSocialId).HasColumnName("ObraSocial_ID");
            entity.Property(e => e.TenantId).HasColumnName("Tenant_ID");
        });

        modelBuilder.Entity<Ajustesinventario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AJUSTESI__3214EC27B354E8CB");

            entity.ToTable("AJUSTESINVENTARIO");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.FechaHoraAjuste).HasColumnType("datetime");
            entity.Property(e => e.IdProducto).HasColumnName("ID_Producto");
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
        });

        modelBuilder.Entity<Almacengeneral>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AlmacenG__3214EC07327F1A5E");

            entity.ToTable("ALMACENGENERAL");

            entity.Property(e => e.AreaTotalM2).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.FechaApertura).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
        });

        modelBuilder.Entity<Arealaboral>(entity =>
        {
            entity.ToTable("AREALABORAL");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AreaLaboral1)
                .HasMaxLength(50)
                .HasColumnName("AreaLaboral");
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
        });

        modelBuilder.Entity<Asignacionlaboral>(entity =>
        {
            entity.ToTable("ASIGNACIONLABORAL");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.EmpleadoId).HasColumnName("Empleado_ID");
            entity.Property(e => e.EstadoId).HasColumnName("Estado_ID");
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
            entity.Property(e => e.TipoAsignacionId).HasColumnName("TipoAsignacion_ID");
        });

        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.ProviderKey).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.Name).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Autorizacionescompra>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AUTORIZA__3214EC27C38DE6AB");

            entity.ToTable("AUTORIZACIONESCOMPRA");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.FechaAutorizacion).HasColumnType("date");
            entity.Property(e => e.IdEmpleadoAutorizador).HasColumnName("ID_EmpleadoAutorizador");
            entity.Property(e => e.IdSolicitudCompra).HasColumnName("ID_SolicitudCompra");
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
        });

        modelBuilder.Entity<Banco>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BANCOS__3214EC27367DA359");

            entity.ToTable("BANCOS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Direccion).HasMaxLength(100);
            entity.Property(e => e.LocalidadId).HasColumnName("Localidad_ID");
            entity.Property(e => e.NombreBanco).HasMaxLength(50);
            entity.Property(e => e.ProvinciaId).HasColumnName("Provincia_ID");
            entity.Property(e => e.TelefonosId).HasColumnName("Telefonos_ID");
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
        });

        modelBuilder.Entity<Beneficiosobrassociale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BENEFICI__3214EC27DCEF36CF");

            entity.ToTable("BENEFICIOSOBRASSOCIALES");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DescripcionBeneficio).HasMaxLength(100);
            entity.Property(e => e.ObraSocialId).HasColumnName("ObraSocial_ID");
            entity.Property(e => e.TenantId).HasColumnName("Tenant_ID");
            entity.Property(e => e.TipoBeneficio).HasMaxLength(50);
        });

        modelBuilder.Entity<Caja>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CAJAS_1");

            entity.ToTable("CAJAS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CtaBcriaAsociadaId).HasColumnName("CTA_BCRIA_ASOCIADA_ID");
            entity.Property(e => e.Descripcion).HasColumnName("DESCRIPCION");
            entity.Property(e => e.EstadoId).HasColumnName("ESTADO_ID");
            entity.Property(e => e.FCreacion)
                .HasColumnType("datetime")
                .HasColumnName("F_CREACION");
            entity.Property(e => e.MonedaId).HasColumnName("MONEDA_ID");
            entity.Property(e => e.NombreCaja)
                .HasMaxLength(100)
                .HasColumnName("NOMBRE_CAJA");
            entity.Property(e => e.ResponsableId).HasColumnName("RESPONSABLE_ID");
            entity.Property(e => e.SaldoActual)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("SALDO_ACTUAL");
            entity.Property(e => e.SaldoIncial)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("SALDO_INCIAL");
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
            entity.Property(e => e.TipocajaId).HasColumnName("TIPOCAJA_ID");
            entity.Property(e => e.UbicacionId).HasColumnName("UBICACION_ID");
        });

        modelBuilder.Entity<Calle>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("calles");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.NombreCalle)
                .HasMaxLength(120)
                .HasColumnName("Nombre_Calle");
            entity.Property(e => e.TenantId).HasColumnName("Tenant_ID");
        });

        modelBuilder.Entity<CategoriaProveedor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CATEGORIA_PROVEEDOR");

            entity.ToTable("CATEGORIA_PROVEEDOR");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.NombreCategoria)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
        });

        modelBuilder.Entity<Categoriaservicio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CATEGORIASERVICIOS");

            entity.ToTable("CATEGORIASERVICIOS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.NombreCategoria)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
        });

        modelBuilder.Entity<Categoriasproducto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CATEGORI__02AA07856716C765");

            entity.ToTable("CATEGORIASPRODUCTOS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Categoria).HasMaxLength(50);
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
        });

        modelBuilder.Entity<Chequespropio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CHEQUESP__3214EC2748C922D2");

            entity.ToTable("CHEQUESPROPIOS");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Beneficiario).HasMaxLength(100);
            entity.Property(e => e.CuentaBancariaId).HasColumnName("CuentaBancaria_ID");
            entity.Property(e => e.EstadoChequeId).HasColumnName("EstadoCheque_ID");
            entity.Property(e => e.FechaEmision).HasColumnType("date");
            entity.Property(e => e.FechaVencimiento).HasColumnType("date");
            entity.Property(e => e.Monto).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.NumeroCheque).HasMaxLength(20);
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Clientes__D5946642B5F8F792");

            entity.Property(e => e.Documento).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FechaAlta)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(150);
            entity.Property(e => e.Telefono).HasMaxLength(50);
        });

        modelBuilder.Entity<Codigosbarra>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CodigosB__3214EC27AAD7E5F1");

            entity.ToTable("CODIGOSBARRAS");

            entity.HasIndex(e => e.CodigoBarras, "UQ__CodigosB__F61589C873F4118F").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AlmacenId).HasColumnName("AlmacenID");
            entity.Property(e => e.CodigoBarras).HasMaxLength(50);
            entity.Property(e => e.FechaAsignacion).HasColumnType("datetime");
            entity.Property(e => e.MovimientoId).HasColumnName("MovimientoID");
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");
            entity.Property(e => e.SubAlmacenId).HasColumnName("SubAlmacenID");
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
        });

        modelBuilder.Entity<Compra>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__COMPRAS__3214EC27AE5819DC");

            entity.ToTable("COMPRAS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AutorizaId).HasColumnName("Autoriza_ID");
            entity.Property(e => e.CotizacionId).HasColumnName("Cotizacion_ID");
            entity.Property(e => e.EncargadoComprasId).HasColumnName("EncargadoCompras_ID");
            entity.Property(e => e.EstadoCompraId).HasColumnName("EstadoCompra_ID");
            entity.Property(e => e.ExentoNoGrav)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Exento_No_Grav");
            entity.Property(e => e.FechaCompra).HasColumnType("date");
            entity.Property(e => e.FormaPagoId).HasColumnName("FormaPago_ID");
            entity.Property(e => e.MonedaId).HasColumnName("Moneda_ID");
            entity.Property(e => e.NumFactura).HasMaxLength(40);
            entity.Property(e => e.ProveedorId).HasColumnName("Proveedor_ID");
            entity.Property(e => e.RegimenesEspeciales).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
        });

        modelBuilder.Entity<Conciliacionbancarium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CONCILIA__3214EC27082610FC");

            entity.ToTable("CONCILIACIONBANCARIA");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CuentaId).HasColumnName("CUENTA_ID");
            entity.Property(e => e.FechaConciliacion).HasColumnType("date");
            entity.Property(e => e.SaldoLibroBancario).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.SaldoLibroContable).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
        });

        modelBuilder.Entity<Contratistum>(entity =>
        {
            entity.ToTable("CONTRATISTA");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CelularId).HasColumnName("CELULAR_ID");
            entity.Property(e => e.CtaBancariaId).HasColumnName("CTA_BANCARIA_ID");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .HasColumnName("DIRECCION");
            entity.Property(e => e.Email)
                .HasMaxLength(60)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Localidad).HasColumnName("LOCALIDAD");
            entity.Property(e => e.Nombrecontratista)
                .HasMaxLength(120)
                .HasColumnName("NOMBRECONTRATISTA");
            entity.Property(e => e.NumDocumento).HasColumnName("NUM_DOCUMENTO");
            entity.Property(e => e.OcupProfId).HasColumnName("OCUP_PROF_ID");
            entity.Property(e => e.Pais).HasColumnName("PAIS");
            entity.Property(e => e.Provincia).HasColumnName("PROVINCIA");
            entity.Property(e => e.TenantId)
                .ValueGeneratedOnAdd()
                .HasColumnName("TENANT_ID");
            entity.Property(e => e.TipodocumentoId).HasColumnName("TIPODOCUMENTO_ID");
            entity.Property(e => e.TipotrabajoId).HasColumnName("TIPOTRABAJO_ID");
        });

        modelBuilder.Entity<Cotizacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__COTIZACION");

            entity.ToTable("COTIZACION");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.AutorizaciónId).HasColumnName("Autorización_ID");
            entity.Property(e => e.EncargadoComprasId).HasColumnName("EncargadoCompras_ID");
            entity.Property(e => e.EstadoCotizacionId).HasColumnName("EstadoCotizacion_ID");
            entity.Property(e => e.ExentoNoGrav)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Exento_No_Grav");
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.FechaCotizacion).HasColumnType("date");
            entity.Property(e => e.FormaPagoId).HasColumnName("FormaPago_ID");
            entity.Property(e => e.MonedaId).HasColumnName("Moneda_ID");
            entity.Property(e => e.NroCotizacion)
                .HasMaxLength(100)
                .HasColumnName("Nro_Cotizacion");
            entity.Property(e => e.ProveedorId).HasColumnName("Proveedor_ID");
            entity.Property(e => e.RegimenesEspeciales).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SolicitudCompraId).HasColumnName("SolicitudCompra_ID");
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
            entity.Property(e => e.ValidoHasta)
                .HasColumnType("date")
                .HasColumnName("Valido_hasta");
        });

        modelBuilder.Entity<Credito>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CREDITOS__3214EC27E0B00163");

            entity.ToTable("CREDITOS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CajaDesembolsoId).HasColumnName("CajaDesembolso_ID");
            entity.Property(e => e.DestinoCredito).HasColumnType("text");
            entity.Property(e => e.EntidadPrestamistaId).HasColumnName("EntidadPrestamista_ID");
            entity.Property(e => e.EstadoCreditoId).HasColumnName("EstadoCredito_ID");
            entity.Property(e => e.FechaDesembolso).HasColumnType("date");
            entity.Property(e => e.FechaInicioPago).HasColumnType("date");
            entity.Property(e => e.MontoTotal).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.TasaInteresAnual).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
        });

        modelBuilder.Entity<Cuentabancariacontratistum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CUENTABANCARIACONTRATISTA");

            entity.ToTable("CUENTABANCARIACONTRATISTA");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BancoId)
                .HasMaxLength(50)
                .HasColumnName("Banco_ID");
            entity.Property(e => e.ContratistaId).HasColumnName("Contratista_ID");
            entity.Property(e => e.NumeroCuenta).HasMaxLength(50);
            entity.Property(e => e.SucursalBanco).HasMaxLength(50);
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
            entity.Property(e => e.TipoCuentaId).HasColumnName("TipoCuenta_ID");
        });

        modelBuilder.Entity<Cuentabancariaempleado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CUENTABA__3214EC27B344C5BD");

            entity.ToTable("CUENTABANCARIAEMPLEADO");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BancoId)
                .HasMaxLength(50)
                .HasColumnName("Banco_ID");
            entity.Property(e => e.EmpleadoId).HasColumnName("Empleado_ID");
            entity.Property(e => e.FechaApertura).HasColumnType("date");
            entity.Property(e => e.NumeroCuenta).HasMaxLength(50);
            entity.Property(e => e.SucursalBanco).HasMaxLength(50);
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
            entity.Property(e => e.TipoCuentaId).HasColumnName("TipoCuenta_ID");
        });

        modelBuilder.Entity<Cuentasbancaria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CUENTASB__3214EC27BE27904B");

            entity.ToTable("CUENTASBANCARIAS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BancoId).HasColumnName("Banco_ID");
            entity.Property(e => e.EstadoCuenta).HasMaxLength(20);
            entity.Property(e => e.FechaApertura).HasColumnType("date");
            entity.Property(e => e.NombreCuenta).HasMaxLength(50);
            entity.Property(e => e.NumeroCuenta).HasMaxLength(20);
            entity.Property(e => e.SaldoActual).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SucursalBancaria).HasMaxLength(50);
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
            entity.Property(e => e.TipoCuentaId).HasColumnName("TipoCuenta_ID");
        });

        modelBuilder.Entity<Cuotascredito>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CUOTASCR__3214EC276713ECCA");

            entity.ToTable("CUOTASCREDITO");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreditoId).HasColumnName("Credito_ID");
            entity.Property(e => e.EstadoCuotaId).HasColumnName("EstadoCuota_ID");
            entity.Property(e => e.FechaVencimiento).HasColumnType("date");
            entity.Property(e => e.MontoCuota).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Detallecotizacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DETALLEC__3214EC273885E094");

            entity.ToTable("DETALLECOTIZACION");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CotizacionId).HasColumnName("Cotizacion_ID");
            entity.Property(e => e.Descuento).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProductoServicioId).HasColumnName("ProductoServicio_ID");
            entity.Property(e => e.SolicitudCompraId).HasColumnName("SolicitudCompra_ID");
            entity.Property(e => e.Subtotal).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SubtotalIva)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Subtotal_IVA");
            entity.Property(e => e.Tasa).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
            entity.Property(e => e.UnidadMedida).HasMaxLength(10);
        });

        modelBuilder.Entity<Detallemovimientoalmacengeneral>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DETALLEI__3214EC27A8D959C4");

            entity.ToTable("DETALLEMOVIMIENTOALMACENGENERAL");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Cantidad).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaMovimiento).HasColumnType("datetime");
            entity.Property(e => e.MovimientoId).HasColumnName("MovimientoID");
            entity.Property(e => e.NumOperacion).HasColumnName("Num_Operacion");
            entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
        });

        modelBuilder.Entity<Detallemovimientosubalmacen>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DETALLEMOVIMIENTOSUBALMACEN");

            entity.ToTable("DETALLEMOVIMIENTOSUBALMACEN");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Cantidad).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MovimientoId).HasColumnName("MovimientoID");
            entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
        });

        modelBuilder.Entity<Detallepagoscompra>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DETALLEP__3214EC274AE97222");

            entity.ToTable("DETALLEPAGOSCOMPRAS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ConceptoPago)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EmpleadoId).HasColumnName("EmpleadoID");
            entity.Property(e => e.PagoCompraId).HasColumnName("PagoCompra_ID");
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");
            entity.Property(e => e.ProveedorId).HasColumnName("ProveedorID");
        });

        modelBuilder.Entity<Detallepagosremuneracione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DETALLEP__3214EC2784F50677");

            entity.ToTable("DETALLEPAGOSREMUNERACIONES");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ConceptoPago)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PagoId).HasColumnName("Pago_ID");
            entity.Property(e => e.RemuneracionId).HasColumnName("Remuneracion_ID");
        });

        modelBuilder.Entity<Detallescompra>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DETALLES__01B081C1F26F3ED9");

            entity.ToTable("DETALLESCOMPRA");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CompraId).HasColumnName("Compra_ID");
            entity.Property(e => e.CoticazionId).HasColumnName("Coticazion_ID");
            entity.Property(e => e.Descuento).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProductoServicioId).HasColumnName("ProductoServicio_ID");
            entity.Property(e => e.Subtotal).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SubtotalIva)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Subtotal_IVA");
            entity.Property(e => e.Tasa).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
            entity.Property(e => e.UnidadMedida).HasMaxLength(10);
        });

        modelBuilder.Entity<Detallescredito>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DETALLES__3214EC2779D4C151");

            entity.ToTable("DETALLESCREDITOS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CajaId).HasColumnName("Caja_ID");
            entity.Property(e => e.CreditoId).HasColumnName("Credito_ID");
            entity.Property(e => e.DestinoCredito).HasColumnType("text");
            entity.Property(e => e.FechaDeposito).HasColumnType("date");
        });

        modelBuilder.Entity<Detallesolicitudcompra>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DetalleS__3214EC277514F732");

            entity.ToTable("DETALLESOLICITUDCOMPRA");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProductoServicioId).HasColumnName("ProductoServicio_ID");
            entity.Property(e => e.SolicitudCompraId).HasColumnName("SolicitudCompra_ID");
            entity.Property(e => e.Subtotal).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
            entity.Property(e => e.TipoProductoServicio).HasMaxLength(50);
            entity.Property(e => e.UnidadMedidaId).HasColumnName("UnidadMedida_ID");
        });

        modelBuilder.Entity<Detallesolicitudmateriale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DETALLES__CECB425F671EAA19");

            entity.ToTable("DETALLESOLICITUDMATERIALES");

            entity.Property(e => e.CantidadSolicitada).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Estado).HasMaxLength(50);
            entity.Property(e => e.ProductoId).HasColumnName("Producto_Id");
            entity.Property(e => e.SolicitudId).HasColumnName("Solicitud_Id");
            entity.Property(e => e.SubAlmacenId).HasColumnName("SubAlmacen_Id");
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
        });

        modelBuilder.Entity<Detallespagosimpuesto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DETALLES__3214EC27C836E06A");

            entity.ToTable("DETALLESPAGOSIMPUESTOS");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ImpuestoId).HasColumnName("Impuesto_ID");
            entity.Property(e => e.MontoImpuesto).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PagoId).HasColumnName("Pago_ID");
        });

        modelBuilder.Entity<Detallesplanespagoimpuesto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DETALLES__3214EC27F1C36A75");

            entity.ToTable("DETALLESPLANESPAGOIMPUESTO");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.FechaVencimiento).HasColumnType("date");
            entity.Property(e => e.MontoCuota).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PagoId).HasColumnName("Pago_ID");
            entity.Property(e => e.PlanPagoImpuestoId).HasColumnName("PlanPagoImpuesto_ID");
        });

        modelBuilder.Entity<DeviceCode>(entity =>
        {
            entity.HasKey(e => e.UserCode);

            entity.Property(e => e.UserCode).HasMaxLength(200);
            entity.Property(e => e.ClientId).HasMaxLength(200);
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.DeviceCode1)
                .HasMaxLength(200)
                .HasColumnName("DeviceCode");
            entity.Property(e => e.SessionId).HasMaxLength(100);
            entity.Property(e => e.SubjectId).HasMaxLength(200);
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.ToTable("EMPLEADO");

            entity.Property(e => e.AreaId).HasColumnName("AREA_ID");
            entity.Property(e => e.CantidadHijos).HasColumnName("CANTIDAD_HIJOS");
            entity.Property(e => e.CtaBancariaId).HasColumnName("CTA_BANCARIA_ID");
            entity.Property(e => e.Direccion).HasColumnName("DIRECCION");
            entity.Property(e => e.Email)
                .HasMaxLength(60)
                .HasColumnName("EMAIL");
            entity.Property(e => e.EstadoCivilId).HasColumnName("ESTADO_CIVIL_ID");
            entity.Property(e => e.FIngreso)
                .HasColumnType("datetime")
                .HasColumnName("F_INGRESO");
            entity.Property(e => e.FNacimiento)
                .HasColumnType("datetime")
                .HasColumnName("F_NACIMIENTO");
            entity.Property(e => e.FVencLicConducir)
                .HasColumnType("datetime")
                .HasColumnName("F_VENC_LIC_CONDUCIR");
            entity.Property(e => e.Foto).HasColumnName("FOTO");
            entity.Property(e => e.LicenciaConducir)
                .HasMaxLength(50)
                .HasColumnName("LICENCIA_CONDUCIR");
            entity.Property(e => e.Localidad).HasColumnName("LOCALIDAD");
            entity.Property(e => e.Nombre)
                .HasMaxLength(120)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.Num).HasColumnName("NUM");
            entity.Property(e => e.NumDocumento).HasColumnName("NUM_DOCUMENTO");
            entity.Property(e => e.ObraSocialId).HasColumnName("OBRA_SOCIAL_ID");
            entity.Property(e => e.OcupProfId).HasColumnName("OCUP_PROF_ID");
            entity.Property(e => e.Pais).HasColumnName("PAIS");
            entity.Property(e => e.Provincia).HasColumnName("PROVINCIA");
            entity.Property(e => e.PuestoId).HasColumnName("PUESTO_ID");
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
            entity.Property(e => e.TipodocumentoId).HasColumnName("TIPODOCUMENTO_ID");
            entity.Property(e => e.Usuario)
                .HasMaxLength(450)
                .HasColumnName("USUARIO");
        });

        modelBuilder.Entity<Entidadesprestamista>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ENTIDADE__3214EC275D7BFEF3");

            entity.ToTable("ENTIDADESPRESTAMISTAS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CodigoPostal).HasMaxLength(10);
            entity.Property(e => e.CorreoElectronico).HasMaxLength(50);
            entity.Property(e => e.Direccion).HasMaxLength(255);
            entity.Property(e => e.LocalidadId).HasColumnName("Localidad_ID");
            entity.Property(e => e.NombreEntidad).HasMaxLength(100);
            entity.Property(e => e.PaisId).HasColumnName("Pais_ID");
            entity.Property(e => e.ProvinciaId).HasColumnName("Provincia_ID");
            entity.Property(e => e.TelefonoId).HasColumnName("Telefono_ID");
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.ToTable("ESTADO");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DetalleEstado).HasMaxLength(50);
        });

        modelBuilder.Entity<EstadoCuentum>(entity =>
        {
            entity.ToTable("ESTADO_CUENTA");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.EstadoCuenta)
                .HasMaxLength(50)
                .HasColumnName("ESTADO_CUENTA");
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
        });

        modelBuilder.Entity<Estadocaja>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ESTADOCA__3214EC271AAAF488");

            entity.ToTable("ESTADOCAJA");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DetalleEstado).HasMaxLength(50);
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
        });

        modelBuilder.Entity<Estadocheque>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ESTADOCH__3214EC27924B2214");

            entity.ToTable("ESTADOCHEQUE");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.EstadoCheque1)
                .HasMaxLength(50)
                .HasColumnName("EstadoCheque");
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
        });

        modelBuilder.Entity<Estadocivil>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ESTADO CIVIL");

            entity.ToTable("ESTADOCIVIL");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.EstadoCivil1)
                .HasMaxLength(15)
                .HasColumnName("ESTADO_CIVIL");
        });

        modelBuilder.Entity<Estadocompra>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ESTADOCO__3214EC27D8E23314");

            entity.ToTable("ESTADOCOMPRA");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DetalleEstado).HasMaxLength(50);
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
        });

        modelBuilder.Entity<Estadocotizacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ESTADOCO__3214EC279A321354");

            entity.ToTable("ESTADOCOTIZACION");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DetalleEstado).HasMaxLength(50);
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
        });

        modelBuilder.Entity<Estadocuotum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ESTADOCU__3214EC27F1A85936");

            entity.ToTable("ESTADOCUOTA");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.EstadoPago).HasMaxLength(50);
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
        });

        modelBuilder.Entity<Estadofactura>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ESTADOFA__3214EC270A503983");

            entity.ToTable("ESTADOFACTURA");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DetalleEstado).HasMaxLength(50);
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
        });

        modelBuilder.Entity<Estadoimpuesto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ESTADOIM__3214EC2742660D7A");

            entity.ToTable("ESTADOIMPUESTO");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DetalleEstado).HasMaxLength(50);
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
        });

        modelBuilder.Entity<Estadopago>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ESTADOPA__3214EC270986B18E");

            entity.ToTable("ESTADOPAGO");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DetalleEstado).HasMaxLength(50);
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
        });

        modelBuilder.Entity<Estadoremuneracion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ESTADORE__3214EC27BC9FEBDD");

            entity.ToTable("ESTADOREMUNERACION");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DetalleEstado).HasMaxLength(50);
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
        });

        modelBuilder.Entity<Estadoscredito>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ESTADOSC__3214EC27F9AEA011");

            entity.ToTable("ESTADOSCREDITO");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.EstadoCredito).HasMaxLength(50);
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
        });

        modelBuilder.Entity<Estadosolicitud>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ESTADOSO__3214EC272A6838C6");

            entity.ToTable("ESTADOSOLICITUD");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DetalleEstado).HasMaxLength(50);
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
        });

        modelBuilder.Entity<FormaPago>(entity =>
        {
            entity.ToTable("FORMA_PAGO");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.FormaPago1)
                .HasMaxLength(50)
                .HasColumnName("FORMA_PAGO");
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
        });

        modelBuilder.Entity<Impuesto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__IMPUESTO__3214EC273D5F0BBD");

            entity.ToTable("IMPUESTOS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DescripcionImpuesto).HasColumnType("text");
            entity.Property(e => e.EstadoImpuestoId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EstadoImpuesto_ID");
            entity.Property(e => e.NombreImpuesto)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TasaImpuesto).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
            entity.Property(e => e.TipoImpuestoId).HasColumnName("TipoImpuesto_ID");
        });

        modelBuilder.Entity<Inventarioalmacengeneral>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_INVENTARIO");

            entity.ToTable("INVENTARIOALMACENGENERAL");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AlmacenId).HasColumnName("AlmacenID");
            entity.Property(e => e.CantidadTotal).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CompraId).HasColumnName("CompraID");
            entity.Property(e => e.Estado).HasMaxLength(50);
            entity.Property(e => e.FechaUltimaActualizacion).HasColumnType("datetime");
            entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
        });

        modelBuilder.Entity<Inventariosubalmacen>(entity =>
        {
            entity.ToTable("INVENTARIOSUBALMACEN");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CantidadTotal).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CompraId).HasColumnName("Compra_ID");
            entity.Property(e => e.FechaUltimaActualizacion).HasColumnType("datetime");
            entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProductoId).HasColumnName("Producto_ID");
            entity.Property(e => e.SubAlmacenId).HasColumnName("SubAlmacen_ID");
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
        });

        modelBuilder.Entity<Key>(entity =>
        {
            entity.Property(e => e.Algorithm).HasMaxLength(100);
            entity.Property(e => e.IsX509certificate).HasColumnName("IsX509Certificate");
            entity.Property(e => e.Use).HasMaxLength(450);
        });

        modelBuilder.Entity<Localidad>(entity =>
        {
            entity.ToTable("LOCALIDAD");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Codigopostal).HasColumnName("CODIGOPOSTAL");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.ProvinciaId).HasColumnName("PROVINCIA_ID");
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MARCA__3214EC2740D11DAC");

            entity.ToTable("MARCA");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.NombreMarca).HasMaxLength(50);
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
        });

        modelBuilder.Entity<Modelo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MODELO__3214EC278387B6DD");

            entity.ToTable("MODELO");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.MarcaId).HasColumnName("Marca_ID");
            entity.Property(e => e.NombreModelo).HasMaxLength(50);
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
        });

        modelBuilder.Entity<Monedum>(entity =>
        {
            entity.ToTable("MONEDA");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Moneda)
                .HasMaxLength(50)
                .HasColumnName("MONEDA");
            entity.Property(e => e.Simbolo)
                .HasMaxLength(5)
                .HasColumnName("SIMBOLO");
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
        });

        modelBuilder.Entity<Movimientoalmacengeneral>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MOVIMIEN__BF923FCC40762C00");

            entity.ToTable("MOVIMIENTOALMACENGENERAL");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AlmacenId).HasColumnName("AlmacenID");
            entity.Property(e => e.EmpleadoId).HasColumnName("EmpleadoID");
            entity.Property(e => e.Estado).HasMaxLength(50);
            entity.Property(e => e.FechaMovimiento).HasColumnType("datetime");
            entity.Property(e => e.NumOperacion).HasColumnName("Num_Operacion");
            entity.Property(e => e.SubAlmacenDestinoId).HasColumnName("SubAlmacenDestinoID");
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
            entity.Property(e => e.TipoMovimientoId).HasColumnName("TipoMovimientoID");
        });

        modelBuilder.Entity<Movimientoscaja>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MOVIMIEN__3214EC2754C6B488");

            entity.ToTable("MOVIMIENTOSCAJA");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CajaId).HasColumnName("Caja_ID");
            entity.Property(e => e.EntidadImpuestosId).HasColumnName("EntidadImpuestos_ID");
            entity.Property(e => e.FechaMovimiento).HasColumnType("datetime");
            entity.Property(e => e.Monto).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProveedoresId).HasColumnName("Proveedores_ID");
            entity.Property(e => e.RemuneracionId).HasColumnName("Remuneracion_ID");
            entity.Property(e => e.TenantId).HasColumnName("Tenant_ID");
            entity.Property(e => e.TipoMovimientoId).HasColumnName("TipoMovimiento_ID");
        });

        modelBuilder.Entity<Movimientosubalmacen>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MOVIMIENTOSUBALMACEN");

            entity.ToTable("MOVIMIENTOSUBALMACEN");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AlmacenOrigenId).HasColumnName("AlmacenOrigenID");
            entity.Property(e => e.EmpleadoId).HasColumnName("EmpleadoID");
            entity.Property(e => e.Estado).HasMaxLength(50);
            entity.Property(e => e.FechaMovimiento).HasColumnType("datetime");
            entity.Property(e => e.SubAlmacenId).HasColumnName("SubAlmacenID");
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
            entity.Property(e => e.TipoMovimientoId).HasColumnName("TipoMovimientoID");
        });

        modelBuilder.Entity<Obrasocial>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OBRASOCI__3214EC27ECE4617C");

            entity.ToTable("OBRASOCIAL");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Cobertura).HasMaxLength(100);
            entity.Property(e => e.ContactoEmail).HasMaxLength(100);
            entity.Property(e => e.ContactoNombre).HasMaxLength(50);
            entity.Property(e => e.ContactoTelefono).HasMaxLength(20);
            entity.Property(e => e.Direccion).HasMaxLength(100);
            entity.Property(e => e.NombreObraSocial).HasMaxLength(50);
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
            entity.Property(e => e.TipoPlan).HasMaxLength(50);
        });

        modelBuilder.Entity<Ocupacionprofesion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_OCUPACION PROFESION");

            entity.ToTable("OCUPACIONPROFESION");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.OcupacionProfesion1)
                .HasMaxLength(50)
                .HasColumnName("OCUPACION_PROFESION");
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
        });

        modelBuilder.Entity<Ont>(entity =>
        {
            entity.HasKey(e => e.IdOnt).HasName("PK__ONTs__2A0AA6B1D897B933");

            entity.ToTable("ONTs");

            entity.Property(e => e.IdOnt).HasColumnName("IdONT");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValueSql("('ACTIVA')");
            entity.Property(e => e.Modelo).HasMaxLength(50);
            entity.Property(e => e.SerialNumber).HasMaxLength(50);

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Onts)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__ONTs__IdCliente__2EE5E349");
        });

        modelBuilder.Entity<OrdenesServicio>(entity =>
        {
            entity.HasKey(e => e.IdOrden).HasName("PK__OrdenesS__C38F300DB3E52C6D");

            entity.ToTable("OrdenesServicio");

            entity.Property(e => e.Descripcion).HasMaxLength(250);
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValueSql("('PENDIENTE')");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.OrdenesServicios)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrdenesSe__IdCli__2FDA0782");
        });

        modelBuilder.Entity<Pagosanuladosremun>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PAGOSANULADOSREMUN");

            entity.ToTable("PAGOSANULADOSREMUN");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AutorizaUsuId).HasColumnName("AutorizaUsu_ID");
            entity.Property(e => e.CajaId).HasColumnName("Caja_ID");
            entity.Property(e => e.FechaAnulado).HasColumnType("datetime");
            entity.Property(e => e.Monto).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PagoRemunId).HasColumnName("PagoRemun_ID");
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
            entity.Property(e => e.TipoAnuladoId).HasColumnName("TipoAnulado_ID");
            entity.Property(e => e.UsuarioId).HasColumnName("Usuario_ID");
        });

        modelBuilder.Entity<Pagoscredito>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PAGOSCRE__3214EC27B07199D4");

            entity.ToTable("PAGOSCREDITOS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CajaId).HasColumnName("Caja_ID");
            entity.Property(e => e.CreditoId).HasColumnName("Credito_ID");
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.EstadoCuotaId).HasColumnName("EstadoCuota_ID");
            entity.Property(e => e.FechaPago).HasColumnType("date");
            entity.Property(e => e.FormaPagoId).HasColumnName("FormaPago_ID");
            entity.Property(e => e.MontoPagado).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Pagosimpuesto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PAGOSIMP__3214EC275AD3C2BF");

            entity.ToTable("PAGOSIMPUESTOS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CompraId).HasColumnName("Compra_ID");
            entity.Property(e => e.DetallePago).HasColumnType("text");
            entity.Property(e => e.EstadoPago)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.FechaPago).HasColumnType("date");
            entity.Property(e => e.FormaPagoId).HasColumnName("FormaPago_ID");
            entity.Property(e => e.Monto).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
            entity.Property(e => e.TipoPagoId).HasColumnName("TipoPago_ID");
        });

        modelBuilder.Entity<Pagosproveedore>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PAGOSPRO__3214EC273BDBC9A2");

            entity.ToTable("PAGOSPROVEEDORES");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CompraId).HasColumnName("Compra_ID");
            entity.Property(e => e.DetallePago).HasColumnType("text");
            entity.Property(e => e.EstadoPago)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.FechaPago).HasColumnType("date");
            entity.Property(e => e.FormaPagoId).HasColumnName("FormaPago_ID");
            entity.Property(e => e.Monto).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
            entity.Property(e => e.TipoPagoId).HasColumnName("TipoPago_ID");
        });

        modelBuilder.Entity<Pagosremuneracione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PAGOSREM__3214EC27B219054C");

            entity.ToTable("PAGOSREMUNERACIONES");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CajaId).HasColumnName("Caja_ID");
            entity.Property(e => e.EstadoPagoId).HasColumnName("EstadoPago_ID");
            entity.Property(e => e.FechaPago).HasColumnType("datetime");
            entity.Property(e => e.FormaPagoId).HasColumnName("FormaPago_ID");
            entity.Property(e => e.Monto).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PagoAnuladoId).HasColumnName("PagoAnulado_ID");
            entity.Property(e => e.RemuneracionId).HasColumnName("Remuneracion_ID");
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
            entity.Property(e => e.TipoPagoId).HasColumnName("TipoPago_ID");
            entity.Property(e => e.UsuarioRegistroId)
                .HasMaxLength(450)
                .HasColumnName("UsuarioRegistro_ID");
        });

        modelBuilder.Entity<Paise>(entity =>
        {
            entity.ToTable("PAISES");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Gentilicio)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("GENTILICIO");
            entity.Property(e => e.IsoNac)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("ISO_NAC");
            entity.Property(e => e.Pais)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("PAIS");
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
        });

        modelBuilder.Entity<Parentesco>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Parentesco");

            entity.ToTable("PARENTESCOS");

            entity.Property(e => e.Parentesco1)
                .HasMaxLength(60)
                .HasColumnName("Parentesco");
        });

        modelBuilder.Entity<PersistedGrant>(entity =>
        {
            entity.HasKey(e => e.Key);

            entity.Property(e => e.Key).HasMaxLength(200);
            entity.Property(e => e.ClientId).HasMaxLength(200);
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.SessionId).HasMaxLength(100);
            entity.Property(e => e.SubjectId).HasMaxLength(200);
            entity.Property(e => e.Type).HasMaxLength(50);
        });

        modelBuilder.Entity<Planespagoimpuesto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PLANESPA__3214EC274516E35A");

            entity.ToTable("PLANESPAGOIMPUESTOS");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.DescripcionPlan).HasColumnType("text");
            entity.Property(e => e.ImpuestoId).HasColumnName("ImpuestoID");
            entity.Property(e => e.NombrePlan)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PRODUCTO__3214EC279A65F266");

            entity.ToTable("PRODUCTOS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CategoriaId).HasColumnName("Categoria_ID");
            entity.Property(e => e.Cbarras)
                .HasMaxLength(2)
                .HasColumnName("CBarras");
            entity.Property(e => e.FechaActualizacion).HasColumnType("datetime");
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.MarcaId).HasColumnName("Marca_ID");
            entity.Property(e => e.ModeloId).HasColumnName("Modelo_ID");
            entity.Property(e => e.NombreProducto).HasMaxLength(100);
            entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProveedorPreferidoId).HasColumnName("ProveedorPreferido_ID");
            entity.Property(e => e.SubCategoriaId).HasColumnName("SubCategoria_ID");
            entity.Property(e => e.TasaIva).HasColumnName("TasaIVA");
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
            entity.Property(e => e.UnidadMedidaId).HasColumnName("UnidadMedida_ID");
        });

        modelBuilder.Entity<Proveedore>(entity =>
        {
            entity.ToTable("PROVEEDORES");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CategProveedor).HasColumnName("CATEG_PROVEEDOR");
            entity.Property(e => e.CondPagoId).HasColumnName("COND_PAGO_ID");
            entity.Property(e => e.Direccion).HasColumnName("DIRECCION");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.FechaAlta)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_ALTA");
            entity.Property(e => e.LocalidadId).HasColumnName("LOCALIDAD_ID");
            entity.Property(e => e.NombreContacto)
                .HasMaxLength(100)
                .HasColumnName("NOMBRE_CONTACTO");
            entity.Property(e => e.NombreEmpresa)
                .HasMaxLength(100)
                .HasColumnName("NOMBRE_EMPRESA");
            entity.Property(e => e.NombreFiscal)
                .HasMaxLength(100)
                .HasColumnName("NOMBRE_FISCAL");
            entity.Property(e => e.Num).HasColumnName("NUM");
            entity.Property(e => e.PaisId).HasColumnName("PAIS_ID");
            entity.Property(e => e.ProvinciaId).HasColumnName("PROVINCIA_ID");
            entity.Property(e => e.RegTributario)
                .HasMaxLength(50)
                .HasColumnName("REG_TRIBUTARIO");
            entity.Property(e => e.RegimenImpositivoId).HasColumnName("REGIMEN_IMPOSITIVO_ID");
            entity.Property(e => e.SitioWeb)
                .HasMaxLength(100)
                .HasColumnName("SITIO_WEB");
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
        });

        modelBuilder.Entity<Provincium>(entity =>
        {
            entity.ToTable("PROVINCIA");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Codigo31662)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CODIGO31662");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.PaisId).HasColumnName("PAIS_ID");
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
        });

        modelBuilder.Entity<Puestolaboral>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PUESTOLA__3214EC27F7941EAE");

            entity.ToTable("PUESTOLABORAL");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AreaId).HasColumnName("Area_ID");
            entity.Property(e => e.PuestoLaboral1)
                .HasMaxLength(50)
                .HasColumnName("PuestoLaboral");
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
        });

        modelBuilder.Entity<Recepcionmercaderium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RECEPCIO__3214EC2769BA8700");

            entity.ToTable("RECEPCIONMERCADERIA");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.FechaRecepcion).HasColumnType("date");
            entity.Property(e => e.IdCompra).HasColumnName("ID_Compra");
            entity.Property(e => e.IdEmpleadoRecepcion).HasColumnName("ID_EmpleadoRecepcion");
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
        });

        modelBuilder.Entity<RegimenImpositivo>(entity =>
        {
            entity.ToTable("REGIMEN_IMPOSITIVO");

            entity.Property(e => e.RegimenImpositivo1)
                .HasMaxLength(50)
                .HasColumnName("REGIMEN_IMPOSITIVO");
        });

        modelBuilder.Entity<Remuneracione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__REMUNERA__3214EC2702FE1280");

            entity.ToTable("REMUNERACIONES");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AutorizaUsuId).HasColumnName("AutorizaUsu_ID");
            entity.Property(e => e.CajaAsociadaId).HasColumnName("CajaAsociada_ID");
            entity.Property(e => e.ConceptoRemuneracion).HasMaxLength(100);
            entity.Property(e => e.ContratistaId).HasColumnName("Contratista_ID");
            entity.Property(e => e.CuentaUsuarioId).HasColumnName("CuentaUsuario_ID");
            entity.Property(e => e.EmpleadoId).HasColumnName("Empleado_ID");
            entity.Property(e => e.FechaPago).HasColumnType("datetime");
            entity.Property(e => e.FechaProgramada).HasColumnType("date");
            entity.Property(e => e.Monto).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
            entity.Property(e => e.TipoRemuneracionId).HasColumnName("TipoRemuneracion_ID");
            entity.Property(e => e.UsuarioRegistraId)
                .HasMaxLength(450)
                .HasColumnName("UsuarioRegistra_ID");
        });

        modelBuilder.Entity<Rubro>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Rubro");

            entity.ToTable("RUBRO");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Rubro1)
                .HasMaxLength(50)
                .HasColumnName("Rubro");
            entity.Property(e => e.TenantId).HasColumnName("Tenant_Id");
        });

        modelBuilder.Entity<Saldosporpagar>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SALDOSPO__3214EC2726121FDB");

            entity.ToTable("SALDOSPORPAGAR");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreditoId).HasColumnName("Credito_ID");
            entity.Property(e => e.MontoPendiente).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<SchemaVersion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_SchemaVersions_Id");

            entity.Property(e => e.Applied).HasColumnType("datetime");
            entity.Property(e => e.ScriptName).HasMaxLength(255);
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SERVICIO__3214EC277A5D2ED6");

            entity.ToTable("SERVICIOS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CategoriaServicioId).HasColumnName("CategoriaServicio_ID");
            entity.Property(e => e.FechaFin).HasColumnType("date");
            entity.Property(e => e.FechaInicio).HasColumnType("date");
            entity.Property(e => e.NombreServicio).HasMaxLength(100);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ProveedorPreferidoId).HasColumnName("ProveedorPreferido_ID");
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
        });

        modelBuilder.Entity<Solicitudcompra>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SOLICITU__3214EC27752A63D6");

            entity.ToTable("SOLICITUDCOMPRAS");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.EncargadoComprasId).HasColumnName("EncargadoCompras_ID");
            entity.Property(e => e.EstadoSolicitudId).HasColumnName("EstadoSolicitud_ID");
            entity.Property(e => e.FechaRequerida).HasColumnType("date");
            entity.Property(e => e.FechaSolicitud).HasColumnType("datetime");
            entity.Property(e => e.SolicitanteId)
                .HasMaxLength(450)
                .HasColumnName("Solicitante_ID");
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
        });

        modelBuilder.Entity<Solicitudmateriale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Solicitu__3214EC07E04A0D7C");

            entity.ToTable("SOLICITUDMATERIALES");

            entity.Property(e => e.AlmacenGId).HasColumnName("AlmacenG_Id");
            entity.Property(e => e.EstadoSolicitud)
                .HasMaxLength(50)
                .HasDefaultValueSql("('PENDIENTE')");
            entity.Property(e => e.FechaEntrega).HasColumnType("datetime");
            entity.Property(e => e.FechaRequerida).HasColumnType("datetime");
            entity.Property(e => e.FechaSolicitud)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.SubAlmacenId).HasColumnName("SubAlmacen_Id");
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
        });

        modelBuilder.Entity<Subalmacen>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SubAlmac__3214EC07B9F6C5FC");

            entity.ToTable("SUBALMACEN");

            entity.Property(e => e.AlmacenGId).HasColumnName("AlmacenG_Id");
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.TenantId).HasColumnName("Tenant_Id");
            entity.Property(e => e.TipoSubAlmacen).HasMaxLength(50);
        });

        modelBuilder.Entity<Subcategoriaproducto>(entity =>
        {
            entity.ToTable("SUBCATEGORIAPRODUCTOS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CategoriaId).HasColumnName("Categoria_ID");
            entity.Property(e => e.SubCategoria).HasMaxLength(50);
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
        });

        modelBuilder.Entity<Tasaiva>(entity =>
        {
            entity.ToTable("TASAIVA");

            entity.Property(e => e.TasaIva1)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TasaIVA");
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
        });

        modelBuilder.Entity<Telefono>(entity =>
        {
            entity.ToTable("TELEFONOS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Activo)
                .HasDefaultValueSql("((1))")
                .HasColumnName("ACTIVO");
            entity.Property(e => e.Referencia)
                .HasMaxLength(50)
                .HasColumnName("REFERENCIA");
            entity.Property(e => e.SujetoId).HasColumnName("SUJETO_ID");
            entity.Property(e => e.Tabla)
                .HasMaxLength(100)
                .HasColumnName("TABLA");
            entity.Property(e => e.TelefonoCelular)
                .HasMaxLength(50)
                .HasColumnName("TELEFONO_CELULAR");
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
            entity.Property(e => e.TipoTelefono)
                .HasMaxLength(15)
                .HasColumnName("TIPO_TELEFONO");
            entity.Property(e => e.UsuarioId)
                .HasMaxLength(450)
                .HasColumnName("USUARIO_ID");
        });

        modelBuilder.Entity<Tenant>(entity =>
        {
            entity.ToTable("TENANTS");

            entity.Property(e => e.ContactoId).HasColumnName("Contacto_Id");
            entity.Property(e => e.DireccionTenant)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("Direccion_Tenant");
            entity.Property(e => e.EmailTenant)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("Email_Tenant");
            entity.Property(e => e.EspacioAlmacenamiento).HasColumnName("Espacio_Almacenamiento");
            entity.Property(e => e.Facebook)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Creacion");
            entity.Property(e => e.FechaExpiracion)
                .HasColumnType("date")
                .HasColumnName("Fecha_Expiracion");
            entity.Property(e => e.FechaInicio)
                .HasColumnType("date")
                .HasColumnName("Fecha_Inicio");
            entity.Property(e => e.Instagram)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.LimiteUsuarios).HasColumnName("Limite_Usuarios");
            entity.Property(e => e.LocalidadId).HasColumnName("Localidad_Id");
            entity.Property(e => e.LogoTenant).HasColumnName("Logo_Tenant");
            entity.Property(e => e.NombreTenant)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Nombre_Tenant");
            entity.Property(e => e.Observaciones).HasColumnType("text");
            entity.Property(e => e.PaisId).HasColumnName("Pais_Id");
            entity.Property(e => e.PlanSuscripcion).HasColumnName("Plan_Suscripcion");
            entity.Property(e => e.ProvinciaId).HasColumnName("Provincia_Id");
            entity.Property(e => e.RegistroTributario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Registro_Tributario");
            entity.Property(e => e.Rubro)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.SitoWebTenant)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("SitoWeb_Tenant");
            entity.Property(e => e.Telefono)
                .HasMaxLength(30)
                .HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<TipoAsignacion>(entity =>
        {
            entity.ToTable("TIPO_ASIGNACION");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DetalleAsignacion).HasMaxLength(50);
        });

        modelBuilder.Entity<TipoCaja>(entity =>
        {
            entity.ToTable("TIPO_CAJA");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Descripcion).HasColumnName("DESCRIPCION");
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
            entity.Property(e => e.TipoCaja1)
                .HasMaxLength(50)
                .HasColumnName("TIPO_CAJA");
        });

        modelBuilder.Entity<TipoDocumento>(entity =>
        {
            entity.ToTable("TIPO_DOCUMENTO");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
            entity.Property(e => e.Tipodocumento1)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("TIPODOCUMENTO");
        });

        modelBuilder.Entity<TipoTransaccion>(entity =>
        {
            entity.ToTable("TIPO_TRANSACCION");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
            entity.Property(e => e.TipoTransaccion1)
                .HasMaxLength(50)
                .HasColumnName("TIPO_TRANSACCION");
        });

        modelBuilder.Entity<Tipoanulado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TIPOANUL__3214EC27B0D32FE4");

            entity.ToTable("TIPOANULADO");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DetalleTipoAnulado).HasMaxLength(50);
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
        });

        modelBuilder.Entity<Tipocuentum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TIPOCUEN__3214EC27AC711D62");

            entity.ToTable("TIPOCUENTA");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
            entity.Property(e => e.TipoCuenta).HasMaxLength(50);
        });

        modelBuilder.Entity<Tipoimpuesto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TIPOIMPU__3214EC274BE0D0A5");

            entity.ToTable("TIPOIMPUESTO");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DetalleImpuesto).HasMaxLength(50);
            entity.Property(e => e.TasaImpuesto).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
        });

        modelBuilder.Entity<Tipopago>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TIPOPAGO__3214EC2797E3B3C4");

            entity.ToTable("TIPOPAGO");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DetalleTipoPago).HasMaxLength(50);
            entity.Property(e => e.Grupo).HasMaxLength(20);
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
        });

        modelBuilder.Entity<Tipoproducto>(entity =>
        {
            entity.ToTable("TIPOPRODUCTO");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
            entity.Property(e => e.TipoProducto1)
                .HasMaxLength(50)
                .HasColumnName("Tipo_Producto");
        });

        modelBuilder.Entity<Tiporemuneracion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TIPOREMU__3214EC278AF3194B");

            entity.ToTable("TIPOREMUNERACION");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DetalleRemuneracion).HasMaxLength(50);
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
        });

        modelBuilder.Entity<Tiposmovimiento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TIPOSMOV__3214EC2760727095");

            entity.ToTable("TIPOSMOVIMIENTOS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
            entity.Property(e => e.TipoMovimiento).HasMaxLength(50);
        });

        modelBuilder.Entity<Tiposolicitudcompra>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TIPOSOLI__3214EC27965C330B");

            entity.ToTable("TIPOSOLICITUDCOMPRA");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
            entity.Property(e => e.TipoSolicictud).HasMaxLength(50);
        });

        modelBuilder.Entity<Tipotrabajo>(entity =>
        {
            entity.ToTable("TIPOTRABAJO");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Detalletrabajo)
                .HasMaxLength(25)
                .HasColumnName("DETALLETRABAJO");
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
        });

        modelBuilder.Entity<TransaccionProveedor>(entity =>
        {
            entity.ToTable("TRANSACCION_PROVEEDOR");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CajaId).HasColumnName("CAJA_ID");
            entity.Property(e => e.Descripcion).HasColumnName("DESCRIPCION");
            entity.Property(e => e.FacturacompraId).HasColumnName("FACTURACOMPRA_ID");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("FECHA");
            entity.Property(e => e.FormapagoId).HasColumnName("FORMAPAGO_ID");
            entity.Property(e => e.MonedaId).HasColumnName("MONEDA_ID");
            entity.Property(e => e.Monto)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("MONTO");
            entity.Property(e => e.NumRecibo).HasColumnName("NUM_RECIBO");
            entity.Property(e => e.ProductoId).HasColumnName("PRODUCTO_ID");
            entity.Property(e => e.ProveedorId).HasColumnName("PROVEEDOR_ID");
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
            entity.Property(e => e.TipoTransaccion).HasColumnName("TIPO_TRANSACCION");
            entity.Property(e => e.UsuarioId).HasColumnName("USUARIO_ID");
        });

        modelBuilder.Entity<Transaccionesinventario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TRANSACC__3214EC27D553AC86");

            entity.ToTable("TRANSACCIONESINVENTARIO");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.FechaHoraTransaccion).HasColumnType("datetime");
            entity.Property(e => e.IdProducto).HasColumnName("ID_Producto");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
            entity.Property(e => e.TipoTransaccion)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Ubicacioncaja>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UBICACIO__3214EC277A61A79E");

            entity.ToTable("UBICACIONCAJA");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
            entity.Property(e => e.Ubicacion)
                .HasMaxLength(50)
                .HasColumnName("UBICACION");
        });

        modelBuilder.Entity<Unidadmedidum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UnidadMe__3214EC27464D0009");

            entity.ToTable("UNIDADMEDIDA");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Abreviatura).HasMaxLength(10);
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
            entity.Property(e => e.Unidad).HasMaxLength(50);
        });

        modelBuilder.Entity<Vencimientoscredito>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__VENCIMIE__3214EC278E34EBB0");

            entity.ToTable("VENCIMIENTOSCREDITOS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreditoId).HasColumnName("Credito_ID");
            entity.Property(e => e.EstadoVencimiento).HasMaxLength(20);
            entity.Property(e => e.FechaVencimiento).HasColumnType("date");
            entity.Property(e => e.MontoVencimiento).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TenantId).HasColumnName("TENANT_ID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
