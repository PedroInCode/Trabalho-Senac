using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trabalho_senac;

internal class CupomDesconto
{
    private string _codigo;
    private double _percentualDesconto;
    private double _valorMinimo ;

    public string Codigo => _codigo;
    public double PercentualDesconto => _percentualDesconto;
    public double ValorMinimoCompra => _valorMinimo;

    public CupomDesconto(string codigo, double percentualDesconto, double valorMinimoCompra)
    {
        _codigo = codigo;
        _percentualDesconto = percentualDesconto;
        _valorMinimo = valorMinimoCompra;
    }

    public bool ValidarCupom(double subTotal)
    {   
        if (subTotal >= _valorMinimo)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
        
    
    























}




