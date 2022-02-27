using API_EF6.Models.Entities.Clientes;
using API_EF6.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_EF6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClientesRepository repos;
        public ClientesController(IClientesRepository _repos)
        {
            repos = _repos;
        }

        [HttpGet("{Id}")]
        public IActionResult Get([FromRoute]ClienteId cliente)
        {
            var cliente_db = repos.Read(cliente.Id);
            return Ok(cliente_db);
        }

        [HttpPost]
        public IActionResult Post(PostClientes cliente)
        {
            if (repos.Create(cliente))
                return Ok();

            return BadRequest();
        }

        [HttpPut]
        public IActionResult Put(PutClientes cliente)
        {
            if (repos.Update(cliente))
                return Ok();

            return BadRequest();
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete([FromRoute] ClienteId cliente)
        {
            if (repos.Delete(cliente.Id))
                return Ok();

            return BadRequest();
        }



    }
}
