using System;

namespace ConsoleAppValorVenda
{
    public static class VendaRepositorio
    {
        public static Venda GerarVendaCapa()
        {
            return new Venda(
                codigo: 1,
                cooperativa: CooperativaRepositorio.Cooperativas[0],
                cooperado: CooperadoRepositorio.Cooperados[0],
                finalidade: FinalidadeRespositorio.Finalidades[0],
                formaPagto: FormaPagtoRepositorio.FormaPagtoAPrazo,
                data: DateTime.Today
            );
        }
    }
}