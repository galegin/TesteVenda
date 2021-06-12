using System;

namespace ConsoleAppValorVenda
{
    public static class PagtoServico
    {
        public static void GerarPagtos(this Venda venda)
        {
            venda.Pagtos.Clear();

            var qtdeParcela = venda.FormaPagto.Parcelas.Count;
            var valorParcela = Math.Round(venda.ValorTotal / qtdeParcela, 2);
            var valorResto = Math.Round(venda.ValorTotal - (valorParcela * qtdeParcela), 2);

            foreach (var parcela in venda.FormaPagto.Parcelas)
            {
                var dataVencto = venda.Data.AddDays(parcela.NumeroDias);
                var vendaPagto = new VendaPagto(parcela.SeqParcela, dataVencto, Math.Round(valorParcela, 2));
                venda.Pagtos.Add(vendaPagto);

                if (parcela.SeqParcela == 1)
                {
                    vendaPagto.ValorParcela = Math.Round(vendaPagto.ValorParcela + valorResto, 2);
                    valorResto = 0;
                }
            }
        }
    }
}