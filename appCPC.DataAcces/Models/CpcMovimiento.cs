using System;
using System.Collections.Generic;

namespace appCPC.DataAcces.Models;

public partial class CpcMovimiento
{
    public decimal MovMovimientoId { get; set; }

    public decimal? NotNotaDebitoId { get; set; }

    public decimal? NocNotaCreditoId { get; set; }

    public DateTime? MovFecha { get; set; }

    public string? MovComentario { get; set; }

    public virtual ICollection<CpcRegistroPago> CpcRegistroPagos { get; set; } = new List<CpcRegistroPago>();

    public virtual CpcNotaCredito? NocNotaCredito { get; set; }

    public virtual CpcNotaDebito? NotNotaDebito { get; set; }
}
