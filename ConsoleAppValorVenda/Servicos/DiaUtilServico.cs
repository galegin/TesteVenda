using System;
using System.Linq;

namespace ConsoleAppValorVenda
{
    public static class DiaUtilServico
    {
        public static int CalcularNumeroDiasUteis(this FormaPagto formaPagto, DateTime dataBase)
        {
            var numeroDiasUteis = 0;
            var numeroMaiorParcela = formaPagto.Parcelas.Max(x => x.NumeroDias);
            var dataUltimaParcela = dataBase.AddDays(numeroMaiorParcela);
            
            for (var dataAux = dataBase; dataAux <= dataUltimaParcela; )
            {
                if (dataAux.IndDiaUtil())
                {
                    numeroDiasUteis++;
                }

                dataAux = dataAux.AddDays(1);
            }

            return numeroDiasUteis;
        }

        public static bool IndDiaUtil(this DateTime dateTime)
        {
            return dateTime.DayOfWeek == DayOfWeek.Saturday
                | dateTime.DayOfWeek == DayOfWeek.Sunday;
        }
    }
}