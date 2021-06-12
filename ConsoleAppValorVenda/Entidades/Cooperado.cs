using System;
using System.Collections.Generic;

namespace ConsoleAppValorVenda
{
    public abstract class Cooperado
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public PessoaTipo TipoPessoa { get; set; }
        public string Endereco { get; set; }
        public Municipio Municipio { get; set; }
        public Conceito Conceito { get; set; }

        protected Cooperado(int codigo, string nome, PessoaTipo tipoPessoa, string endereco, Municipio municipio, Conceito conceito)
        {
            Codigo = codigo;
            Nome = nome;
            TipoPessoa = tipoPessoa;
            Endereco = endereco;
            Municipio = municipio;
            Conceito = conceito;
        }

        public override bool Equals(object obj)
        {
            return obj is Cooperado cooperado &&
                   Codigo == cooperado.Codigo;
        }

        public override int GetHashCode()
        {
            return 11 + Codigo.GetHashCode();
        }
    }

    public class CooperadoFisica : Cooperado
    {
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public EstCivilTipo EstCivil { get; set; }
        public DateTime DataNascto { get; set; }

        public CooperadoFisica(int codigo, string nome, string endereco, Municipio municipio, Conceito conceito,
            string cpf, string rg, EstCivilTipo estCivil, DateTime dataNascto) 
            : base(codigo, nome, PessoaTipo.Fisica, endereco, municipio, conceito)
        {
            Cpf = cpf;
            Rg = rg;
            EstCivil = estCivil;
            DataNascto = dataNascto;
        }
    }

    public class CooperadoJuridica : Cooperado
    {
        public DateTime DataFundacao { get; set; }
        public List<CooperadoSocio> Socios { get; set; }

        public CooperadoJuridica(int codigo, string nome, string endereco, Municipio municipio, Conceito conceito,
            DateTime dataFundacao, List<CooperadoSocio> socios = null) 
            : base(codigo, nome, PessoaTipo.Juridica, endereco, municipio, conceito)
        {
            DataFundacao = dataFundacao;
            Socios = socios ?? new List<CooperadoSocio>();
        }
    }

    public class CooperadoSocio
    {
        public int Sequencia { get; set; }
        public string Nome { get; set; }
        public string Passporte { get; set; }

        public override bool Equals(object obj)
        {
            return obj is CooperadoSocio socio &&
                   Sequencia == socio.Sequencia;
        }

        public override int GetHashCode()
        {
            return 11 + Sequencia.GetHashCode();
        }
    }
}