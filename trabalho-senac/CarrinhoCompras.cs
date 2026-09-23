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
    private int _idCarrinho;
    private string _idCliente;
    private List<ItemCarrinho> itens;

    public int IdCarrinho => _idCarrinho;

        
}
