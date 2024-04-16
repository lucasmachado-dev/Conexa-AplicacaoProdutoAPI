using AplicacaoProdutoAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AplicacaoProdutoAPI.Repositories.Interfaces
{
    public interface IAplicacaoRepository
    {
        Task<Aplicacao> CreateAplicacao(Aplicacao aplicacao);
        Task<Aplicacao> GetAplicacao(int id);
        Task<IEnumerable<Aplicacao>> GetAplicacoes();
        Task<IEnumerable<Aplicacao>> GetAplicacoesByDate(DateOnly data);
        Task<bool> UpdateAplicacao(int id, Aplicacao aplicacao);
        Task<bool> DeleteAplicacao(int id);
    }
}
