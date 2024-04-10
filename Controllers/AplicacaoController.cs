using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AplicacaoProdutoAPI.Models;
using NuGet.Protocol;

namespace AplicacaoProdutoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AplicacaoController : ControllerBase
    {
        private readonly appDBContext _context;

        public AplicacaoController(appDBContext context)
        {
            _context = context;
        }

        //POST
        [HttpPost]
        public async Task<ActionResult<Aplicacao>> PostAplicacao(Aplicacao aplicacao)
        {
            if (!SafraExists(aplicacao.SafraId))
            {
                return NotFound("Id da safra inválido.".ToJson());
            }
            if (!FazendaExists(aplicacao.FazendaId))
            {
                return NotFound("Id da fazenda inválido.".ToJson());
            }
            if (!AtividadeExists(aplicacao.AtividadeId))
            {
                return NotFound("Id da atividade inválido.".ToJson());
            }
            if (!TalhaoExists(aplicacao.TalhaoId))
            {
                return NotFound("Id do talhão inválido.".ToJson());
            }
            if (!TalhaoPertenceFazenda(aplicacao.TalhaoId, aplicacao.FazendaId))
            {
                return ValidationProblem("Talhão não pertence à fazenda informada.".ToJson());
            }

            decimal areaTalhao = GetAreaTalhao(aplicacao.TalhaoId);


            foreach (var item in aplicacao.AplicacaoItens)
            {
                item.QuantidadeTotal = item.Dosagem * item.AreaAplicada;
                item.Valor = item.QuantidadeTotal * GetValorProduto(item.ProdutoId);
                if (item.AreaAplicada > areaTalhao)
                {
                    return ValidationProblem("Área aplicada não pode ser maior que a área do talhão.".ToJson());
                }
            }
            

            _context.Aplicacoes.Add(aplicacao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAplicacao", new { id = aplicacao.Id }, aplicacao);
        }


        //PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAplicacao(int id, Aplicacao aplicacao)
        {
            if (id != aplicacao.Id)
            {
                return BadRequest();
            }

            _context.Entry(aplicacao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AplicacaoExists(id))
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
        public async Task<IActionResult> DeleteAplicacao(int id)
        {
            var aplicacao = await _context.Aplicacoes.FindAsync(id);
            if (aplicacao == null)
            {
                return NotFound();
            }

            _context.Aplicacoes.Remove(aplicacao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //GET all
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aplicacao>>> GetAplicacao()
        {
            return await _context.Aplicacoes.ToListAsync();
        }

        //GET id
        [HttpGet("{id}")]
        public async Task<ActionResult<Aplicacao>> GetAplicacao(int id)
        {
            var aplicacao = await _context.Aplicacoes.FindAsync(id);

            if (aplicacao == null)
            {
                return NotFound();
            }

            return aplicacao;
        }

        //TODO: implementar busca avançada
        //GET avançado
        [HttpGet("Busca{?data}")]
        public async Task<ActionResult<IEnumerable<Aplicacao>>> GetAplicacao(DateOnly data)
        {
            var retorno = _context.Aplicacoes.Where(a => a.Data == data);
            return retorno.ToList();
        }

        private bool AplicacaoExists(int id)
        {
            return _context.Aplicacoes.Any(e => e.Id == id);
        }

        private bool SafraExists(int id)
        {
            return _context.Safras.Any(s => s.Id == id);
        }

        private bool FazendaExists(int id)
        {
            return _context.Fazendas.Any(f => f.Id == id);
        }
        private bool AtividadeExists(int id)
        {
            return _context.Atividades.Any(a => a.Id == id);
        }
        private bool TalhaoExists(int id)
        {
            return _context.Talhoes.Any(t => t.Id == id);
        }
        private bool TalhaoPertenceFazenda(int idTalhao, int idFazenda)
        {
            var talhao = _context.Talhoes.Find(idTalhao);
            return talhao.FazendaId == idFazenda;
        }
        private decimal GetValorProduto(int produtoId)
        {
            var produto = _context.Produtos.Find(produtoId);
            return produto.PrecoUnitario;
        }
        private decimal GetAreaTalhao(int talhaoId)
        {
            var talhao = _context.Talhoes.Find(talhaoId);
            return talhao.Area;
        }

    }
}
