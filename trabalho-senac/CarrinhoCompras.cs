using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trabalho_senac;

//Enum com opções de status para o carrinho
public enum StatusCarrinho
{
    Aberto,
    Processando,
    Fechado,
    Cancelado
}

//Enum com opções de fretes
public enum TipoFrete
{
    Normal,
    Expresso,
    RetiradaLoja,
    Gratis
}

internal class CarrinhoCompras
{
    //Propriedades privadas
    private int _idCarrinho;
    private string _idCliente;
    private List<ItemCarrinho> _itens;
    private StatusCarrinho _status;
    private double _valorTotal;
    private CupomDesconto? _cupom;

    //Propriedades públicas
    public int IdCarrinho => _idCarrinho;
    public string IdCliente => _idCliente;
    public IReadOnlyList<ItemCarrinho> Itens => _itens.AsReadOnly();
    public StatusCarrinho Status => _status;
    public double ValorTotal => _valorTotal;
    public CupomDesconto? Cupom => _cupom;

    //Construtor da Classe
    public CarrinhoCompras(int idcarrinho, string idcliente, CupomDesconto? cupom)
    {
        this._idCarrinho = idcarrinho;
        this._idCliente = idcliente;
        this._itens = new List<ItemCarrinho>();
        this._status = StatusCarrinho.Aberto;
        this._valorTotal = 0;
        this._cupom = cupom;
    }

    //Método para Adicionar itens/produtos ao nosso carrinho
    public void AdicionarItem(ItemCarrinho item)
    {
        //Se o item já estiver no carrinho, guardamos ele nessa variavel
        var itemExistente = BuscarItem(item.IdProduto);

        //Condição que verifica se a quantidade do item é menor ou igual a zero
        if (item.Quantidade <= 0)
        {
            //Se for menor ou igual, não adicionamos o item no carrinho, mostramos uma mensagem e só retornamos.
            Console.WriteLine("Erro: quantidade deve ser maior que zero");
            return;
        }
        
        //Condição que verifica se a variavel itemExistente é igual a null
        if(itemExistente == null)
        {
            //Se for verdadeiro, adicionamos o item no carrinho
            _itens.Add(item);
        }
        else
        {
            //Caso contrario, o item já existe no carrinho, sendo assim, atualizamos sua quantidade
            itemExistente.AtualizarQuantidade(item.Quantidade);
        }
    }

    //Método para remover itens do nosso carrinho via id do produto
    public bool RemoverItem(int idProduto)
    {
        //variavel guarda o item caso ele exista, caso contrario, ele vai ser igual a null
        //Utiliza o método que Busca itens por id
        var item = BuscarItem(idProduto);

        //Condição que verifica se a variavel 'item' é diferente de null
        if (item != null)
            //Se for, remove o item da lista e retorna.
            return this._itens.Remove(item);

        //Caso não cumpra com os requisitos da condição, retornamos false.
        Console.WriteLine("Error: Item não encontrado no carrinho!");
        return false;
    }

    //Método para buscar itens em nosso carrrinho
    public ItemCarrinho? BuscarItem(int idProduto)
    {
        /*FirstOrDefault -> Ele busca o primeiro item dentro da lista que possui o IdProduto igual ao informado.
         ( Se encontrar, retorna o objeto --- Se não encontrar, retorna null ) */
        return this._itens.FirstOrDefault(item => item.IdProduto == idProduto);
    }

    //Método para aplicar cupom de desconto no valor total do carrinho
    public bool AplicarCupom(CupomDesconto cupom)
    {
        // variavel que recebe o subtotal do item/itens.
        // Se houver mais que 1 item, ele soma os subtotais e guarda o na variavel.
        double subtotal = this._itens.Sum(item => item.CalcularSubtotal());

        //Se cupom for diferente de null E se o cupom for válido.
        if (cupom != null && cupom.ValidarCupom(subtotal) == true)
        {
            this._cupom = cupom;
            return true;
        }
        return false;
    }

    //Método para Calcular o valor Total do carrinho
    public double CalcularTotal()
    {
        //variavel que guarda o valor total
        double valortot = 0;

        //Laço de repetição para Calcular o subtotal de cada item da lista
        foreach (ItemCarrinho item in this._itens)
        {
            valortot += item.CalcularSubtotal();
        }

        //Se cupom for diferente de null E cupom for válido
        if (this._cupom != null && this._cupom.ValidarCupom(valortot) == true)
        {
            //variavel que recebe o valor que deve ser subtraido do valor total
            double desconto = valortot * (this._cupom.PercentualDesconto / 100.0);
            //Aplicando o desconto no valortotal
            valortot -= desconto;
            
        }

        //o atributo privado da classe '_valorTotal' recebe o valor total do método após os calculos.
        this._valorTotal = valortot;
        //retornamos o valortotal
        return this._valorTotal;
    }

    //Método para Finalizar a compra/Carrinho
    public bool FinalizarCompra()
    {
        //Condição que verifica se o status do carrinho é igual a 'Aberto'
        if (this._status == StatusCarrinho.Aberto)
        {
            //Atualiza o status do carrinho para 'Fechado'
            this._status = StatusCarrinho.Fechado;
            return true;
        }

        //Condição que verifica se o status do carrinho é igual a 'Fechado'
        if(this._status == StatusCarrinho.Fechado)
        {
            Console.WriteLine("Aviso: O carrinho ja está fechado!!");
        }
        else
        {
            //Caso o carrinho esteja com algum status diferente dos solicitados nos casos de teste
            Console.WriteLine($"Erro: não é possível finalizar um carrinho com status {_status}");
        } 
        return false;
    }
}