using System;
using System.Collections.Generic;

namespace appCPC.DataAcces.Models;

public partial class CpcCheque
{
    public decimal CheChequeId { get; set; }

    public decimal CheNumeroCheque { get; set; }

    public decimal CheMonto { get; set; }

    public DateTime CheFechaEmision { get; set; }

    public string CheNombreBeneficiario { get; set; } = null!;

    public string CheBancoEmisor { get; set; } = null!;

    public decimal CheNumeroDeCuenta { get; set; }

    public string? CheEstado { get; set; }

    public virtual ICollection<CpcTipoDePago> CpcTipoDePagos { get; set; } = new List<CpcTipoDePago>();
}
