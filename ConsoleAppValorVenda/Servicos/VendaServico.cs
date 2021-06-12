using System;

namespace ConsoleAppValorVenda
{
    public class VendaServico
    {
        public Venda Venda { get; private set; }

        public VendaServico(Venda venda)
        {
            Venda = venda;
        }

        public void AdicionarItem(Produto produto, double qtde = 1)
        {
            var vendaItem = new VendaItem
            (
                venda: Venda,
                produto: produto,
                qtde: qtde,
                valorUnitario: produto.ValorVenda
            );

            var regraFiscal = vendaItem.BuscarRegraFiscal();
            if (regraFiscal is null)
                throw new Exception("Regra fiscal não encontrada");

            var conceito = vendaItem.BuscarConceito();
            if (conceito is null)
                throw new Exception("Conceito não encontrado");

            Venda.Itens.Add(vendaItem);

            vendaItem.CalcularValorDesconto(conceito);
                      
            vendaItem.CalcularValorImposto(regraFiscal);
        }

        public void Totalizar()
        {
            Venda.CalcularValorAcrescimo();

            Venda.TotalizarVenda();

            Venda.GerarPagtos();
        }
    }
}