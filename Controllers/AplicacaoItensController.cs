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
    public class AplicacaoItensController : ControllerBase
    {
        private readonly appDBContext _context;

        public AplicacaoItensController(appDBContext context)
        {
            _context = context;
        }

        //POST
        [HttpPost]
        public async Task<ActionResult<AplicacaoItens>> PostAplicacaoItens(AplicacaoItens aplicacaoItens)
        {
            
            //Validações - refatorar
            aplicacaoItens.QuantidadeTotal = aplicacaoItens.Dosagem * aplicacaoItens.AreaAplicada;
            aplicacaoItens.Valor = aplicacaoItens.QuantidadeTotal * GetValorProduto(aplicacaoItens.ProdutoId);
            //Fim validações

            _context.AplicacaoItens.Add(aplicacaoItens);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAplicacaoItens", new { id = aplicacaoItens.Id }, aplicacaoItens);
        }


        //PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAplicacaoItens(int id, AplicacaoItens aplicacaoItens)
        {
            if (id != aplicacaoItens.Id)
            {
                return BadRequest();
            }

            _context.Entry(aplicacaoItens).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AplicacaoItensExists(id))
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

        //DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAplicacaoItens(int id)
        {
            var aplicacaoItens = await _context.AplicacaoItens.FindAsync(id);
            if (aplicacaoItens == null)
            {
                return NotFound();
            }

            _context.AplicacaoItens.Remove(aplicacaoItens);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //GET all
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AplicacaoItens>>> GetAplicacaoItens()
        {
            return await _context.AplicacaoItens.ToListAsync();
        }

        //GET por id
        [HttpGet("{id}")]
        public async Task<ActionResult<AplicacaoItens>> GetAplicacaoItens(int id)
        {
            var aplicacaoItens = await _context.AplicacaoItens.FindAsync(id);

            if (aplicacaoItens == null)
            {
                return NotFound();
            }

            return aplicacaoItens;
        }

        private bool AplicacaoItensExists(int id)
        {
            return _context.AplicacaoItens.Any(e => e.Id == id);
        }

        private decimal GetValorProduto(int produtoId)
        {
            var produto = _context.Produtos.Find(produtoId);
            return produto.PrecoUnitario;
        }
    }
}
