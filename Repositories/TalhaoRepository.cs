using AplicacaoProdutoAPI.Models;
using AplicacaoProdutoAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AplicacaoProdutoAPI.Repositories
{
    public class TalhaoRepository : ITalhaoRepository
    {
        private readonly appDBContext _context;

        public TalhaoRepository(appDBContext context)
        {
            _context = context;
        }
        public async Task<Talhao> CreateTalhao(Talhao talhao)
        {
            _context.Talhoes.Add(talhao);
            await _context.SaveChangesAsync();
            return talhao;
        }

        public async Task<bool> DeleteTalhao(int id)
        {
            var talhao = await _context.Talhoes.FindAsync(id);
            if (talhao == null)
                return false;

            _context.Talhoes.Remove(talhao);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Talhao> GetTalhao(int id)
        {
            return await _context.Talhoes.FindAsync(id);
        }

        public async Task<IEnumerable<Talhao>> GetTalhao()
        {
            return await _context.Talhoes.ToListAsync();
        }

        public async Task<bool> UpdateTalhao(int id, Talhao talhao)
        {
            if (id != talhao.Id)
                return false;

            _context.Entry(talhao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TalhaoExists(id))
                    return false;
                else
                    throw;
            }

            return true;
        }

        private bool TalhaoExists(int id)
        {
            return _context.Produtos.Any(p => p.Id == id);
        }

    }
}
