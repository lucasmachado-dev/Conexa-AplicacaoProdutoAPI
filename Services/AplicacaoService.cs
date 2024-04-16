using AplicacaoProdutoAPI.Models;
using AplicacaoProdutoAPI.Repositories.Interfaces;
using AplicacaoProdutoAPI.Services.Interfaces;

namespace AplicacaoProdutoAPI.Services
{
    public class AplicacaoService : IAplicacaoService
    {
        private readonly IAplicacaoRepository _aplicacaoRepository;

        public AplicacaoService(IAplicacaoRepository aplicacaoRepository)
        {
            _aplicacaoRepository = aplicacaoRepository;
        }

        public async Task<Aplicacao> CreateAplicacao(Aplicacao aplicacao)
        {
            return await _aplicacaoRepository.CreateAplicacao(aplicacao);
        }

        public async Task<bool> DeleteAplicacao(int id)
        {
            return await _aplicacaoRepository.DeleteAplicacao(id);
        }

        public async Task<Aplicacao> GetAplicacao(int id)
        {
            return await _aplicacaoRepository.GetAplicacao(id);
        }

        public async Task<IEnumerable<Aplicacao>> GetAplicacoes()
        {
            return await _aplicacaoRepository.GetAplicacoes();
        }

        public async Task<IEnumerable<Aplicacao>> GetAplicacoesByDate(DateOnly data)
        {
            return await _aplicacaoRepository.GetAplicacoesByDate(data);
        }

        public async Task<bool> UpdateAplicacao(int id, Aplicacao aplicacao)
        {
            return await _aplicacaoRepository.UpdateAplicacao(id, aplicacao);
        }
    }
}
