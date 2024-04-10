using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AplicacaoProdutoAPI.Models
{
    public class Fazenda
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="É obrigatório informar a descrição da fazenda")]
        public String Descricao { get; set; }

    }
}
