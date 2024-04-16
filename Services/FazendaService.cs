using AplicacaoProdutoAPI.Models;
using AplicacaoProdutoAPI.Repositories.Interfaces;
using AplicacaoProdutoAPI.Services.Interfaces;

namespace AplicacaoProdutoAPI.Services
{
    public class FazendaService : IFazendaService
    {
        private readonly IFazendaRepository _fazendaRepository;

        public FazendaService(IFazendaRepository fazendaRepository)
        {
            _fazendaRepository = fazendaRepository;
        }
        public async Task<Fazenda> CreateFazenda(Fazenda fazenda)
        {
            return await _fazendaRepository.CreateFazenda(fazenda);
        }

        public async Task<bool> DeleteFazenda(int id)
        {
            return await _fazendaRepository.DeleteFazenda(id);
        }

        public async Task<Fazenda> GetFazenda(int id)
        {
            return await _fazendaRepository.GetFazenda(id);
        }

        public async Task<IEnumerable<Fazenda>> GetFazenda()
        {
            return await _fazendaRepository.GetFazenda();
        }

        public async Task<bool> UpdateFazenda(int id, Fazenda fazenda)
        {
            return await _fazendaRepository.UpdateFazenda(id, fazenda);
        }
    }
}
