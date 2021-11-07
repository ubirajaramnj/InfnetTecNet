using System;
using System.Collections.Generic;

namespace Infnet.Aula3.Atm.Domain
{
    public interface IConta
    {
        int Numero { get; }
        List<Transacao> Transacoes { get; }

        void Deposito(double valor);
        Extrato Extrato(DateTime dataInicial, DateTime dataFinal);
        bool IsValid(int numeroDeConta, int pin);
        double Saldo();
        double Saque(double valor);
    }
}