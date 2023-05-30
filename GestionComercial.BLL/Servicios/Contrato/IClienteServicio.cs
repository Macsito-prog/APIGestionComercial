using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionComercial.DTO;

namespace GestionComercial.BLL.Servicios.Contrato
{
    public interface IClienteServicio
    {
        Task<List<ClienteDTO>> Lista();

        Task<ClienteDTO> Crear(ClienteDTO modelo);

        Task<bool> Editar(ClienteDTO modelo);

        Task<bool> Eliminar(int IdCliente);
    }
}
