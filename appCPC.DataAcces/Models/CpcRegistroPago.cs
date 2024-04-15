using System;
using System.Collections.Generic;

namespace appCPC.DataAcces.Models;

public partial class CpcRegistroPago
{
    public decimal PagRegistroPagoId { get; set; }

    public decimal? TdpTipoDePagoId { get; set; }

    public decimal? MovMovimientoId { get; set; }

    public decimal FacFacturaId { get; set; }

    public DateTime PagFechaPago { get; set; }

    public decimal? PagMontoPagado { get; set; }

    public virtual ICollection<CpcDetalle> CpcDetalleEmpEmpleados { get; set; } = new List<CpcDetalle>();

    public virtual ICollection<CpcDetalle> CpcDetallePagRegistroPagos { get; set; } = new List<CpcDetalle>();

    public virtual ICollection<CpcDetallePago> CpcDetallePagos { get; set; } = new List<CpcDetallePago>();

    public virtual CpcFactura FacFactura { get; set; } = null!;

    public virtual CpcMovimiento? MovMovimiento { get; set; }

    public virtual CpcTipoDePago? TdpTipoDePago { get; set; }
}
