using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using GestionComercial.BLL.Servicios.Contrato;
using GestionComercial.DAL.Repositorios.Contrato;
using GestionComercial.DTO;
using GestionComercial.Model;
using Microsoft.EntityFrameworkCore;

namespace GestionComercial.BLL.Servicios
{
    public class ClienteService : IClienteServicio
    {

        private readonly IGenericRepository<Cliente> _clienteRepositorio;
        private readonly IMapper _mapper;

        public ClienteService(IGenericRepository<Cliente> clienteRepositorio, IMapper mapper)
        {
            _clienteRepositorio = clienteRepositorio;
            _mapper = mapper;
        }
        public async Task<ClienteDTO> Crear(ClienteDTO modelo)
        {
            try
            {


                var clienteCreado = await _clienteRepositorio.Crear(_mapper.Map<Cliente>(modelo));
                if (clienteCreado.IdCliente == 0)
                {
                    throw new TaskCanceledException("No se pudo crear el cliente");
                }
                return _mapper.Map<ClienteDTO>(clienteCreado);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(ClienteDTO modelo)
        {
            try
            {
                var clienteModelo = _mapper.Map<Cliente>(modelo);
                var clienteEncontrado = await _clienteRepositorio.Obtener(u =>
                u.IdCliente == clienteModelo.IdCliente);

                if( clienteEncontrado == null)
                
                    throw new TaskCanceledException("El cliente no está registrado");

                clienteEncontrado.NombreCliente = clienteModelo.NombreCliente;
                clienteEncontrado.FechaRegistroCliente = clienteModelo.FechaRegistroCliente;
                clienteEncontrado.FechaPagoCliente = clienteModelo.FechaPagoCliente;

                bool respuesta = await _clienteRepositorio.Editar(clienteEncontrado);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo editar el cliente...");
                return respuesta;
            }
            catch 
            {
                throw;
            }

        }

        public async Task<bool> Eliminar(int IdCliente)
        {
            try { 
            var clienteEncontrado = await _clienteRepositorio.Obtener(p=>p.IdCliente==IdCliente);

                if (clienteEncontrado == null)
                    throw new TaskCanceledException("El Cliente no existe");
                bool respuesta = await _clienteRepositorio.Delete(clienteEncontrado);

                if (!respuesta) throw new TaskCanceledException("No se pudo eliminar");
                return respuesta;
            }
            catch { throw; }
        }

        public async Task<List<ClienteDTO>> Lista()
        {
            try
            {
                var queryCliente = await _clienteRepositorio.Consultar();
                var listaClientes = queryCliente.ToList();
                return _mapper.Map<List<ClienteDTO>>(listaClientes.ToList());
            }
            catch
            {
                throw;
            }
        }
    }
}
