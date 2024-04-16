using System.ComponentModel.DataAnnotations;

namespace AplicacaoProdutoAPI.Models
{
    public class Produto
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="É obrigatório informar a Descrição")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "É obrigatório informar o Preço Unitário")]
        public decimal PrecoUnitario { get; set; }
    }
}
