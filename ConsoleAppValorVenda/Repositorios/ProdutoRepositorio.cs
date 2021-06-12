namespace ConsoleAppValorVenda
{
    public static class ProdutoRepositorio
    {
        public static Produto[] Produtos =
        {
            new Produto(1, GrupoRepositorio.Grupos[0], "Fertilizante - A", null, null, "KG", 150),
            new Produto(1, GrupoRepositorio.Grupos[1], "Corretivo - A", null, null, "KG", 150),
            new Produto(1, GrupoRepositorio.Grupos[2], "Herbicida - A", null, null, "KG", 150),
            new Produto(1, GrupoRepositorio.Grupos[3], "Fungicida - A", null, null, "KG", 150),
            new Produto(1, GrupoRepositorio.Grupos[4], "Inseticida - A", null, null, "KG", 150),
        };
    }
}