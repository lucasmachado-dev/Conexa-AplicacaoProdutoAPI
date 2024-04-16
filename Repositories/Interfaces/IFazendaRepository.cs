using AplicacaoProdutoAPI.Models;

namespace AplicacaoProdutoAPI.Repositories.Interfaces
{
    public interface IFazendaRepository 
    {
        Task<Fazenda> CreateFazenda(Fazenda fazenda);
        Task<Fazenda> GetFazenda(int id);
        Task<IEnumerable<Fazenda>> GetFazenda();
        Task<bool> UpdateFazenda(int id, Fazenda fazenda);
        Task<bool> DeleteFazenda(int id);
    }
}
