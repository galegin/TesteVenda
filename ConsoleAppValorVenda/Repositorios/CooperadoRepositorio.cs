using System;

namespace ConsoleAppValorVenda
{
    public static class CooperadoRepositorio
    {
        public static Cooperado[] Cooperados =
        {
            new CooperadoFisica(1, "Jose", "Rua", MunicipioRepositorio.Municipios[0], ConceitoRepositorio.Conceitos[0], 
                "11122233344", "67778889", EstCivilTipo.Casado, new DateTime(1980, 1, 1)),
            new CooperadoJuridica(1, "Jose", "Rua", MunicipioRepositorio.Municipios[0], ConceitoRepositorio.Conceitos[0], 
                new DateTime(1980, 1, 1), null),
        };
    }
}