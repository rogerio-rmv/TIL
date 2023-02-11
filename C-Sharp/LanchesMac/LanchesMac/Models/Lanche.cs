namespace LanchesMac.Models
{
    public class Lanche
    {
        #region "Atributos da classe"
        public int LancheId { get; set; }
        public string? Nome { get; set; }
        public string? DescricaoCurta { get; set; }
        public string? DescricaoDetalhada { get; set; }
        public decimal Preco { get; set; }
        public string? ImagemUrl { get; set; }
        public string? ImagemThumbnailUrl { get; set; }
        public bool IsLanchePreferido { get; set; }
        public bool EmEstoque { get; set; }
        #endregion

        #region "Atributos de relacionamento com Categoria"
        public int CategoriaId { get; set; } // Atributo chave-estrangeira
        public virtual Categoria? Categoria { get; set; } // Relacionamento com Categoria ( 1 para 1 )
        #endregion
    }
}
