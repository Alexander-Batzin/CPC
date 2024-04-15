using System;
using System.Collections.Generic;

namespace appCPC.DataAcces.Models;

public partial class CpcDetallePago
{
    public decimal DtpDetallePagoId { get; set; }

    public decimal PagRegistroPagoId { get; set; }

    public DateTime DtpFecha { get; set; }

    public string DtpMoneda { get; set; } = null!;

    public virtual CpcRegistroPago PagRegistroPago { get; set; } = null!;
}
