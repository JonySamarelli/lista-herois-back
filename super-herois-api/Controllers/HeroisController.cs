using Microsoft.AspNetCore.Mvc;
using super_herois_api.Domain.DTOs;
using super_herois_api.Domain.Models;
using super_herois_api.Exceptions;
using super_herois_api.Services;
using System.Text.Json;

namespace super_herois_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroisController : ControllerBase
    {
        private readonly IServiceBase<Herois, HeroisDTO> _service;
        public HeroisController(IServiceBase<Herois, HeroisDTO> service)
        {
            _service = service;
        }
        // GET: api/<HeroisController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<Herois> heroes = _service.Listar();
                return Ok(heroes);
            } catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // GET api/<HeroisController>/id
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get(int id)
        {
            try
            {
                HeroisDTO? heroiDto = _service.Buscar(id);
                return Ok(heroiDto);
            }
            catch (HeroisExcepetion e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // POST api/<HeroisController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Post([FromBody] HeroisDTO heroiDto)
        {
            try
            {
                Herois heroi = _service.Inserir(heroiDto);
                if (heroi == null)
                {
                    return StatusCode(500, "Não foi possível inserir o herói. Tente novamente.");
                }
                return Ok(heroi);
            }
            catch (HeroisExcepetion e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // PUT api/<HeroisController>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Put(int id, [FromBody] HeroisDTO heroiDto)
        {
            try
            {
                if (_service.Atualizar(id, heroiDto) == null)
                {
                    return StatusCode(500, "Não foi possível atualizar o herói. Tente novamente.");
                }
                return Ok(heroiDto);
            }
            catch (HeroisExcepetion e)
            {
                if (e.Message == "Herói não encontrado") return NotFound(e.Message);
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // DELETE api/<HeroisController>/id
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Delete(int id)
        {
            try
            {
                if(_service.Deletar(id) == null)
                {
                    return StatusCode(500, "Não foi possível deletar o herói. Tente novamente.");
                }
                return Ok("Herói deletado com sucesso!");
            }
            catch (HeroisExcepetion e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
