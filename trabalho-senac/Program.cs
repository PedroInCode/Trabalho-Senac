using System.ComponentModel.DataAnnotations;
using trabalho_senac;

internal class Program
{

    static void Main(string[] args)
    {
        CupomDesconto cupom1 = new CupomDesconto(
            "123456",
            10,
            50
            );


        CupomDesconto cupom2 = new CupomDesconto(
            "100",
            15,
            100
            );

        CupomDesconto cupom = new CupomDesconto(
            "200",
            20,
            200
            );
    }
}

    
