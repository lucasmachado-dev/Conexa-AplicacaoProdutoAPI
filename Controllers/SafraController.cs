using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AplicacaoProdutoAPI.Models;
using NuGet.Protocol;

namespace AplicacaoProdutoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SafraController : ControllerBase
    {
        private readonly appDBContext _context;

        public SafraController(appDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Safra>>> GetSafra()
        {
            return await _context.Safras.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Safra>> GetSafra(int id)
        {
            var safra = await _context.Safras.FindAsync(id);

            if (safra == null)
            {
                return NotFound();
            }

            return safra;
        }

        // POST: api/Safra
        [HttpPost]
        public async Task<ActionResult<Safra>> PostSafra(Safra safra)
        {
            if (safra.DataInicio >= safra.DataFim)
            {
                return BadRequest("Data final da safra deve ser maior que a data inicial.".ToJson());
            }
            _context.Safras.Add(safra);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSafra", new { id = safra.Id }, safra);
        }

        // PUT: api/Safra/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSafra(int id, Safra safra)
        {
            if (id != safra.Id)
            {
                return BadRequest();
            }

            _context.Entry(safra).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SafraExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Safra/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSafra(int id)
        {
            var safra = await _context.Safras.FindAsync(id);
            if (safra == null)
            {
                return NotFound();
            }

            _context.Safras.Remove(safra);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SafraExists(int id)
        {
            return _context.Safras.Any(e => e.Id == id);
        }
    }
}