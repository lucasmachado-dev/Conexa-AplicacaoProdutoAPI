using AplicacaoProdutoAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AplicacaoProdutoAPI.Services.Interfaces
{
    public interface ISafraService
    {
        Task<Safra> CreateSafra(Safra safra);
        Task<Safra> GetSafra(int id);
        Task<IEnumerable<Safra>> GetSafra();
        Task<bool> UpdateSafra(int id, Safra safra);
        Task<bool> DeleteSafra(int id);
    }
}

