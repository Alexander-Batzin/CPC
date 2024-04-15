using System;
using System.Collections.Generic;

namespace appCPC.DataAcces.Models;

public partial class CpcTransferencium
{
    public decimal TraTransferenciaId { get; set; }

    public decimal TraCodigoAutorizacion { get; set; }

    public string TraNombreBeneficiario { get; set; } = null!;

    public string TraBancoEmisor { get; set; } = null!;

    public string TraBancoReceptor { get; set; } = null!;

    public DateTime TraFecha { get; set; }

    public decimal TraMonto { get; set; }

    public string TraMoneda { get; set; } = null!;

    public virtual ICollection<CpcTipoDePago> CpcTipoDePagos { get; set; } = new List<CpcTipoDePago>();
}
