using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionComercial.DTO
{
    public class ClienteDTO
    {
        public int IdCliente { get; set; } //es la id pero en la vista será el RUT

        public string? NombreCliente { get; set; }

        public DateTime? fechaRegistroCliente { get; set; }

        public DateTime? FechaPagoCliente { get; set; }

    
    }
}
