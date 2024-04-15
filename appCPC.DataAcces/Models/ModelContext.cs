using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace appCPC.DataAcces.Models;

public partial class ModelContext : DbContext
{
    public ModelContext()
    {
    }

    public ModelContext(DbContextOptions<ModelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CpcCancelacionTotal> CpcCancelacionTotals { get; set; }

    public virtual DbSet<CpcCheque> CpcCheques { get; set; }

    public virtual DbSet<CpcCliente> CpcClientes { get; set; }

    public virtual DbSet<CpcDetalle> CpcDetalles { get; set; }

    public virtual DbSet<CpcDetallePago> CpcDetallePagos { get; set; }

    public virtual DbSet<CpcEmpleado> CpcEmpleados { get; set; }

    public virtual DbSet<CpcFactura> CpcFacturas { get; set; }

    public virtual DbSet<CpcMovimiento> CpcMovimientos { get; set; }

    public virtual DbSet<CpcNotaCredito> CpcNotaCreditos { get; set; }

    public virtual DbSet<CpcNotaDebito> CpcNotaDebitos { get; set; }

    public virtual DbSet<CpcOrdenCompra> CpcOrdenCompras { get; set; }

    public virtual DbSet<CpcProducto> CpcProductos { get; set; }

    public virtual DbSet<CpcRegistroPago> CpcRegistroPagos { get; set; }

    public virtual DbSet<CpcTipoDePago> CpcTipoDePagos { get; set; }

    public virtual DbSet<CpcTransferencium> CpcTransferencia { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
  //      => optionsBuilder.UseOracle("User Id=BDCPC;password=cpc1234_;Data Source=localhost:1521/xe;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("BDCPC")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<CpcCancelacionTotal>(entity =>
        {
            entity.HasKey(e => e.CntCancelacionTotalId).HasName("SYS_C008858");

            entity.ToTable("CPC_CANCELACION_TOTAL");

            entity.Property(e => e.CntCancelacionTotalId)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("CNT_CANCELACION_TOTAL_ID");
            entity.Property(e => e.CliClienteId)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("CLI_CLIENTE_ID");
            entity.Property(e => e.CntDescuento)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("CNT_DESCUENTO");
            entity.Property(e => e.CntFechaCancelacion)
                .HasColumnType("DATE")
                .HasColumnName("CNT_FECHA_CANCELACION");
            entity.Property(e => e.CntMontoTotalPagado)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("CNT_MONTO_TOTAL_PAGADO");
            entity.Property(e => e.FacFacturaId)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("FAC_FACTURA_ID");

            entity.HasOne(d => d.CliCliente).WithMany(p => p.CpcCancelacionTotals)
                .HasForeignKey(d => d.CliClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CLI_CLIENTE_ID_CAN");

            entity.HasOne(d => d.FacFactura).WithMany(p => p.CpcCancelacionTotals)
                .HasForeignKey(d => d.FacFacturaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FAC_FACTURA_ID_CAN");
        });

        modelBuilder.Entity<CpcCheque>(entity =>
        {
            entity.HasKey(e => e.CheChequeId).HasName("SYS_C008815");

            entity.ToTable("CPC_CHEQUE");

            entity.Property(e => e.CheChequeId)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("CHE_CHEQUE_ID");
            entity.Property(e => e.CheBancoEmisor)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CHE_BANCO_EMISOR");
            entity.Property(e => e.CheEstado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CHE_ESTADO");
            entity.Property(e => e.CheFechaEmision)
                .HasColumnType("DATE")
                .HasColumnName("CHE_FECHA_EMISION");
            entity.Property(e => e.CheMonto)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("CHE_MONTO");
            entity.Property(e => e.CheNombreBeneficiario)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CHE_NOMBRE_BENEFICIARIO");
            entity.Property(e => e.CheNumeroCheque)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("CHE_NUMERO_CHEQUE");
            entity.Property(e => e.CheNumeroDeCuenta)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("CHE_NUMERO_DE_CUENTA");
        });

        modelBuilder.Entity<CpcCliente>(entity =>
        {
            entity.HasKey(e => e.CliClienteId).HasName("SYS_C008772");

            entity.ToTable("CPC_CLIENTE");

            entity.Property(e => e.CliClienteId)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("CLI_CLIENTE_ID");
            entity.Property(e => e.CliCui)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("CLI_CUI");
            entity.Property(e => e.CliDireccion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CLI_DIRECCION");
            entity.Property(e => e.CliEmail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CLI_EMAIL");
            entity.Property(e => e.CliNit)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("CLI_NIT");
            entity.Property(e => e.CliPasaporte)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("CLI_PASAPORTE");
            entity.Property(e => e.CliPrimerApellido)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("CLI_PRIMER_APELLIDO");
            entity.Property(e => e.CliPrimerNombre)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("CLI_PRIMER_NOMBRE");
            entity.Property(e => e.CliSegundoApellido)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("CLI_SEGUNDO_APELLIDO");
            entity.Property(e => e.CliSegundoNombre)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("CLI_SEGUNDO_NOMBRE");
            entity.Property(e => e.CliTelefono)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("CLI_TELEFONO");
        });

        modelBuilder.Entity<CpcDetalle>(entity =>
        {
            entity.HasKey(e => e.DteDetalleId).HasName("SYS_C008867");

            entity.ToTable("CPC_DETALLE");

            entity.Property(e => e.DteDetalleId)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("DTE_DETALLE_ID");
            entity.Property(e => e.CliClienteId)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("CLI_CLIENTE_ID");
            entity.Property(e => e.DteAbono)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("DTE_ABONO");
            entity.Property(e => e.DteComentario)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DTE_COMENTARIO");
            entity.Property(e => e.DteEstadoPago)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DTE_ESTADO_PAGO");
            entity.Property(e => e.DteFechaRegistro)
                .HasColumnType("DATE")
                .HasColumnName("DTE_FECHA_REGISTRO");
            entity.Property(e => e.DteInteres)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("DTE_INTERES");
            entity.Property(e => e.DteMontoInicial)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("DTE_MONTO_INICIAL");
            entity.Property(e => e.DteMontoPagado)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("DTE_MONTO_PAGADO");
            entity.Property(e => e.DteMora)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("DTE_MORA");
            entity.Property(e => e.DteSaldoActual)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("DTE_SALDO_ACTUAL");
            entity.Property(e => e.DteSaldoAnterior)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("DTE_SALDO_ANTERIOR");
            entity.Property(e => e.DteTotalPago)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("DTE_TOTAL_PAGO");
            entity.Property(e => e.EmpEmpleadoId)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("EMP_EMPLEADO_ID");
            entity.Property(e => e.FacFacturaId)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("FAC_FACTURA_ID");
            entity.Property(e => e.OrdOrdenCompraId)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ORD_ORDEN_COMPRA_ID");
            entity.Property(e => e.PagRegistroPagoId)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("PAG_REGISTRO_PAGO_ID");

            entity.HasOne(d => d.CliCliente).WithMany(p => p.CpcDetalles)
                .HasForeignKey(d => d.CliClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CLI_CLIENTE_ID_DET");

            entity.HasOne(d => d.EmpEmpleado).WithMany(p => p.CpcDetalleEmpEmpleados)
                .HasForeignKey(d => d.EmpEmpleadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EMP_EMPLEADO_ID_DET");

            entity.HasOne(d => d.FacFactura).WithMany(p => p.CpcDetalles)
                .HasForeignKey(d => d.FacFacturaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FAC_FACTURA_ID_DET");

            entity.HasOne(d => d.OrdOrdenCompra).WithMany(p => p.CpcDetalles)
                .HasForeignKey(d => d.OrdOrdenCompraId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ORD_ORDEN_COMPRA_ID_DET");

            entity.HasOne(d => d.PagRegistroPago).WithMany(p => p.CpcDetallePagRegistroPagos)
                .HasForeignKey(d => d.PagRegistroPagoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PAG_REGISTRO_PAGO_ID_DET");
        });

        modelBuilder.Entity<CpcDetallePago>(entity =>
        {
            entity.HasKey(e => e.DtpDetallePagoId).HasName("SYS_C008852");

            entity.ToTable("CPC_DETALLE_PAGO");

            entity.Property(e => e.DtpDetallePagoId)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("DTP_DETALLE_PAGO_ID");
            entity.Property(e => e.DtpFecha)
                .HasColumnType("DATE")
                .HasColumnName("DTP_FECHA");
            entity.Property(e => e.DtpMoneda)
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasColumnName("DTP_MONEDA");
            entity.Property(e => e.PagRegistroPagoId)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("PAG_REGISTRO_PAGO_ID");

            entity.HasOne(d => d.PagRegistroPago).WithMany(p => p.CpcDetallePagos)
                .HasForeignKey(d => d.PagRegistroPagoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PAG_REGISTRO_PAGO_ID");
        });

        modelBuilder.Entity<CpcEmpleado>(entity =>
        {
            entity.HasKey(e => e.EmpEmpleadoId).HasName("SYS_C008762");

            entity.ToTable("CPC_EMPLEADO");

            entity.Property(e => e.EmpEmpleadoId)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("EMP_EMPLEADO_ID");
            entity.Property(e => e.EmpCui)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("EMP_CUI");
            entity.Property(e => e.EmpDireccion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EMP_DIRECCION");
            entity.Property(e => e.EmpEmail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EMP_EMAIL");
            entity.Property(e => e.EmpJefeInmediato)
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasColumnName("EMP_JEFE_INMEDIATO");
            entity.Property(e => e.EmpPasaporte)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("EMP_PASAPORTE");
            entity.Property(e => e.EmpPassword)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("EMP_PASSWORD");
            entity.Property(e => e.EmpPrimerApellido)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("EMP_PRIMER_APELLIDO");
            entity.Property(e => e.EmpPrimerNombre)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("EMP_PRIMER_NOMBRE");
            entity.Property(e => e.EmpPuesto)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("EMP_PUESTO");
            entity.Property(e => e.EmpSegundoApellido)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("EMP_SEGUNDO_APELLIDO");
            entity.Property(e => e.EmpSegundoNombre)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("EMP_SEGUNDO_NOMBRE");
            entity.Property(e => e.EmpTelefono)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("EMP_TELEFONO");
            entity.Property(e => e.EmpUsuario)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("EMP_USUARIO");
        });

        modelBuilder.Entity<CpcFactura>(entity =>
        {
            entity.HasKey(e => e.FacFacturaId).HasName("SYS_C008805");

            entity.ToTable("CPC_FACTURA");

            entity.Property(e => e.FacFacturaId)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("FAC_FACTURA_ID");
            entity.Property(e => e.CliClienteId)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("CLI_CLIENTE_ID");
            entity.Property(e => e.EmpEmpleadoId)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("EMP_EMPLEADO_ID");
            entity.Property(e => e.FacCantidad)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("FAC_CANTIDAD");
            entity.Property(e => e.FacDescripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("FAC_DESCRIPCION");
            entity.Property(e => e.FacFechaEmision)
                .HasColumnType("DATE")
                .HasColumnName("FAC_FECHA_EMISION");
            entity.Property(e => e.FacFechaVencimiento)
                .HasColumnType("DATE")
                .HasColumnName("FAC_FECHA_VENCIMIENTO");
            entity.Property(e => e.FacFelNoDte)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("FAC_FEL_NO_DTE");
            entity.Property(e => e.FacFelNumeroAutorizacion)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("FAC_FEL_NUMERO_AUTORIZACION");
            entity.Property(e => e.FacFelSerie)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("FAC_FEL_SERIE");
            entity.Property(e => e.FacIva)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("FAC_IVA");
            entity.Property(e => e.FacMoneda)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("FAC_MONEDA");
            entity.Property(e => e.FacMontoTotal)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("FAC_MONTO_TOTAL");
            entity.Property(e => e.FacPlazoDePago)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("FAC_PLAZO_DE_PAGO");
            entity.Property(e => e.FacPrecioTotal)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("FAC_PRECIO_TOTAL");
            entity.Property(e => e.FacPrecioUnitario)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("FAC_PRECIO_UNITARIO");
            entity.Property(e => e.FacSubtotal)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("FAC_SUBTOTAL");

            entity.HasOne(d => d.CliCliente).WithMany(p => p.CpcFacturas)
                .HasForeignKey(d => d.CliClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CLI_CLIENTE_ID_FAC");

            entity.HasOne(d => d.EmpEmpleado).WithMany(p => p.CpcFacturas)
                .HasForeignKey(d => d.EmpEmpleadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EMP_EMPLEADO_ID");
        });

        modelBuilder.Entity<CpcMovimiento>(entity =>
        {
            entity.HasKey(e => e.MovMovimientoId).HasName("SYS_C008838");

            entity.ToTable("CPC_MOVIMIENTO");

            entity.Property(e => e.MovMovimientoId)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("MOV_MOVIMIENTO_ID");
            entity.Property(e => e.MovComentario)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MOV_COMENTARIO");
            entity.Property(e => e.MovFecha)
                .HasColumnType("DATE")
                .HasColumnName("MOV_FECHA");
            entity.Property(e => e.NocNotaCreditoId)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("NOC_NOTA_CREDITO_ID");
            entity.Property(e => e.NotNotaDebitoId)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("NOT_NOTA_DEBITO_ID");

            entity.HasOne(d => d.NocNotaCredito).WithMany(p => p.CpcMovimientos)
                .HasForeignKey(d => d.NocNotaCreditoId)
                .HasConstraintName("FK_NOC_NOTA_CREDITO_ID");

            entity.HasOne(d => d.NotNotaDebito).WithMany(p => p.CpcMovimientos)
                .HasForeignKey(d => d.NotNotaDebitoId)
                .HasConstraintName("FK_NOT_NOTA_DEBITO_ID");
        });

        modelBuilder.Entity<CpcNotaCredito>(entity =>
        {
            entity.HasKey(e => e.NocNotaCreditoId).HasName("SYS_C008832");

            entity.ToTable("CPC_NOTA_CREDITO");

            entity.Property(e => e.NocNotaCreditoId)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("NOC_NOTA_CREDITO_ID");
            entity.Property(e => e.NocDescripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOC_DESCRIPCION");
            entity.Property(e => e.NocFechaEmision)
                .HasColumnType("DATE")
                .HasColumnName("NOC_FECHA_EMISION");
            entity.Property(e => e.NocMontoDescuento)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("NOC_MONTO_DESCUENTO");
        });

        modelBuilder.Entity<CpcNotaDebito>(entity =>
        {
            entity.HasKey(e => e.NotNotaDebitoId).HasName("SYS_C008828");

            entity.ToTable("CPC_NOTA_DEBITO");

            entity.Property(e => e.NotNotaDebitoId)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("NOT_NOTA_DEBITO_ID");
            entity.Property(e => e.NotDescripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOT_DESCRIPCION");
            entity.Property(e => e.NotFechaEmision)
                .HasColumnType("DATE")
                .HasColumnName("NOT_FECHA_EMISION");
            entity.Property(e => e.NotMontoAdicional)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("NOT_MONTO_ADICIONAL");
        });

        modelBuilder.Entity<CpcOrdenCompra>(entity =>
        {
            entity.HasKey(e => e.OrdOrdenCompraId).HasName("SYS_C008786");

            entity.ToTable("CPC_ORDEN_COMPRA");

            entity.Property(e => e.OrdOrdenCompraId)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ORD_ORDEN_COMPRA_ID");
            entity.Property(e => e.CliClienteId)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("CLI_CLIENTE_ID");
            entity.Property(e => e.OrdCantidad)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ORD_CANTIDAD");
            entity.Property(e => e.OrdCuentaMayor)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ORD_CUENTA_MAYOR");
            entity.Property(e => e.OrdFechaOrden)
                .HasColumnType("DATE")
                .HasColumnName("ORD_FECHA_ORDEN");
            entity.Property(e => e.OrdIva)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("ORD_IVA");
            entity.Property(e => e.OrdMontoTotal)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("ORD_MONTO_TOTAL");
            entity.Property(e => e.OrdPlazoDePago)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ORD_PLAZO_DE_PAGO");
            entity.Property(e => e.OrdProductoDetallado)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ORD_PRODUCTO_DETALLADO");
            entity.Property(e => e.ProProductoId)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("PRO_PRODUCTO_ID");

            entity.HasOne(d => d.CliCliente).WithMany(p => p.CpcOrdenCompras)
                .HasForeignKey(d => d.CliClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CLI_CLIENTE_ID");

            entity.HasOne(d => d.ProProducto).WithMany(p => p.CpcOrdenCompras)
                .HasForeignKey(d => d.ProProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PRO_PRODUCTO_ID");
        });

        modelBuilder.Entity<CpcProducto>(entity =>
        {
            entity.HasKey(e => e.ProProductoId).HasName("SYS_C008778");

            entity.ToTable("CPC_PRODUCTO");

            entity.Property(e => e.ProProductoId)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("PRO_PRODUCTO_ID");
            entity.Property(e => e.ProDescripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PRO_DESCRIPCION");
            entity.Property(e => e.ProEstadoProducto)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PRO_ESTADO_PRODUCTO");
            entity.Property(e => e.ProNombreProducto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PRO_NOMBRE_PRODUCTO");
            entity.Property(e => e.ProPrecioSinIva)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("PRO_PRECIO_SIN_IVA");
            entity.Property(e => e.ProStock)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("PRO_STOCK");
        });

        modelBuilder.Entity<CpcRegistroPago>(entity =>
        {
            entity.HasKey(e => e.PagRegistroPagoId).HasName("SYS_C008844");

            entity.ToTable("CPC_REGISTRO_PAGO");

            entity.Property(e => e.PagRegistroPagoId)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("PAG_REGISTRO_PAGO_ID");
            entity.Property(e => e.FacFacturaId)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("FAC_FACTURA_ID");
            entity.Property(e => e.MovMovimientoId)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("MOV_MOVIMIENTO_ID");
            entity.Property(e => e.PagFechaPago)
                .HasColumnType("DATE")
                .HasColumnName("PAG_FECHA_PAGO");
            entity.Property(e => e.PagMontoPagado)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("PAG_MONTO_PAGADO");
            entity.Property(e => e.TdpTipoDePagoId)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("TDP_TIPO_DE_PAGO_ID");

            entity.HasOne(d => d.FacFactura).WithMany(p => p.CpcRegistroPagos)
                .HasForeignKey(d => d.FacFacturaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FAC_FACTURA_ID");

            entity.HasOne(d => d.MovMovimiento).WithMany(p => p.CpcRegistroPagos)
                .HasForeignKey(d => d.MovMovimientoId)
                .HasConstraintName("FK_MOV_MOVIMIENTO_ID");

            entity.HasOne(d => d.TdpTipoDePago).WithMany(p => p.CpcRegistroPagos)
                .HasForeignKey(d => d.TdpTipoDePagoId)
                .HasConstraintName("FK_TDP_TIPO_DE_PAGO_ID");
        });

        modelBuilder.Entity<CpcTipoDePago>(entity =>
        {
            entity.HasKey(e => e.TdpTipoDePagoId).HasName("SYS_C008834");

            entity.ToTable("CPC_TIPO_DE_PAGO");

            entity.Property(e => e.TdpTipoDePagoId)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("TDP_TIPO_DE_PAGO_ID");
            entity.Property(e => e.CheChequeId)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("CHE_CHEQUE_ID");
            entity.Property(e => e.TdpComentario)
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasColumnName("TDP_COMENTARIO");
            entity.Property(e => e.TdpFechaRegistro)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("TDP_FECHA_REGISTRO");
            entity.Property(e => e.TraTransferenciaId)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("TRA_TRANSFERENCIA_ID");

            entity.HasOne(d => d.CheCheque).WithMany(p => p.CpcTipoDePagos)
                .HasForeignKey(d => d.CheChequeId)
                .HasConstraintName("FK_CHE_CHEQUE_ID");

            entity.HasOne(d => d.TraTransferencia).WithMany(p => p.CpcTipoDePagos)
                .HasForeignKey(d => d.TraTransferenciaId)
                .HasConstraintName("FK_TRA_TRANSFERENCIA_ID");
        });

        modelBuilder.Entity<CpcTransferencium>(entity =>
        {
            entity.HasKey(e => e.TraTransferenciaId).HasName("SYS_C008824");

            entity.ToTable("CPC_TRANSFERENCIA");

            entity.Property(e => e.TraTransferenciaId)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("TRA_TRANSFERENCIA_ID");
            entity.Property(e => e.TraBancoEmisor)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TRA_BANCO_EMISOR");
            entity.Property(e => e.TraBancoReceptor)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TRA_BANCO_RECEPTOR");
            entity.Property(e => e.TraCodigoAutorizacion)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("TRA_CODIGO_AUTORIZACION");
            entity.Property(e => e.TraFecha)
                .HasColumnType("DATE")
                .HasColumnName("TRA_FECHA");
            entity.Property(e => e.TraMoneda)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TRA_MONEDA");
            entity.Property(e => e.TraMonto)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("TRA_MONTO");
            entity.Property(e => e.TraNombreBeneficiario)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TRA_NOMBRE_BENEFICIARIO");
        });
        modelBuilder.HasSequence("CPC_CANCELACION_TOTAL_SEQUE");
        modelBuilder.HasSequence("CPC_CHEQUE_SEQUE");
        modelBuilder.HasSequence("CPC_CLIENTE_SEQUE");
        modelBuilder.HasSequence("CPC_DETALLE_PAGO_SEQUE");
        modelBuilder.HasSequence("CPC_DETALLE_SEQUE");
        modelBuilder.HasSequence("CPC_EMPLEADO_SEQUE");
        modelBuilder.HasSequence("CPC_FACTURA_SEQUE");
        modelBuilder.HasSequence("CPC_MOVIMIENTO_SEQUE");
        modelBuilder.HasSequence("CPC_NOTA_CREDITO_SEQUE");
        modelBuilder.HasSequence("CPC_NOTA_DEBITO_SEQUE");
        modelBuilder.HasSequence("CPC_ORDEN_COMPRA_SEQUE");
        modelBuilder.HasSequence("CPC_PRODUCTO_SEQUE");
        modelBuilder.HasSequence("CPC_REGISTRO_PAGO_SEQUE");
        modelBuilder.HasSequence("CPC_TIPO_DE_PAGO_SEQUE");
        modelBuilder.HasSequence("CPC_TRANSFERENCIA_SEQUE");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
