using Microsoft.AspNetCore.Mvc;
using AplicacaoProdutoAPI.Models;
using AplicacaoProdutoAPI.Services.Interfaces;

namespace AplicacaoProdutoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }


        [HttpPost]
        public async Task<ActionResult<Produto>> PostProduto(Produto produto)
        {
            await _produtoService.CreateProduto(produto);

            return Ok(produto);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduto(int id, Produto produto)
        {
            if (id != produto.Id)
            {
                return BadRequest();
            }

            try
            {
                await _produtoService.UpdateProduto(id, produto);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduto(int id)
        {
            try
            {
                await _produtoService.DeleteProduto(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProduto()
        {
            var produtos = await _produtoService.GetProduto();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetProduto(int id)
        {
            var produto = await _produtoService.GetProduto(id);

            if (produto == null)
            {
                return NotFound();
            }

            return Ok(produto);
        }


    }
}
