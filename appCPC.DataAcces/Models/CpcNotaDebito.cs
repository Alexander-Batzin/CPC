using System;
using System.Collections.Generic;

namespace appCPC.DataAcces.Models;

public partial class CpcNotaDebito
{
    public decimal NotNotaDebitoId { get; set; }

    public decimal NotMontoAdicional { get; set; }

    public DateTime NotFechaEmision { get; set; }

    public string? NotDescripcion { get; set; }

    public virtual ICollection<CpcMovimiento> CpcMovimientos { get; set; } = new List<CpcMovimiento>();
}
