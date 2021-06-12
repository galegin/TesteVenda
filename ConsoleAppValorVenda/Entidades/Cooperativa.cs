namespace ConsoleAppValorVenda
{
    public class Cooperativa
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public Municipio Municipio { get; set; }

        public Cooperativa(int codigo, string nome, Municipio municipio)
        {
            Codigo = codigo;
            Nome = nome;
            Municipio = municipio;
        }

        public override bool Equals(object obj)
        {
            return obj is Cooperativa cooperativa &&
                   Codigo == cooperativa.Codigo;
        }

        public override int GetHashCode()
        {
            return 11 + Codigo.GetHashCode();
        }
    }
}