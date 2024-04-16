using AplicacaoProdutoAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AplicacaoProdutoAPI.Services.Interfaces
{
    public interface IFazendaService
    {
        Task<Fazenda> CreateFazenda(Fazenda fazenda);
        Task<Fazenda> GetFazenda(int id);
        Task<IEnumerable<Fazenda>> GetFazenda();
        Task<bool> UpdateFazenda(int id, Fazenda fazenda);
        Task<bool> DeleteFazenda(int id);
    }
}

