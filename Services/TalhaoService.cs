using AplicacaoProdutoAPI.Models;
using AplicacaoProdutoAPI.Repositories.Interfaces;
using AplicacaoProdutoAPI.Services.Interfaces;

namespace AplicacaoProdutoAPI.Services
{
    public class TalhaoService : ITalhaoService
    {
        private readonly ITalhaoRepository _talhaoRepository;

        public TalhaoService(ITalhaoRepository talhaoRepository)
        {
            _talhaoRepository = talhaoRepository;
        }
        public async Task<Talhao> CreateTalhao(Talhao talhao)
        {
            return await _talhaoRepository.CreateTalhao(talhao);
        }

        public async Task<bool> DeleteTalhao(int id)
        {
            return await _talhaoRepository.DeleteTalhao(id);
        }

        public async Task<Talhao> GetTalhao(int id)
        {
            return await _talhaoRepository.GetTalhao(id);
        }

        public async Task<IEnumerable<Talhao>> GetTalhao()
        {
            return await _talhaoRepository.GetTalhao();
        }

        public async Task<bool> UpdateTalhao(int id, Talhao talhao)
        {
            return await _talhaoRepository.UpdateTalhao(id, talhao);
        }
    }
}
