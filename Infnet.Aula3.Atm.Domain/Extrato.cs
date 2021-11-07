using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.Aula3.Atm.Domain
{
    public class Extrato
    {
        public Extrato(int numeroDaConta, double saldo, List<Transacao> transacoes)
        {
            NumeroDaConta = numeroDaConta;
            Saldo = saldo;
            Transacoes = transacoes;
            Data = DateTime.Now;
        }

        public int NumeroDaConta { get; internal set; }

        public DateTime Data { get; internal set; }

        public double Saldo { get; internal set; }

        public List<Transacao> Transacoes { get; internal set; }
    }
}
