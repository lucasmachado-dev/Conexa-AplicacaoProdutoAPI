using AplicacaoProdutoAPI.Models;

namespace AplicacaoProdutoAPI.Repositories.Interfaces
{
    public interface ISafraRepository
    {
        Task<Safra> CreateSafra(Safra safra);
        Task<Safra> GetSafra(int id);
        Task<IEnumerable<Safra>> GetSafra();
        Task<bool> UpdateSafra(int id, Safra safra);
        Task<bool> DeleteSafra(int id);
    }
}
