using NuGet.Protocol.Core.Types;
using System.ComponentModel.DataAnnotations;

namespace AplicacaoProdutoAPI.Models
{
    public class Aplicacao
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="É obrigatório informar a Data")]
        public DateOnly Data { get; set; }
        [Required(ErrorMessage = "É obrigatório informar a Fazenda")]
        public int FazendaId { get; set; }
        [Required(ErrorMessage = "É obrigatório informar a Safra")]
        public int SafraId { get; set; }
        [Required(ErrorMessage = "É obrigatório informar a Atividade")]
        public int AtividadeId { get; set; }
        [Required(ErrorMessage = "É obrigatório informar o Talhão")]
        public int TalhaoId { get; set; }
        public string Observacao { get; set; }

        public List<AplicacaoItens> AplicacaoItens { get; set; }

    }
}
