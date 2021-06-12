using System.Collections.Generic;
using System.Linq;

namespace ConsoleAppValorVenda
{
    public class FormaPagto
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public List<FormaPagtoParcela> Parcelas { get; set; }

        public FormaPagto(int codigo, string descricao, FormaPagtoParcela[] parcelas = null)
        {
            Codigo = codigo;
            Descricao = descricao;
            Parcelas = parcelas?.ToList() ?? new List<FormaPagtoParcela>();
        }

        public override bool Equals(object obj)
        {
            return obj is FormaPagto pagto &&
                   Codigo == pagto.Codigo;
        }

        public override int GetHashCode()
        {
            return 11 + Codigo.GetHashCode();
        }
    }

    public class FormaPagtoParcela
    {
        public int SeqParcela { get; set; }
        public int NumeroDias { get; set; }

        public FormaPagtoParcela(int seqParcela, int numeroDias)
        {
            SeqParcela = seqParcela;
            NumeroDias = numeroDias;
        }

        public override bool Equals(object obj)
        {
            return obj is FormaPagtoParcela parcela &&
                   SeqParcela == parcela.SeqParcela;
        }

        public override int GetHashCode()
        {
            return 11 + SeqParcela.GetHashCode();
        }
    }
}