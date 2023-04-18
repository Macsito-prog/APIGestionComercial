using System;
using System.Collections.Generic;

namespace GestionComercial.Model;

public partial class Categoria
{
    public int IdCategoria { get; set; }

    public string? NombreCategoria { get; set; }

    public bool? EsActivaCategoria { get; set; }

    public DateTime? FechaRegistroCategoria { get; set; }

    public virtual ICollection<Producto> Productos { get; } = new List<Producto>();
}
