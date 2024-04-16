using AplicacaoProdutoAPI.Models;
using Microsoft.EntityFrameworkCore;
using AplicacaoProdutoAPI.Repositories.Interfaces;

namespace AplicacaoProdutoAPI.Repositories
{
    public class AplicacaoRepository : IAplicacaoRepository
    {
        private readonly appDBContext _context;
        public AplicacaoRepository(appDBContext context)
        {
            _context = context;
        }

        public async Task<Aplicacao> CreateAplicacao(Aplicacao aplicacao)
        {
            _context.Aplicacoes.Add(aplicacao);
            await _context.SaveChangesAsync();
            return aplicacao;
        }

        public async Task<bool> DeleteAplicacao(int id)
        {
            var aplicacao = await _context.Aplicacoes.FindAsync(id);
            if (aplicacao == null)
                return false;

            _context.Aplicacoes.Remove(aplicacao);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Aplicacao> GetAplicacao(int id)
        {
            return await _context.Aplicacoes.FindAsync(id);
        }

        public async Task<IEnumerable<Aplicacao>> GetAplicacoes()
        {
            return await _context.Aplicacoes.Include(a => a.AplicacaoItens).ToArrayAsync();
        }

        public async Task<IEnumerable<Aplicacao>> GetAplicacoesByDate(DateOnly data)
        {
            return await _context.Aplicacoes.Where(a => a.Data == data).ToListAsync();
        }

        public async Task<bool> UpdateAplicacao(int id, Aplicacao aplicacao)
        {
            if (id != aplicacao.Id)
                return false;

            _context.Entry(aplicacao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AplicacaoExists(id))
                    return false;
                else
                    throw;
            }

            return true;
        }

        private bool AplicacaoExists(int id)
        {
            return _context.Aplicacoes.Any(e => e.Id == id);
        }
    }
}
