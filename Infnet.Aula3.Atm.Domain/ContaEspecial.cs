using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.Aula3.Atm.Domain
{
    public class ContaEspecial : Conta
    {
        private double _limiteUtilizado = 0;

        public double Limite { get; set; }
        
        public double SaldoIncluindoLimite()
        {
            return (base.Saldo() + (Limite - _limiteUtilizado));
        }

        public override double Saque(double valor)
        {
            var currentSaldo = base.Saldo();
            if (currentSaldo >= valor)
                return base.Saque(valor);
            else if (currentSaldo <= valor && currentSaldo > 0)
            {
                base.Saque(currentSaldo);
                RegistrarSaque(valor - currentSaldo);
                _limiteUtilizado += valor;
                return valor;
            }
            else if (currentSaldo <= 0 && SaldoIncluindoLimite() >= valor)
            {
                RegistrarSaque(valor);
                return valor;
            }
            else
            {
                throw new Exception("Saldo não suficiente.");
            }
        }
    }
}
