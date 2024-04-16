using AplicacaoProdutoAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AplicacaoProdutoAPI.Repositories.Interfaces
{
    public interface IAtividadeRepository
    {
        Task<Atividade> CreateAtividade(Atividade atividade);
        Task<Atividade> GetAtividade(int id);
        Task<IEnumerable<Atividade>> GetAtividade();
        Task<bool> UpdateAtividade(int id, Atividade atividade);
        Task<bool> DeleteAtividade(int id);
    }
}
