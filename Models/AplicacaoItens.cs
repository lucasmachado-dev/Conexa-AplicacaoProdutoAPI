using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AplicacaoProdutoAPI.Models
{
    public class AplicacaoItens
    {
        public int Id { get; set; }
        [ForeignKey("Aplicacao")]
        public int AplicacaoId { get; set; }
        [Required(ErrorMessage = "É obrigatório informar o id do produto")]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "É obrigatório informar a dosagem")]
        public decimal Dosagem { get; set; }
        [Required(ErrorMessage = "É obrigatório informar a área aplicada")]
        public decimal AreaAplicada { get; set; }
        public decimal QuantidadeTotal { get; set; }
        public decimal Valor { get; set; }

    }
}
