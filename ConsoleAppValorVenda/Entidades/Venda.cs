using System;
using System.Collections.Generic;

namespace ConsoleAppValorVenda
{
    public class Venda
    {
        public int Codigo { get; set; }
        public Cooperativa Cooperativa { get; set; }
        public Cooperado Cooperado { get; set; }
        public Finalidade Finalidade { get; set; }
        public FormaPagto FormaPagto { get; set; }
        public DateTime Data { get; set; }
        public double ValorProduto { get; set; }
        public double ValorDesconto { get; set; }
        public double ValorAcrescimo { get; set; }
        public double ValorImposto { get; set; }
        public double ValorTotal { get; set; }
        public List<VendaItem> Itens { get; set; }
        public List<VendaPagto> Pagtos { get; set; }

        public Venda(int codigo, Cooperativa cooperativa, Cooperado cooperado, Finalidade finalidade, FormaPagto formaPagto,
            DateTime data, 
            double valorProduto = 0, double valorDesconto = 0, double valorAcrescimo = 0, double valorImposto = 0, double valorTotal = 0, 
            List<VendaItem> itens = null, List<VendaPagto> pagtos = null)
        {
            Codigo = codigo;
            Cooperativa = cooperativa;
            Cooperado = cooperado;
            Finalidade = finalidade;
            FormaPagto = formaPagto;
            Data = data;
            ValorProduto = valorProduto;
            ValorDesconto = valorDesconto;
            ValorAcrescimo = valorAcrescimo;
            ValorImposto = valorImposto;
            ValorTotal = valorTotal;
            Itens = itens ?? new List<VendaItem>();
            Pagtos = pagtos ?? new List<VendaPagto>();
        }

        public override bool Equals(object obj)
        {
            return obj is Venda venda &&
                   Codigo == venda.Codigo;
        }

        public override int GetHashCode()
        {
            return 11 + Codigo.GetHashCode();
        }
    }

    public class VendaItem
    {
        public Venda Venda { get; set; }
        public Produto Produto { get; set; }
        public double Qtde { get; set; }
        public double ValorUnitario { get; set; }
        public double ValorBruto { get; set; }
        public double ValorDesconto { get; set; }
        public double ValorLiquido { get; set; }
        public double ValorImposto { get; set; }

        public VendaItem(Venda venda, Produto produto, double qtde = 1, 
            double valorUnitario = 0, double valorDesconto = 0, double valorLiquido = 0, double valorImposto = 0)
        {
            Venda = venda;
            Produto = produto;
            Qtde = qtde;
            ValorUnitario = valorUnitario;
            ValorBruto = valorUnitario * qtde;
            ValorDesconto = valorDesconto;
            ValorLiquido = valorLiquido;
            ValorImposto = valorImposto;
        }

        public override bool Equals(object obj)
        {
            return obj is VendaItem item &&
                   EqualityComparer<Venda>.Default.Equals(Venda, item.Venda) &&
                   EqualityComparer<Produto>.Default.Equals(Produto, item.Produto);
        }

        public override int GetHashCode()
        {
            int hashCode = 11;
            hashCode = hashCode * 11 + EqualityComparer<Venda>.Default.GetHashCode(Venda);
            hashCode = hashCode * 11 + EqualityComparer<Produto>.Default.GetHashCode(Produto);
            return hashCode;
        }
    }

    public class VendaPagto
    {
        public int NumParcela { get; set; }
        public DateTime DataVencto { get; set; }
        public double ValorParcela { get; set; }

        public VendaPagto(int numParcela, DateTime dataVencto, double valorParcela)
        {
            NumParcela = numParcela;
            DataVencto = dataVencto;
            ValorParcela = valorParcela;
        }
    }
}