using System;

namespace ConsoleAppValorVenda
{

    // Desenvolva um algoritmo para calcular o valor de venda de cada item e o valor total da venda.

    class Program
    {
        static void Main(string[] args)
        {
            var venda = VendaRepositorio.GerarVendaCapa();

            var vendaServico = new VendaServico(venda);
            
            foreach (var produto in ProdutoRepositorio.Produtos)
            {
                vendaServico.AdicionarItem(produto);
            }

            vendaServico.Totalizar();

            Console.ReadLine();
        }
    }
}
