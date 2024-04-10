using System.ComponentModel.DataAnnotations.Schema;

namespace AplicacaoProdutoAPI.Models
{
    public class Talhao
    {
        public int Id { get; set; }      
        public int FazendaId { get; set; }
        public string Identificacao { get; set; }
        public decimal Area { get; set; }

    }
}
