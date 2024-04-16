using AplicacaoProdutoAPI.Models;

namespace AplicacaoProdutoAPI.Repositories.Interfaces
{
    public interface ITalhaoRepository
    {
        Task<Talhao> CreateTalhao(Talhao talhao);
        Task<Talhao> GetTalhao(int id);
        Task<IEnumerable<Talhao>> GetTalhao();
        Task<bool> UpdateTalhao(int id, Talhao talhao);
        Task<bool> DeleteTalhao(int id);
    }
}
