using System;
using System.Linq;

namespace ConsoleAppValorVenda
{
    public static class AcrescimoServico
    {
        public static void CalcularValorAcrescimo(this Venda venda)
        {
            //Nas vendas a prazo é acrescentado 0,05 % de juros ao dia conforme a seguinte fórmula:
            //Valor de Juros = Valor principal * ((  (1 + (taxa de juros/ 100)) ^nro de dias) – 1), onde nro de dias é
            //a quantidade de dias úteis entre a data de compra e data de vencimento;

            var taxaJuros = 0.05;
            var numeroDiasUteis = venda.FormaPagto.CalcularNumeroDiasUteis(venda.Data);
            var prazoMedioPagto = numeroDiasUteis / venda.FormaPagto.Parcelas.Count();
            var valorTotalLiquido = venda.Itens.Sum(x => x.ValorLiquido);
            var valorTotalAcrescimo = valorTotalLiquido * (Math.Pow(1 + (taxaJuros / 100), prazoMedioPagto) - 1);
            venda.ValorAcrescimo = Math.Round(valorTotalAcrescimo, 2);
        }
    }
}