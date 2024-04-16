using AplicacaoProdutoAPI.Models;
using AplicacaoProdutoAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AplicacaoProdutoAPI.Repositories
{
    public class SafraRepository : ISafraRepository
    {
        private readonly appDBContext _context;

        public SafraRepository(appDBContext context)
        {
            _context = context;
        }
        public async Task<Safra> CreateSafra(Safra safra)
        {
            _context.Safras.Add(safra);
            await _context.SaveChangesAsync();
            return safra;
        }

        public async Task<bool> DeleteSafra(int id)
        {
            var safra = await _context.Safras.FindAsync(id);
            if (safra == null)
                return false;

            _context.Safras.Remove(safra);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Safra> GetSafra(int id)
        {
            return await _context.Safras.FindAsync(id);
        }

        public async Task<IEnumerable<Safra>> GetSafra()
        {
            return await _context.Safras.ToListAsync();
        }

        public async Task<bool> UpdateSafra(int id, Safra safra)
        {
            if (id != safra.Id)
                return false;

            _context.Entry(safra).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SafraExists(id))
                    return false;
                else
                    throw;
            }

            return true;
        }

        private bool SafraExists(int id)
        {
            return _context.Produtos.Any(p => p.Id == id);
        }

    }
}
