using AplicacaoProdutoAPI.Models;
using AplicacaoProdutoAPI.Repositories.Interfaces;
using AplicacaoProdutoAPI.Services.Interfaces;

namespace AplicacaoProdutoAPI.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        public async Task<Produto> CreateProduto(Produto produto)
        {
            return await _produtoRepository.CreateProduto(produto);
        }

        public async Task<bool> DeleteProduto(int id)
        {
            return await _produtoRepository.DeleteProduto(id);
        }

        public async Task<Produto> GetProduto(int id)
        {
            return await _produtoRepository.GetProduto(id);
        }

        public async Task<IEnumerable<Produto>> GetProduto()
        {
            return await _produtoRepository.GetProduto();
        }

        public async Task<bool> UpdateProduto(int id, Produto produto)
        {
            return await _produtoRepository.UpdateProduto(id, produto);
        }
    }
}
