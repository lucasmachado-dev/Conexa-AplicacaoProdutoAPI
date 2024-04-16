using Microsoft.AspNetCore.Mvc;
using AplicacaoProdutoAPI.Models;
using AplicacaoProdutoAPI.Services.Interfaces;

namespace AplicacaoProdutoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TalhaoController : ControllerBase
    {
        private readonly ITalhaoService _talhaoService;

        public TalhaoController(ITalhaoService talhaoService)
        {
            _talhaoService = talhaoService;
        }

        [HttpPost]
        public async Task<ActionResult<Talhao>> PostTalhao(Talhao talhao)
        {
            await _talhaoService.CreateTalhao(talhao);
            return Ok(talhao);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTalhao(int id, Talhao talhao)
        {
            if (id != talhao.Id)
            {
                return BadRequest();
            }

            try
            {
                await _talhaoService.UpdateTalhao(id, talhao);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return Ok(talhao);
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTalhao(int id)
        {
            try
            {
                await _talhaoService.DeleteTalhao(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Talhao>>> GetTalhoes()
        {
            var talhoes = await _talhaoService.GetTalhao();
            return Ok(talhoes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Talhao>> GetTalhao(int id)
        {
            var talhao = await _talhaoService.GetTalhao(id);

            if (talhao == null)
            {
                return NotFound();
            }

            return Ok(talhao);
        }


    }
}
