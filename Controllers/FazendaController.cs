using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AplicacaoProdutoAPI.Models;
using NuGet.Protocol;

namespace AplicacaoProdutoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FazendaController : ControllerBase
    {
        private readonly appDBContext _context;

        public FazendaController(appDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fazenda>>> GetFazendas()
        {
            return await _context.Fazendas.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Fazenda>> GetFazenda(int id)
        {
            var fazenda = await _context.Fazendas.FindAsync(id);

            if (fazenda == null)
            {
                return NotFound();
            }

            return fazenda;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFazenda(int id, Fazenda fazenda)
        {
            if (id != fazenda.Id)
            {
                return BadRequest();
            }

            _context.Entry(fazenda).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FazendaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(fazenda.ToJson());
        }

        [HttpPost]
        public async Task<ActionResult<Fazenda>> PostFazenda(Fazenda fazenda)
        {
            _context.Fazendas.Add(fazenda);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFazenda", new { id = fazenda.Id }, fazenda);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFazenda(int id)
        {
            var fazenda = await _context.Fazendas.FindAsync(id);
            if (fazenda == null)
            {
                return NotFound();
            }

            _context.Fazendas.Remove(fazenda);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FazendaExists(int id)
        {
            return _context.Fazendas.Any(e => e.Id == id);
        }
    }
}
