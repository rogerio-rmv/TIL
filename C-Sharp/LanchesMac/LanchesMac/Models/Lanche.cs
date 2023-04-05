using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesMac.Models
{
    [Table("Lanches")]
    public class Lanche
    {
        #region "Atributos da classe"
        [Key]
        public int LancheId { get; set; }

        [Required(ErrorMessage = "O nome do lanche deve ser informado")]
        [Display(Name = "Nome do Lanche")]
        [StringLength(80, MinimumLength = 3, ErrorMessage = "O {0} deve ter no mínimo {2} e no máximo {1} caracteres")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "A descrição do lanche deve ser informada")]
        [Display(Name = "Descrição do Lanche")]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "A descrição do lanche deve ter no mínimo {2} e no máximo {1} caracteres")]
        public string? DescricaoCurta { get; set; }

        [Required(ErrorMessage = "A descrição detalhada do lanche deve ser informada")]
        [Display(Name = "Descrição detalhada")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "A descrição detalhada do lanche deve ter no mínimo {2} e no máximo {1} caracteres")]
        public string? DescricaoDetalhada { get; set; }

        [Required(ErrorMessage = "O preço do lanche deve ser informado")]
        [Display(Name = "Preço do lanche")]
        [Column(TypeName = "decimal(5,2)")]
        [Range(0.01, 999.99, ErrorMessage = "O preço do lanhce deve estar entre R$ 0,01 e R$ 999,99")]
        public decimal Preco { get; set; }

        [Display(Name = "Caminho Imagem Normal")]
        [StringLength(200, ErrorMessage = "O {0} deve ter o máximo {1} caracteres")]
        public string? ImagemUrl { get; set; }

        [Display(Name = "Caminho Imagem Miniatura")]
        [StringLength(200, ErrorMessage = "O {0} deve ter o máximo {1} caracteres")]
        public string? ImagemThumbnailUrl { get; set; }

        [Display(Name = "Preferido?")]
        public bool IsLanchePreferido { get; set; }

        [Display(Name = "Estoque")]
        public bool EmEstoque { get; set; }
        #endregion

        #region "Atributos de relacionamento com Categoria"
        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; } // Atributo chave-estrangeira
        public virtual Categoria? Categoria { get; set; } // Relacionamento com Categoria ( 1 para 1 )
        #endregion
    }
}
