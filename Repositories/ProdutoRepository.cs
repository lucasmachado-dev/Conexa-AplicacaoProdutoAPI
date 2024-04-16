using AplicacaoProdutoAPI.Models;
using AplicacaoProdutoAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AplicacaoProdutoAPI.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly appDBContext _context;

        public ProdutoRepository(appDBContext context)
        {
            _context = context;
        }
        public async Task<Produto> CreateProduto(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
            return produto;
        }

        public async Task<bool> DeleteProduto(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
                return false;

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Produto> GetProduto(int id)
        {
            return await _context.Produtos.FindAsync(id);
        }

        public async Task<IEnumerable<Produto>> GetProduto()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task<bool> UpdateProduto(int id, Produto produto)
        {
            if (id != produto.Id)
                return false;

            _context.Entry(produto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoExists(id))
                    return false;
                else
                    throw;
            }

            return true;
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produtos.Any(p => p.Id == id);
        }
        public decimal GetValorProduto(int id)
        {
            var produto = _context.Produtos.Find(id);
            return produto.PrecoUnitario;
        }

    }
}
