using AplicacaoProdutoAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AplicacaoProdutoAPI.Services.Interfaces
{
    public interface ITalhaoService
    {
        Task<Talhao> CreateTalhao(Talhao talhao);
        Task<Talhao> GetTalhao(int id);
        Task<IEnumerable<Talhao>> GetTalhao();
        Task<bool> UpdateTalhao(int id, Talhao talhao);
        Task<bool> DeleteTalhao(int id);
    }
}

