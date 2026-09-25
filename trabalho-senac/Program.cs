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
    

       //Testando ITEMCARRINHO BIANCA
    
        //testando items e vendo como funciona o subtotal pra nao perder logica
        //por exemplo no carrinho vai ter o item teclado porem o cliente colocou
        //que quer colocar 5 unidade do teclado , e entao o subtotal do item
        // vai ser 5* 250 = 1250
        ItemCarrinho item1 = new ItemCarrinho(1, "Teclado Gamer", 250.0, 5);
        ItemCarrinho item2 = new ItemCarrinho(2, "Aspirador de pó", 500.0, 2);
        ItemCarrinho item3 = new ItemCarrinho(3, "Placa de vídeo RTX 3050", 1000.0, 1);

        Console.WriteLine(item1.CalcularSubtotal());

        //testando atualizarQuantidade

        ItemCarrinho item4 = new ItemCarrinho(4, "Processador intel i9", 1500.0, 2);
        Console.WriteLine($"produto: {item4.NomeProduto}" );
        Console.WriteLine($"Quantidade: {item4.Quantidade}" );
        Console.WriteLine($"valor unitario: {item4.PrecoUnitario}");

        item4.AtualizarQuantidade(4);

        Console.WriteLine($"Nova quantidade: {item4.Quantidade}");
        Console.WriteLine($"novo subtotal: {item4.CalcularSubtotal()}");

        //se na nova quantidade for menor ou igual a 0 deve dar retorno ou seja muda nada
        // fica no mesmo valor que estava antes

        item1.AtualizarQuantidade(0);
        Console.WriteLine($"Quantidade retornada: {item1.Quantidade}");


    }
}