using System.Collections.Generic;

namespace ConsoleAppValorVenda
{
    public class RegraFiscal
    {
        public Finalidade Finalidade { get; set; }
        public Grupo Grupo { get; set; }
        public string UfOrigem { get; set; }
        public string UfConsumo { get; set; }
        public PessoaTipo TipoPessoa { get; set; }
        public double PercImposto { get; set; }
        public bool IndIsento { get; set; }

        public RegraFiscal(Finalidade finalidade, Grupo grupo, string ufOrigem, string ufConsumo, PessoaTipo tipoPessoa, double percImposto, bool indIsento)
        {
            Finalidade = finalidade;
            Grupo = grupo;
            UfOrigem = ufOrigem;
            UfConsumo = ufConsumo;
            TipoPessoa = tipoPessoa;
            PercImposto = percImposto;
            IndIsento = indIsento;
        }

        public override bool Equals(object obj)
        {
            return obj is RegraFiscal fiscal &&
                   EqualityComparer<Finalidade>.Default.Equals(Finalidade, fiscal.Finalidade) &&
                   EqualityComparer<Grupo>.Default.Equals(Grupo, fiscal.Grupo) &&
                   UfOrigem == fiscal.UfOrigem &&
                   UfConsumo == fiscal.UfConsumo &&
                   TipoPessoa == fiscal.TipoPessoa;
        }

        public override int GetHashCode()
        {
            int hashCode = 11;
            hashCode = hashCode * 11 + Finalidade.GetHashCode();
            hashCode = hashCode * 11 + Grupo.GetHashCode();
            hashCode = hashCode * 11 + UfOrigem?.GetHashCode() ?? 0;
            hashCode = hashCode * 11 + UfConsumo?.GetHashCode() ?? 0;
            hashCode = hashCode * 11 + TipoPessoa.GetHashCode();
            return hashCode;
        }
    }
}