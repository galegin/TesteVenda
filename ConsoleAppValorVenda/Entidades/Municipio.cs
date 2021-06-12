namespace ConsoleAppValorVenda
{
    public class Municipio
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Uf { get; set; }

        public Municipio(int codigo, string nome, string uf)
        {
            Codigo = codigo;
            Nome = nome;
            Uf = uf;
        }

        public override bool Equals(object obj)
        {
            return obj is Municipio municipio &&
                   Codigo == municipio.Codigo;
        }

        public override int GetHashCode()
        {
            return 11 + Codigo.GetHashCode();
        }
    }
}