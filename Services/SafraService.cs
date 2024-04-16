using AplicacaoProdutoAPI.Models;
using AplicacaoProdutoAPI.Repositories.Interfaces;
using AplicacaoProdutoAPI.Services.Interfaces;

namespace AplicacaoProdutoAPI.Services
{
    public class SafraService : ISafraService
    {
        private readonly ISafraRepository _safraRepository;

        public SafraService(ISafraRepository safraRepository)
        {
            _safraRepository = safraRepository;
        }
        public async Task<Safra> CreateSafra(Safra safra)
        {
            return await _safraRepository.CreateSafra(safra);
        }

        public async Task<bool> DeleteSafra(int id)
        {
            return await _safraRepository.DeleteSafra(id);
        }

        public async Task<Safra> GetSafra(int id)
        {
            return await _safraRepository.GetSafra(id);
        }

        public async Task<IEnumerable<Safra>> GetSafra()
        {
            return await _safraRepository.GetSafra();
        }

        public async Task<bool> UpdateSafra(int id, Safra safra)
        {
            return await _safraRepository.UpdateSafra(id, safra);
        }
    }
}
