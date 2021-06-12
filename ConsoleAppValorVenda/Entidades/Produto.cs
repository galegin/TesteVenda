namespace ConsoleAppValorVenda
{
    public class Produto
    {
        public int Codigo { get; set; }
        public Grupo Grupo { get; set; }
        public string Descricao { get; set; }
        public string Formula { get; set; }
        public string PrincAtivo { get; set; }
        public string UnidMedida { get; set; }
        public double ValorVenda { get; set; }

        public Produto(int codigo, Grupo grupo, string descricao, string formula, string princAtivo, string unidMedida, double valorVenda)
        {
            Codigo = codigo;
            Grupo = grupo;
            Descricao = descricao;
            Formula = formula;
            PrincAtivo = princAtivo;
            UnidMedida = unidMedida;
            ValorVenda = valorVenda;
        }

        public override bool Equals(object obj)
        {
            return obj is Produto produto &&
                   Codigo == produto.Codigo;
        }

        public override int GetHashCode()
        {
            return 11 + Codigo.GetHashCode();
        }
    }
}