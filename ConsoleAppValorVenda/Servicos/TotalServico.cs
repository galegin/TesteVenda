using System.Linq;

namespace ConsoleAppValorVenda
{
    public static class TotalServico
    {
        public static void TotalizarVenda(this Venda venda)
        {
            venda.ValorProduto = venda.Itens.Sum(x => x.ValorLiquido);
            venda.ValorDesconto = venda.Itens.Sum(x => x.ValorDesconto);
            venda.ValorImposto = venda.Itens.Sum(x => x.ValorImposto);
            venda.ValorTotal = venda.Itens.Sum(x => x.ValorLiquido + x.ValorImposto) + venda.ValorAcrescimo;
        }
    }
}