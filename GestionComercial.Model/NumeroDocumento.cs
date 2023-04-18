using System;
using System.Collections.Generic;

namespace GestionComercial.Model;

public partial class NumeroDocumento
{
    public int IdNumeroDocumento { get; set; }

    public int UltimoNumero { get; set; }

    public DateTime? FechaRegistroDocumento { get; set; }
}
