using System;
using System.Collections.Generic;

namespace appCPC.DataAcces.Models;

public partial class CpcDetalle
{
    public decimal DteDetalleId { get; set; }

    public decimal CliClienteId { get; set; }

    public decimal FacFacturaId { get; set; }

    public decimal OrdOrdenCompraId { get; set; }

    public decimal PagRegistroPagoId { get; set; }

    public decimal EmpEmpleadoId { get; set; }

    public decimal? DteMontoInicial { get; set; }

    public decimal? DteMontoPagado { get; set; }

    public decimal? DteAbono { get; set; }

    public decimal? DteSaldoAnterior { get; set; }

    public decimal? DteSaldoActual { get; set; }

    public decimal? DteMora { get; set; }

    public decimal? DteTotalPago { get; set; }

    public string? DteEstadoPago { get; set; }

    public decimal? DteInteres { get; set; }

    public DateTime? DteFechaRegistro { get; set; }

    public string? DteComentario { get; set; }

    public virtual CpcCliente CliCliente { get; set; } = null!;

    public virtual CpcRegistroPago EmpEmpleado { get; set; } = null!;

    public virtual CpcFactura FacFactura { get; set; } = null!;

    public virtual CpcOrdenCompra OrdOrdenCompra { get; set; } = null!;

    public virtual CpcRegistroPago PagRegistroPago { get; set; } = null!;
}
