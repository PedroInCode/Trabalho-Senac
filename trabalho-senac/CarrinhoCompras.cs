using System;
using System.Collections.Generic;
using System.Linq;

namespace trabalho_senac;

// Status possíveis do carrinho
public enum StatusCarrinho
{
    Aberto,
    Processando,
    Fechado,
    Cancelado
}

// Tipos de frete disponíveis
public enum TipoFrete
{
    Normal,
    Expresso,
    RetiradaLoja,
    Gratis
}

internal class CarrinhoCompras
{
    // Atributos privados
    private int _idCarrinho;
    private string _idCliente;
    private List<ItemCarrinho> _itens;
    private StatusCarrinho _status;
    private double _valorTotal;
    private CupomDesconto? _cupom;

    // Propriedades somente leitura
    public int IdCarrinho => _idCarrinho;
    public string IdCliente => _idCliente;
    public IReadOnlyList<ItemCarrinho> Itens => _itens.AsReadOnly();
    public StatusCarrinho Status => _status;
    public double ValorTotal => _valorTotal;
    public CupomDesconto? Cupom => _cupom;

    // Inicializa o carrinho com status aberto e lista vazia
    public CarrinhoCompras(int idcarrinho, string idcliente, CupomDesconto? cupom)
    {
        _idCarrinho = idcarrinho;
        _idCliente = idcliente;
        _itens = new List<ItemCarrinho>();
        _status = StatusCarrinho.Aberto;
        _valorTotal = 0;
        _cupom = cupom;
    }

    // Adiciona um item ao carrinho
    public void AdicionarItem(ItemCarrinho item)
    {
        // Procura se o produto já existe no carrinho
        var itemExistente = BuscarItem(item.IdProduto);

        // Não permite quantidade inválida
        if (item.Quantidade <= 0)
        {
            Console.WriteLine("Erro: quantidade deve ser maior que zero");
            return;
        }

        // Se o produto não existir, adiciona à lista
        if (itemExistente == null)
        {
            _itens.Add(item);
        }
        else
        {
            // Caso já exista, apenas soma a quantidade
            itemExistente.AtualizarQuantidade(item.Quantidade);
        }
    }

    // Remove um produto pelo ID
    public bool RemoverItem(int idProduto)
    {
        // Busca o item na lista
        var item = BuscarItem(idProduto);

        if (item != null)
            return _itens.Remove(item);

        Console.WriteLine("Error: Item não encontrado no carrinho!");
        return false;
    }

    // Retorna o primeiro item com o ID informado ou null
    public ItemCarrinho? BuscarItem(int idProduto)
    {
        return _itens.FirstOrDefault(item => item.IdProduto == idProduto);
    }

    // Aplica um cupom caso ele seja válido para o subtotal atual
    public bool AplicarCupom(CupomDesconto cupom)
    {
        // Soma o subtotal de todos os itens
        double subtotal = _itens.Sum(item => item.CalcularSubtotal());

        if (cupom != null && cupom.ValidarCupom(subtotal))
        {
            _cupom = cupom;
            return true;
        }

        return false;
    }

    // Calcula o valor total do carrinho
    public double CalcularTotal()
    {
        double valortot = 0;

        // Soma o subtotal de cada item
        foreach (ItemCarrinho item in _itens)
        {
            valortot += item.CalcularSubtotal();
        }

        // Aplica o desconto do cupom, se existir e for válido
        if (_cupom != null && _cupom.ValidarCupom(valortot))
        {
            double desconto = valortot * (_cupom.PercentualDesconto / 100.0);
            valortot -= desconto;
        }

        // Atualiza o valor total armazenado no carrinho
        _valorTotal = valortot;
        return _valorTotal;
    }

    // Finaliza a compra alterando o status do carrinho
    public bool FinalizarCompra()
    {
        // Só é possível finalizar se o carrinho estiver aberto
        if (_status == StatusCarrinho.Aberto)
        {
            _status = StatusCarrinho.Fechado;
            return true;
        }

        // Evita finalizar um carrinho já fechado
        if (_status == StatusCarrinho.Fechado)
        {
            Console.WriteLine("Aviso: O carrinho ja está fechado!!");
        }
        else
        {
            Console.WriteLine($"Erro: não é possível finalizar um carrinho com status {_status}");
        }

        return false;
    }
}