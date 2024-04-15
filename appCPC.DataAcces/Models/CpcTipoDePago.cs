using System;
using System.Collections.Generic;

namespace appCPC.DataAcces.Models;

public partial class CpcTipoDePago
{
    public decimal TdpTipoDePagoId { get; set; }

    public decimal? CheChequeId { get; set; }

    public decimal? TraTransferenciaId { get; set; }

    public decimal? TdpFechaRegistro { get; set; }

    public string? TdpComentario { get; set; }

    public virtual CpcCheque? CheCheque { get; set; }

    public virtual ICollection<CpcRegistroPago> CpcRegistroPagos { get; set; } = new List<CpcRegistroPago>();

    public virtual CpcTransferencium? TraTransferencia { get; set; }
}
