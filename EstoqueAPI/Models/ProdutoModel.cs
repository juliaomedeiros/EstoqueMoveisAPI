using System.ComponentModel.DataAnnotations;

namespace EstoqueAPI.Models
{
    public class ProdutoModel
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cor { get; set; }
        public string? Dimencoes { get; set; }
        public string? Tipo { get; set; }
        public int Quantidade { get; set; }
        public string? Img { get; set; } //Se der certo usar, mas nao agora
        public DateTime DataDeCriacao { get; set; } = DateTime.Now.ToLocalTime();
        public DateTime DataDeAlteracao { get; set; } = DateTime.Now.ToLocalTime();
    }
}
