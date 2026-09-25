using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trabalho_senac;

public enum StatusCarrinho
{
    Aberto,
    Processando,
    Fechado,
    Cancelado
}

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

    public CarrinhoCompras(int idcarrinho, string idcliente, CupomDesconto? cupom)
    {
        this._idCarrinho = idcarrinho;
        this._idCliente = idcliente;
        this._itens = new List<ItemCarrinho>();
        this._status = StatusCarrinho.Aberto;
        this._valorTotal = 0;
        this._cupom = cupom;
    }

    public void AdicionarItem(ItemCarrinho item)
    {
        var itemExistente = BuscarItem(item.IdProduto);

        if (item.Quantidade <= 0)
        {
            Console.WriteLine("Erro: quantidade deve ser maior que zero");
        }
        
        if(itemExistente == null)
        {
            _itens.Add(item);
        }
        else
        {
            itemExistente.AtualizarQuantidade(item.Quantidade);
        }
    }

    public bool RemoverItem(int idProduto)
    {
        var item = BuscarItem(idProduto);

        if (item != null)
            return this._itens.Remove(item);

        Console.WriteLine("Error: Item não encontrado no carrinho!");
        return false;
    }

    public ItemCarrinho? BuscarItem(int idProduto)
    {
        return this._itens.FirstOrDefault(item => item.IdProduto == idProduto);
    }

    public bool AplicarCupom(CupomDesconto cupom)
    {
        if (cupom != null && cupom.ValidarCupom(this._valorTotal) == true)
        {
            this._cupom = cupom;
            return true;
        }
        return false;
    }

    public double CalcularTotal()
    {
        double soma = 0;

        foreach (var item in this._itens)
        {
            if(item.Quantidade == 0)
            {
                int idProduto = item.IdProduto;
                RemoverItem(idProduto);
            }
            soma += item.CalcularSubtotal();
        }

        if (this._cupom != null && this._cupom.ValidarCupom(soma))
        {
            double desconto = soma * (this._cupom.PercentualDesconto / 100.0);
            soma -= desconto;
            
        }

        this._valorTotal = soma;
        return this._valorTotal;
    }

    public bool FinalizarCompra()
    {
        if (this._status == StatusCarrinho.Aberto)
        {
            this._status = StatusCarrinho.Fechado;
            return true;
        }

        Console.WriteLine("Erro! A compra não pode ser finalizada.");
        this._status = StatusCarrinho.Cancelado;
        return false;
    }

}
