using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trabalho_senac
{
    internal class ItemCarrinho
    {
        private int _idProduto;
        private string _nomeProduto;
        private double _precoUnitario;
        private int _quantidade;

        public int IdProduto => _idProduto;
        public string NomeProduto => _nomeProduto;
        public double PrecoUnitario => _precoUnitario;
        public int Quantidade => _quantidade;

        public void AtualizarQuantidade(int novaQuantidade)
        {
            if (novaQuantidade <= 0)
            {
                return;
            }

            _quantidade = novaQuantidade;
        }
        
        public double CalcularSubtotal()
        {
            return _precoUnitario * _quantidade;
        }
  
    }
    
        
            
        

}
