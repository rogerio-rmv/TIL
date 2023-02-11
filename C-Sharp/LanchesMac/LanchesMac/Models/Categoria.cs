namespace LanchesMac.Models
{
    public class Categoria
    {
        #region "Atributos da classe"
        public int CategoriaId { get; set; }
        public string? CategoriaNome { get; set; }
        public string? Descricao { get; set; }
        #endregion

        #region "Atributos de relacionamento com Lanche"
        public List<Lanche>? Lanches { get; set; } // Relacionamento com Lanche ( 1 para muitos )
        #endregion
    }
}