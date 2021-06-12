namespace ConsoleAppValorVenda
{
    public class Finalidade
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }

        public Finalidade(int codigo, string descricao)
        {
            Codigo = codigo;
            Descricao = descricao;
        }

        public override bool Equals(object obj)
        {
            return obj is Finalidade finalidade &&
                   Codigo == finalidade.Codigo;
        }

        public override int GetHashCode()
        {
            return 11 + Codigo.GetHashCode();
        }
    }
}