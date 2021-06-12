using System;
using System.Linq;

namespace ConsoleAppValorVenda
{
    public static class DescontoServico
    {
        private static Func<Conceito, bool> FiltrarConceito(VendaItem vendaItem)
        {
            return (conceito) =>
                conceito.Equals(vendaItem.Venda.Cooperado.Conceito);
        }

        public static Conceito BuscarConceito(this VendaItem vendaItem)
        {
            return ConceitoRepositorio.Conceitos.FirstOrDefault(FiltrarConceito(vendaItem));
        }

        public static void CalcularValorDesconto(this VendaItem vendaItem, Conceito conceito)
        {
            var qtdeGrupos = vendaItem.Venda.Itens
                .Select(item => item.Produto.Grupo)
                .GroupBy(grup => grup.Codigo)
                .Select(s => s.Key)
                .Count();

            var percDesconto = conceito.PercDesconto;

            if (qtdeGrupos >= 1 && qtdeGrupos <= 5)
            {
                percDesconto += qtdeGrupos;
            }

            vendaItem.ValorDesconto = 
                percDesconto * vendaItem.ValorBruto / 100;
            
            vendaItem.ValorLiquido = 
                vendaItem.ValorBruto - vendaItem.ValorDesconto;
        }
    }
}