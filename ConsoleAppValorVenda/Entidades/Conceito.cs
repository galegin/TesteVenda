namespace ConsoleAppValorVenda
{
    public class Conceito
    {
        public ConceitoTipo Codigo { get; set; }
        public double PercDesconto { get; set; }

        public Conceito(ConceitoTipo codigo, double percDesconto)
        {
            Codigo = codigo;
            PercDesconto = percDesconto;
        }

        public override bool Equals(object obj)
        {
            return obj is Conceito conceito &&
                   Codigo == conceito.Codigo;
        }

        public override int GetHashCode()
        {
            return 11 + Codigo.GetHashCode();
        }
    }
}