using System.ComponentModel.DataAnnotations;
using trabalho_senac;

internal class Program
{
    static void Main(string[] args)
    {
        //Execução de Testes:

        Console.WriteLine("-=-=-=-=-=- EXECUÇÃO DOS CASOS DE TESTE -=-=-=-=-=-\n");

        // Metodo auxiliar para exibir o estado para os casos de testes
        void ExibirEstadoCarrinho(string casoDeTeste, CarrinhoCompras carrinho)
        {
            Console.WriteLine($"--- [{casoDeTeste}] ESTADO DO CARRINHO ---");
            Console.WriteLine($"Quantidade de itens: {carrinho.Itens.Count}");
            Console.WriteLine($"Status: {carrinho.Status}");
            Console.WriteLine($"Valor Total: R${carrinho.CalcularTotal():F2}");
            Console.WriteLine("------------------------------------------\n");
        }


        /*
         CT1.01 : Carrinho aberto; item com quantidade 0.
         Ação : Tentar adicionar o item.
         Resultado esperado : Operação rejeitada; a lista permanece sem o item.
        */ 

        Console.WriteLine("Executando CT1.01:");
        CarrinhoCompras carrinho1 = new CarrinhoCompras(1, "CLI-001", null);
        ItemCarrinho itemInvalido = new ItemCarrinho(101, "Produto Inválido", 50.0, 0);

        carrinho1.AdicionarItem(itemInvalido);
        ExibirEstadoCarrinho("CT1.01", carrinho1);


        /*
         CT1.02 : Dois itens de R$100,00, cada um com quantidade 1.
         Ação : Calcular o total.
         Resultado esperado : Resultado igual a R$200,00.
        */ 

        Console.WriteLine("Executando CT1.02:");
        CarrinhoCompras carrinho2 = new CarrinhoCompras(2, "CLI-002", null);
        ItemCarrinho itemA = new ItemCarrinho(1, "Item A", 100.0, 1);
        ItemCarrinho itemB = new ItemCarrinho(2, "Item B", 100.0, 1);

        carrinho2.AdicionarItem(itemA);
        carrinho2.AdicionarItem(itemB);

        ExibirEstadoCarrinho("CT1.02", carrinho2);


        /* 
         CT1.03 : Subtotal de R$150,00; cupom com mínimo de R$200,00.
         Ação : Aplicar o cupom.
         Resultado esperado : Retorno de rejeição; nenhum desconto é aplicado.
        */ 

        Console.WriteLine("Executando CT1.03:");
        CarrinhoCompras carrinho3 = new CarrinhoCompras(3, "CLI-003", null);
        ItemCarrinho itemC = new ItemCarrinho(3, "Item C", 150.0, 1); // Subtotal = R$ 150,00
        CupomDesconto cupomAlto = new CupomDesconto("CUPOM200", 10, 200.0); // Mínimo = R$ 200,00

        carrinho3.AdicionarItem(itemC);
        bool aplicou = carrinho3.AplicarCupom(cupomAlto);

        if (!aplicou)
        {
            Console.WriteLine("Aviso: Cupom rejeitado pois o subtotal não atingiu o valor mínimo.");
        }

        ExibirEstadoCarrinho("CT1.03", carrinho3);

        /*
        // CT1.04: Carrinho aberto com itens válidos.
        // Ação: Finalizar a compra.
        // Resultado esperado: Operação aceita; status passa a Fechado.
        */ 
        Console.WriteLine("Executando CT1.04:");
        CarrinhoCompras carrinho4 = new CarrinhoCompras(4, "CLI-004", null);
        ItemCarrinho itemD = new ItemCarrinho(4, "Item D", 80.0, 2);

        carrinho4.AdicionarItem(itemD);
        carrinho4.FinalizarCompra();

        ExibirEstadoCarrinho("CT1.04", carrinho4);
    }
}