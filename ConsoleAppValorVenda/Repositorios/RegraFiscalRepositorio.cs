using System.Collections.Generic;

namespace ConsoleAppValorVenda
{
    public static class RegraFiscalRepositorio
    {
        private static Dictionary<string, double> _ufs =
            new Dictionary<string, double>
            {
                { "PR", 18 },
                { "SC", 12 },
                { "MS", 0 },
            };

        public static RegraFiscal[] RegraFiscals;

        static RegraFiscalRepositorio()
        {
            RegraFiscals = GetRegraFiscals();
        }

        private static RegraFiscal[] GetRegraFiscals()
        {
            var regraFiscais = new List<RegraFiscal>();

            foreach (var finalidade in FinalidadeRespositorio.Finalidades)
            {
                foreach (var grupos in GrupoRepositorio.Grupos)
                {
                    foreach (var uf in _ufs)
                    {
                        var regraFiscal = new RegraFiscal(finalidade, grupos, uf.Key, uf.Key, PessoaTipo.Fisica, uf.Value, false);
                        regraFiscais.Add(regraFiscal);
                    }
                }
            }

            return regraFiscais.ToArray();
        }
    }
}