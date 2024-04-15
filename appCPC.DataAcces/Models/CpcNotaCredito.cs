using System;
using System.Collections.Generic;

namespace appCPC.DataAcces.Models;

public partial class CpcNotaCredito
{
    public decimal NocNotaCreditoId { get; set; }

    public decimal NocMontoDescuento { get; set; }

    public DateTime NocFechaEmision { get; set; }

    public string? NocDescripcion { get; set; }

    public virtual ICollection<CpcMovimiento> CpcMovimientos { get; set; } = new List<CpcMovimiento>();
}
