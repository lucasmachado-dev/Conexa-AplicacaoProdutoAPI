using System.ComponentModel.DataAnnotations;

namespace AplicacaoProdutoAPI.Models
{
    public class Safra
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="É obrigatório informar a descrição")]
        public string Descricao { get; set; }
        [Required(ErrorMessage ="É obrigatório informar a data inicial")]
        public DateTime DataInicio { get; set; }
        [Required(ErrorMessage ="É obrigatório informar a data final")]
        public DateTime DataFim { get; set; }
    }
}
