using System;
using System.Collections.Generic;

namespace appCPC.DataAcces.Models;

public partial class CpcEmpleado
{
    public decimal EmpEmpleadoId { get; set; }

    public string EmpPrimerNombre { get; set; } = null!;

    public string EmpSegundoNombre { get; set; } = null!;

    public string EmpPrimerApellido { get; set; } = null!;

    public string EmpSegundoApellido { get; set; } = null!;

    public string EmpPuesto { get; set; } = null!;

    public decimal EmpTelefono { get; set; }

    public decimal? EmpCui { get; set; }

    public string? EmpPasaporte { get; set; }

    public string EmpJefeInmediato { get; set; } = null!;

    public string EmpEmail { get; set; } = null!;

    public string EmpDireccion { get; set; } = null!;

    public string EmpUsuario { get; set; } = null!;

    public string EmpPassword { get; set; } = null!;

    public virtual ICollection<CpcFactura> CpcFacturas { get; set; } = new List<CpcFactura>();
}
