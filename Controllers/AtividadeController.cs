using Microsoft.AspNetCore.Mvc;
using AplicacaoProdutoAPI.Models;
using AplicacaoProdutoAPI.Services.Interfaces;


namespace AplicacaoProdutoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtividadeController : ControllerBase
    {
        private readonly IAtividadeService _atividadeService;

        public AtividadeController(IAtividadeService atividadeService)
        {
            _atividadeService = atividadeService;
        }

        [HttpPost]
        public async Task<ActionResult<Atividade>> PostAtividade(Atividade atividade)
        {
            await _atividadeService.CreateAtividade(atividade);
            return Ok(atividade);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAtividade(int id, Atividade atividade)
        {

            if (id != atividade.Id)
            {
                return BadRequest();
            }

            try
            {
                await _atividadeService.UpdateAtividade(id, atividade);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return Ok(atividade);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAtividade(int id)
        {

            try
            {
                await _atividadeService.DeleteAtividade(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Atividade>>> GetAtividade()
        {
            var atividades = await _atividadeService.GetAtividade();
            return Ok(atividades);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Atividade>> GetAtividade(int id)
        {
            var atividade = await _atividadeService.GetAtividade(id);

            if (atividade == null)
            {
                return NotFound();
            }

            return Ok(atividade);
        }
    }
}