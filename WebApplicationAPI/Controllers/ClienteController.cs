using Microsoft.AspNetCore.Mvc;
using WebApplicationAPI.Models;

namespace WebApplicationAPI.Controllers
{
    [ApiController]
    [Route("cliente")]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        [Route("listar")]
        public dynamic listarCliente()
        {
            List<Cliente> clientes = new List<Cliente>
            {
                new Cliente
                {
                    id = "1",
                    correo = "abel@gmail.com",
                    edad = "40",
                    nombre ="Abel Estrella"
                },
                new Cliente
                {
                    id = "2",
                    correo = "mariela@gmail.com",
                    edad = "30",
                    nombre ="Mariela Ku"
                }
            };
            return clientes;
        }

        [HttpPost]
        [Route("guardar")]
        public dynamic guardarCliente(Cliente cliente)
        {
            cliente.id = "3";
            return new
            {
                success = true,
                message = "Cliente registrado",
                result = cliente
            };
        }

        [HttpGet]
        [Route("listarxid")]
        public dynamic listarClientexid(string codigo)
        {
            //se obtiene todos los datos de la BD

            return new Cliente
            {
                id = codigo,
                correo = "abel@gmail.com",
                edad = "40",
                nombre ="Abel Estrella"
            };
        }

        [HttpPost]
        [Route("eliminar")]
        public dynamic eliminarCliente(Cliente cliente)
        {
            string token = Request.Headers.Where(x => x.Key == "Autorization").FirstOrDefault().Value;
            if (token != "abel123.")
            {
                return new
                {
                    success = false,
                    message = "Token incorrecto",
                    result = ""
                };
            }

            return new
            {
                success = true,
                message = "Cliente eliminado",
                result = cliente
            };
        }
    }
}
