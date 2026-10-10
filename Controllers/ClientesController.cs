using Microsoft.AspNetCore.Mvc;
using tarea1progra2.Models;

namespace tarea1progra2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : Controller
    {
        private readonly TareaApiContext _ctx;

        public ClientesController(TareaApiContext ctx)
        {
            _ctx = ctx;
        }

        // 1. SELECT - Obtener todos los clientes
        [HttpGet("ListarUsuarios")]
        public ActionResult<List<Cliente>> ListarClientes()
        {
            return _ctx.Clientes.ToList();
        }

        // 1. SELECT - Obtener cliente por ID
        [HttpGet("ObtenerUsuario/{id}")]
        public ActionResult<Cliente> ObtenerUsuario(int id)
        {
            var cliente = _ctx.Clientes.FirstOrDefault(e => e.IdCliente == id);
            if (cliente == null)
            {
                return NotFound();
            }
            return cliente;
        }

        // 2. INSERT - Crear nuevo cliente
        [HttpPost("CrearCliente")]
        public ActionResult<Cliente> CrearCliente([FromBody] Cliente cliente)
        {
            _ctx.Clientes.Add(cliente);
            _ctx.SaveChanges();
            return Ok(cliente);
        }

        // 3. UPDATE - Actualizar cliente existente
        [HttpPut("ActualizarCliente/{id}")]
        public ActionResult ActualizarCliente(int id, [FromBody] Cliente cliente)
        {
            var clienteExistente = _ctx.Clientes.FirstOrDefault(e => e.IdCliente == id);
            if (clienteExistente == null)
            {
                return NotFound();
            }

            clienteExistente.Nombre = cliente.Nombre;
            clienteExistente.Apellidos = cliente.Apellidos;
            clienteExistente.Telefono = cliente.Telefono;

            _ctx.SaveChanges();
            return Ok(clienteExistente);
        }
    }
}