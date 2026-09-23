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
    private CupomDesconto _cupom;

    //Propriedades públicas
    public int IdCarrinho => _idCarrinho;
    public string IdCliente => _idCliente;
    public IReadOnlyList<ItemCarrinho> Itens => _itens.AsReadOnly();
    public StatusCarrinho Status => _status;
    public double ValorTotal => _valorTotal;
    public CupomDesconto Cupom => _cupom;

    public void AdicionarItem(ItemCarrinho item)
    {
        if (!_itens.Contains(item))
        {
            this._itens.Add(item);
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
            CalcularTotal();
            return true;
        }
        return false;
    }

    public double CalcularTotal()
    {
        double soma = 0;

        foreach (var item in this._itens)
        {
            soma += item.CalcularSubTotal();
        }

        //Falta a lógica do desconto do cupom
        if (this._cupom != null && this._cupom.ValidarCupom(soma))
        {
            double desconto = soma * (this._cupom.PercentualDesconto / 100.0);
            soma -= desconto;
        }

        this._valorTotal = soma;
        return this._valorTotal;
    }


}
