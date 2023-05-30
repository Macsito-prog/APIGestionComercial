using GestionComercial.BLL.Servicios.Contrato;
using GestionComercial.DTO;
using GestionComercial.API.Utilidad;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;

namespace GestionComercial.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ClienteController : ControllerBase
    {
        private readonly IClienteServicio _clienteServicio;

        public ClienteController(IClienteServicio clienteServicio)
        {
            _clienteServicio = clienteServicio;
        }
        [HttpGet]
        [Route("Lista")]

        public async Task<IActionResult> Lista()
        {
            var rsp = new Response<List<ClienteDTO>>();

            try
            {
                rsp.status = true;
                rsp.value = await _clienteServicio.Lista();
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;
            }
            return Ok(rsp);
        }

        [HttpPost]
        [Route("Guardar")]

        public async Task<IActionResult> Guardar([FromBody] ClienteDTO cliente)
        {
            var rsp = new Response<ClienteDTO>();

            try
            {
                rsp.status = true;
                rsp.value = await _clienteServicio.Crear(cliente);
            }catch(Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;
            }
            return Ok(rsp);
        }
        [HttpPut]
        [Route("Editar")]

        public async Task<IActionResult> Editar([FromBody] ClienteDTO cliente)
        {
            var rsp = new Response<bool>();

            try
            {
                rsp.status = true;
                rsp.value = await _clienteServicio.Editar(cliente);
            }
            catch(Exception ex)
            {
                rsp.status = false; 
                rsp.msg = ex.Message;
            }
            return Ok(rsp);
        }

        [HttpDelete]
        [Route("Eliminar/{IdCliente:int}")]

        public async Task<IActionResult>Eliminar(int IdCliente)
        {
            var rsp = new Response<bool>();

            try
            {
                rsp.status = true;
                rsp.value = await _clienteServicio.Eliminar(IdCliente);
            }
            catch(Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;
            }

            return Ok(rsp); 
        }
    }
}
