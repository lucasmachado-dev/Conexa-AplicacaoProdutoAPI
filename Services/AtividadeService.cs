using AplicacaoProdutoAPI.Models;
using AplicacaoProdutoAPI.Repositories.Interfaces;
using AplicacaoProdutoAPI.Services.Interfaces;

namespace AplicacaoProdutoAPI.Services
{
    public class AtividadeService : IAtividadeService
    {
        private readonly IAtividadeRepository _atividadeRepository;

        public AtividadeService(IAtividadeRepository atividadeRepository)
        {
            _atividadeRepository = atividadeRepository;
        }
        public async Task<Atividade> CreateAtividade(Atividade atividade)
        {
            return await _atividadeRepository.CreateAtividade(atividade);
        }

        public async Task<bool> DeleteAtividade(int id)
        {
            return await _atividadeRepository.DeleteAtividade(id);
        }

        public async Task<Atividade> GetAtividade(int id)
        {
            return await _atividadeRepository.GetAtividade(id);
        }

        public async Task<IEnumerable<Atividade>> GetAtividade()
        {
            return await _atividadeRepository.GetAtividade();
        }

        public async Task<bool> UpdateAtividade(int id, Atividade atividade)
        {
            return await _atividadeRepository.UpdateAtividade(id, atividade);
        }

    }
}
