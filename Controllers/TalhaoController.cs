using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AplicacaoProdutoAPI.Models;

namespace AplicacaoProdutoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TalhaoController : ControllerBase
    {
        private readonly appDBContext _context;

        public TalhaoController(appDBContext context)
        {
            _context = context;
        }

        // GET: api/Talhao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Talhao>>> GetTalhoes()
        {
            return await _context.Talhoes.ToListAsync();
        }

        // GET: api/Talhao/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Talhao>> GetTalhao(int id)
        {
            var talhao = await _context.Talhoes.FindAsync(id);

            if (talhao == null)
            {
                return NotFound();
            }

            return talhao;
        }

        // PUT: api/Talhao/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTalhao(int id, Talhao talhao)
        {
            if (id != talhao.Id)
            {
                return BadRequest();
            }

            _context.Entry(talhao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TalhaoExists(id))
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

        // POST: api/Talhao
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Talhao>> PostTalhao(Talhao talhao)
        {
            _context.Talhoes.Add(talhao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTalhao", new { id = talhao.Id }, talhao);
        }

        // DELETE: api/Talhao/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTalhao(int id)
        {
            var talhao = await _context.Talhoes.FindAsync(id);
            if (talhao == null)
            {
                return NotFound();
            }

            _context.Talhoes.Remove(talhao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TalhaoExists(int id)
        {
            return _context.Talhoes.Any(e => e.Id == id);
        }
    }
}
