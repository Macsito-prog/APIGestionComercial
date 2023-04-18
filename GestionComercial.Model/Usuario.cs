using System;
using System.Collections.Generic;

namespace GestionComercial.Model;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? NombreCompleto { get; set; }

    public string? Correo { get; set; }

    public int? IdRol { get; set; }

    public string? Clave { get; set; }

    public bool? EsActivo { get; set; }

    public DateTime? FechaRegistroUsuario { get; set; }

    public virtual Rol? IdRolNavigation { get; set; }
}
