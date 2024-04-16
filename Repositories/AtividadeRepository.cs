using AplicacaoProdutoAPI.Models;
using AplicacaoProdutoAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AplicacaoProdutoAPI.Repositories
{
    public class AtividadeRepositoty : IAtividadeRepository
    {
        private readonly appDBContext _context;

        public AtividadeRepositoty(appDBContext context)
        {
            _context = context;
        }
        public async Task<Atividade> CreateAtividade(Atividade atividade)
        {
            _context.Atividades.Add(atividade);
            await _context.SaveChangesAsync();
            return atividade;
        }

        public async Task<bool> DeleteAtividade(int id)
        {
            var atividade = await _context.Atividades.FindAsync(id);
            if (atividade == null)
                return false;

            _context.Atividades.Remove(atividade);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Atividade> GetAtividade(int id)
        {
            return await _context.Atividades.FindAsync(id);
        }

        public async Task<IEnumerable<Atividade>> GetAtividade()
        {
            return await _context.Atividades.ToListAsync();
        }

        public async Task<bool> UpdateAtividade(int id, Atividade atividade)
        {
            if (id != atividade.Id)
                return false;

            _context.Entry(atividade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AtividadeExists(id))
                    return false;
                else
                    throw;
            }

            return true;
        }

        private bool AtividadeExists(int id)
        {
            return _context.Atividades.Any(p => p.Id == id);
        }
    }
}
