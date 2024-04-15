using System;
using System.Collections.Generic;

namespace appCPC.DataAcces.Models;

public partial class CpcCancelacionTotal
{
    public decimal CntCancelacionTotalId { get; set; }

    public decimal CliClienteId { get; set; }

    public decimal FacFacturaId { get; set; }

    public DateTime? CntFechaCancelacion { get; set; }

    public decimal? CntDescuento { get; set; }

    public decimal CntMontoTotalPagado { get; set; }

    public virtual CpcCliente CliCliente { get; set; } = null!;

    public virtual CpcFactura FacFactura { get; set; } = null!;
}
