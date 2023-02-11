using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesMac.Models
{
    /**
     * Não há necessidade de anotar o nome da tabela neste ponto. 
     * Estamos usando as convenções do framework. Pela conversão, 
     * o próprio framework nomearia a tabela conforme definição 
     * realizada no mapemento da tabela na classe AddDbContext 
     * ***/
    [Table("Categorias")] 
    public class Categoria
    {
        #region "Atributos da classe"
        /**
         * Pelos mesmos motivos da anotação da tabela, esta anotação (Key)
         * se torna desnecessária. Ou seja, pela convenção e definição
         * da entidade, já seria suficiente para que o framework
         * criasse a tabela e seu atributos de maneira adequada
         * ***/

        [Key]
        public int CategoriaId { get; set; }

        [StringLength(100, ErrorMessage = "O tamanho máximo é de 100 caracteres")]
        [Required(ErrorMessage = "Informe o nome da categoria")]
        [Display(Name = "Nome")]
        public string? CategoriaNome { get; set; }

        [StringLength(200, ErrorMessage = "O tamanhno máximo é de 200 caracteres")]
        [Required(ErrorMessage = "Informe a descrição da categoria")]
        [Display(Name = "Descrição")]
        public string? Descricao { get; set; }
        #endregion

        #region "Atributos de relacionamento com Lanche"
        public List<Lanche>? Lanches { get; set; } // Relacionamento com Lanche ( 1 para muitos )
        #endregion
    }
}