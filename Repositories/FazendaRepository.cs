using AplicacaoProdutoAPI.Models;
using AplicacaoProdutoAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AplicacaoProdutoAPI.Repositories
{
    public class FazendaRepositoty : IFazendaRepository
    {
        private readonly appDBContext _context;

        public FazendaRepositoty(appDBContext context)
        {
            _context = context;
        }
        public async Task<Fazenda> CreateFazenda(Fazenda fazenda)
        {
            _context.Fazendas.Add(fazenda);
            await _context.SaveChangesAsync();
            return fazenda;
        }

        public async Task<bool> DeleteFazenda(int id)
        {
            var fazenda = await _context.Fazendas.FindAsync(id);
            if (fazenda == null)
                return false;

            _context.Fazendas.Remove(fazenda);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Fazenda> GetFazenda(int id)
        {
            return await _context.Fazendas.FindAsync(id);
        }

        public async Task<IEnumerable<Fazenda>> GetFazenda()
        {
            return await _context.Fazendas.ToListAsync();
        }

        public async Task<bool> UpdateFazenda(int id, Fazenda fazenda)
        {
            if (id != fazenda.Id)
                return false;

            _context.Entry(fazenda).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FazendaExists(id))
                    return false;
                else
                    throw;
            }

            return true;
        }

        private bool FazendaExists(int id)
        {
            return _context.Fazendas.Any(p => p.Id == id);
        }
    }
}
