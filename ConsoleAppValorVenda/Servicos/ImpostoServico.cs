using System;
using System.Linq;

namespace ConsoleAppValorVenda
{
    public static class ImpostoServico
    {
        private static Func<RegraFiscal, bool> FiltrarRegraFiscal(VendaItem vendaItem)
        {
            return (regra) =>
                regra.Finalidade.Equals(vendaItem.Venda.Finalidade) &&
                regra.Grupo.Equals(vendaItem.Produto.Grupo) &&
                regra.UfOrigem.Equals(vendaItem.Venda.Cooperativa.Municipio.Uf) &&
                regra.UfConsumo.Equals(vendaItem.Venda.Cooperado.Municipio.Uf) &&
                regra.TipoPessoa.Equals(vendaItem.Venda.Cooperado.TipoPessoa);
        }

        public static RegraFiscal BuscarRegraFiscal(this VendaItem vendaItem)
        {
            return RegraFiscalRepositorio.RegraFiscals.FirstOrDefault(FiltrarRegraFiscal(vendaItem));
        }

        public static void CalcularValorImposto(this VendaItem vendaItem, RegraFiscal regraFiscal)
        {
            if (regraFiscal.IndIsento)
                return;

            vendaItem.ValorImposto = 
                vendaItem.ValorLiquido * regraFiscal.PercImposto / 100;
        }
    }
}