using Microsoft.AspNetCore.Mvc;
using AplicacaoProdutoAPI.Models;
using AplicacaoProdutoAPI.Services.Interfaces;

namespace AplicacaoProdutoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FazendaController : ControllerBase
    {
        private readonly IFazendaService _fazendaService;

        public FazendaController(IFazendaService fazendaService)
        {
            _fazendaService = fazendaService;
        }

        [HttpPost]
        public async Task<ActionResult<Fazenda>> PostFazenda(Fazenda fazenda)
        {

            await _fazendaService.CreateFazenda(fazenda);
            return Ok(fazenda);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFazenda(int id, Fazenda fazenda)
        {
            if (id != fazenda.Id)
            {
                return BadRequest();
            }

            try
            {
                await _fazendaService.UpdateFazenda(id, fazenda);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFazenda(int id)
        {
            try
            {
                await _fazendaService.DeleteFazenda(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fazenda>>> GetFazendas()
        {
            var fazendas = await _fazendaService.GetFazenda();
            return Ok(fazendas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Fazenda>> GetFazenda(int id)
        {
            var fazenda = await _fazendaService.GetFazenda(id);

            if (fazenda == null)
            {
                return NotFound();
            }

            return Ok(fazenda);
        }
    }
}
