using System;
using System.Collections.Generic;

namespace appCPC.DataAcces.Models;

public partial class CpcOrdenCompra
{
    public decimal OrdOrdenCompraId { get; set; }

    public decimal CliClienteId { get; set; }

    public decimal ProProductoId { get; set; }

    public DateTime? OrdFechaOrden { get; set; }

    public decimal OrdCantidad { get; set; }

    public string OrdProductoDetallado { get; set; } = null!;

    public decimal? OrdMontoTotal { get; set; }

    public decimal OrdIva { get; set; }

    public string? OrdCuentaMayor { get; set; }

    public decimal OrdPlazoDePago { get; set; }

    public virtual CpcCliente CliCliente { get; set; } = null!;

    public virtual ICollection<CpcDetalle> CpcDetalles { get; set; } = new List<CpcDetalle>();

    public virtual CpcProducto ProProducto { get; set; } = null!;
}
