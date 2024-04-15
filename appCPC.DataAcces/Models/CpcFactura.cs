using System;
using System.Collections.Generic;

namespace appCPC.DataAcces.Models;

public partial class CpcFactura
{
    public decimal FacFacturaId { get; set; }

    public decimal CliClienteId { get; set; }

    public decimal EmpEmpleadoId { get; set; }

    public DateTime? FacFechaEmision { get; set; }

    public DateTime FacFechaVencimiento { get; set; }

    public decimal FacCantidad { get; set; }

    public string FacDescripcion { get; set; } = null!;

    public decimal FacPrecioUnitario { get; set; }

    public decimal FacPrecioTotal { get; set; }

    public decimal FacIva { get; set; }

    public decimal FacSubtotal { get; set; }

    public decimal FacMontoTotal { get; set; }

    public string FacMoneda { get; set; } = null!;

    public string FacFelNumeroAutorizacion { get; set; } = null!;

    public string FacFelSerie { get; set; } = null!;

    public string FacFelNoDte { get; set; } = null!;

    public decimal FacPlazoDePago { get; set; }

    public virtual CpcCliente CliCliente { get; set; } = null!;

    public virtual ICollection<CpcCancelacionTotal> CpcCancelacionTotals { get; set; } = new List<CpcCancelacionTotal>();

    public virtual ICollection<CpcDetalle> CpcDetalles { get; set; } = new List<CpcDetalle>();

    public virtual ICollection<CpcRegistroPago> CpcRegistroPagos { get; set; } = new List<CpcRegistroPago>();

    public virtual CpcEmpleado EmpEmpleado { get; set; } = null!;
}
