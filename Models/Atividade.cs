using System.ComponentModel.DataAnnotations;

namespace AplicacaoProdutoAPI.Models
{
    public class Atividade
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "É obrigatório informar a descrição")]
        public string Descricao { get; set; }
    }
}
