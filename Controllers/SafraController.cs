using Microsoft.AspNetCore.Mvc;
using AplicacaoProdutoAPI.Models;
using AplicacaoProdutoAPI.Services.Interfaces;

namespace AplicacaoProdutoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SafraController : ControllerBase
    {
        private readonly ISafraService _safraService;

        public SafraController(ISafraService safraService)
        {
            _safraService = safraService;
        }

        [HttpPost]
        public async Task<ActionResult<Safra>> PostSafra(Safra safra)
        {
            await _safraService.CreateSafra(safra);
            return safra;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSafra(int id, Safra safra)
        {
            if (id != safra.Id)
            {
                return BadRequest();
            }

            try
            {
                await _safraService.UpdateSafra(id, safra);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return Ok(safra);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSafra(int id)
        {
            try
            {
                await _safraService.DeleteSafra(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Safra>>> GetSafra()
        {
            var safras = await _safraService.GetSafra();
            return Ok(safras);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Safra>> GetSafra(int id)
        {
            var safra = await _safraService.GetSafra(id);

            if (safra == null)
            {
                return NotFound();
            }

            return Ok(safra);
        }
    }
}