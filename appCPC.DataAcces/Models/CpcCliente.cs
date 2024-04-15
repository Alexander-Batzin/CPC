using System;
using System.Collections.Generic;

namespace appCPC.DataAcces.Models;

public partial class CpcCliente
{
    public decimal CliClienteId { get; set; }

    public string CliPrimerNombre { get; set; } = null!;

    public string CliSegundoNombre { get; set; } = null!;

    public string CliPrimerApellido { get; set; } = null!;

    public string CliSegundoApellido { get; set; } = null!;

    public decimal? CliCui { get; set; }

    public string? CliPasaporte { get; set; }

    public string CliNit { get; set; } = null!;

    public string CliDireccion { get; set; } = null!;

    public decimal CliTelefono { get; set; }

    public string CliEmail { get; set; } = null!;

    public virtual ICollection<CpcCancelacionTotal> CpcCancelacionTotals { get; set; } = new List<CpcCancelacionTotal>();

    public virtual ICollection<CpcDetalle> CpcDetalles { get; set; } = new List<CpcDetalle>();

    public virtual ICollection<CpcFactura> CpcFacturas { get; set; } = new List<CpcFactura>();

    public virtual ICollection<CpcOrdenCompra> CpcOrdenCompras { get; set; } = new List<CpcOrdenCompra>();
}
