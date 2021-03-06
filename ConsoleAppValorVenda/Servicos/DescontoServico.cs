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

        private const int _qtdeMaximaDescontoGrupo = 5;

        public static void CalcularValorDesconto(this VendaItem vendaItem, Conceito conceito)
        {
            var percDesconto = conceito.PercDesconto;

            var percDescontoPorQtdeGrupos = vendaItem.Venda.Itens
                .Select(item => item.Produto.Grupo)
                .GroupBy(grup => grup.Codigo)
                .Select(s => s.Key)
                .Count();

            if (percDescontoPorQtdeGrupos > _qtdeMaximaDescontoGrupo)
            {
                percDescontoPorQtdeGrupos = _qtdeMaximaDescontoGrupo;
            }

            percDesconto += percDescontoPorQtdeGrupos;

            vendaItem.ValorDesconto = 
                percDesconto * vendaItem.ValorBruto / 100;
            
            vendaItem.ValorLiquido = 
                vendaItem.ValorBruto - vendaItem.ValorDesconto;
        }
    }
}