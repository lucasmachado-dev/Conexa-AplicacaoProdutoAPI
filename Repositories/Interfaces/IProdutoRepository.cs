using AplicacaoProdutoAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AplicacaoProdutoAPI.Repositories.Interfaces
{
    public interface IProdutoRepository
    {
        Task<Produto> CreateProduto(Produto produto);
        Task<Produto> GetProduto(int id);
        Task<IEnumerable<Produto>> GetProduto();
        Task<bool> UpdateProduto(int id, Produto produto);
        Task<bool> DeleteProduto(int id);
    }
}
