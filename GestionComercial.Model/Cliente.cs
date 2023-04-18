using System;
using System.Collections.Generic;

namespace GestionComercial.Model;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string? NombreCliente { get; set; }

    public DateTime? FechaRegistroCliente { get; set; }

    public DateTime? FechaPagoCliente { get; set; }

    public virtual ICollection<DetalleVenta> DetalleVenta { get; } = new List<DetalleVenta>();
}
