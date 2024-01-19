using Microsoft.AspNetCore.Mvc;
using super_herois_api.Domain.Models;
using super_herois_api.Services;

namespace super_herois_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperpoderesController : ControllerBase
    {
        private readonly IServiceBase<Superpoderes, Superpoderes> _service;
        public SuperpoderesController(IServiceBase<Superpoderes, Superpoderes> service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get()
        {
            try
            {
                return Ok(_service.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_service.Buscar(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Post([FromBody] Superpoderes superpoder)
        {
            try
            {
                return Ok(_service.Inserir(superpoder));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Put(int id, [FromBody] Superpoderes superpodere)
        {
            try
            {
                return Ok(_service.Atualizar(id, superpodere));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public void Delete(int id)
        {
            try
            {
                _service.Deletar(id);
            }
            catch (Exception ex)
            {
                BadRequest(ex.Message);
            }
        }
    }
}
