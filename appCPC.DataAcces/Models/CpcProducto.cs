using System;
using System.Collections.Generic;

namespace appCPC.DataAcces.Models;

public partial class CpcProducto
{
    public decimal ProProductoId { get; set; }

    public string ProNombreProducto { get; set; } = null!;

    public string ProDescripcion { get; set; } = null!;

    public decimal ProStock { get; set; }

    public string? ProEstadoProducto { get; set; }

    public decimal ProPrecioSinIva { get; set; }

    public virtual ICollection<CpcOrdenCompra> CpcOrdenCompras { get; set; } = new List<CpcOrdenCompra>();
}
