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

}
