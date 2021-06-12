namespace ConsoleAppValorVenda
{
    public class FormaPagtoRepositorio
    {
        public static FormaPagtoParcela[] FormaPagtoParcelasAVista =
        {
            new FormaPagtoParcela(1, 0),
        };

        public static FormaPagto FormaPagtoAVista =
            new FormaPagto(1, "A Vista", FormaPagtoParcelasAVista);

        public static FormaPagtoParcela[] FormaPagtoParcelasAPrazo =
        {
            new FormaPagtoParcela(1, 30),
            new FormaPagtoParcela(2, 60),
            new FormaPagtoParcela(3, 90),
        };

        public static FormaPagto FormaPagtoAPrazo =
            new FormaPagto(1, "A Prazo", FormaPagtoParcelasAPrazo);
    }
}