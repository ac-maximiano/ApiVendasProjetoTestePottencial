using System.ComponentModel.DataAnnotations;

namespace Pottencial.Teste.Presentation.Api.ViewModels
{
    public class ProdutoVM
    {
        public Guid? Id { get; set; }
        [Required]
        public string? Nome { get; set; }
        [Required]
        public string? Descricao { get; set; }
        [Required]
        public decimal PrecoReferencia { get; set; }
        public bool Ativo { get; set; }
    }
}
