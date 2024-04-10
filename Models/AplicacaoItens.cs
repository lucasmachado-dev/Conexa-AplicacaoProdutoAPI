using System.ComponentModel.DataAnnotations;

namespace AplicacaoProdutoAPI.Models
{
    public class AplicacaoItens
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="É obrigatório informa o id da aplicação")]
        public int AplicacaoId { get; set; }
        [Required(ErrorMessage = "É obrigatório informa o id do produto")]
        public int ProdutoId { get; set; }
        [Required(ErrorMessage = "É obrigatório informa a dosagem")]
        public decimal Dosagem { get; set; }
        [Required(ErrorMessage = "É obrigatório informa a área aplicada")]
        public decimal AreaAplicada { get; set; }
        public decimal QuantidadeTotal { get; set; }
        public decimal Valor { get; set; }
    }
}
