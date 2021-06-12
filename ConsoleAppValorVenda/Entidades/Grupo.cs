namespace ConsoleAppValorVenda
{
    public class Grupo
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }

        public Grupo(int codigo, string descricao)
        {
            Codigo = codigo;
            Descricao = descricao;
        }

        public override bool Equals(object obj)
        {
            return obj is Grupo grupo &&
                   Codigo == grupo.Codigo;
        }

        public override int GetHashCode()
        {
            return 11 + Codigo.GetHashCode();
        }
    }
}