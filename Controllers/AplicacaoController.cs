using Microsoft.AspNetCore.Mvc;
using AplicacaoProdutoAPI.Models;
using AplicacaoProdutoAPI.Services.Interfaces;

namespace AplicacaoProdutoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AplicacaoController : ControllerBase
    {
        private readonly IAplicacaoService _aplicacaoService;

        public AplicacaoController(IAplicacaoService aplicacaoService)
        {
            _aplicacaoService = aplicacaoService;
        }


        [HttpPost]
        public async Task<ActionResult<Aplicacao>> PostAplicacao(Aplicacao aplicacao)
        {
            await _aplicacaoService.CreateAplicacao(aplicacao);

            return Ok(aplicacao);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAplicacao(int id, Aplicacao aplicacao)
        {
            if (id != aplicacao.Id)
            {
                return BadRequest();
            }

            try
            {
                await _aplicacaoService.UpdateAplicacao(id, aplicacao);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return Ok(aplicacao);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAplicacao(int id)
        {
            try
            {
                await _aplicacaoService.DeleteAplicacao(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aplicacao>>> GetAplicacoes()
        {
            var aplicacoes = await _aplicacaoService.GetAplicacoes();
            return Ok(aplicacoes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Aplicacao>> GetAplicacao(int id)
        {
            var aplicacao = await _aplicacaoService.GetAplicacao(id);

            if (aplicacao == null)
            {
                return NotFound();
            }

            return Ok(aplicacao);
        }




    }
}
