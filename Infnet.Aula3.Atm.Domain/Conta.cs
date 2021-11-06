using System;
using System.Collections.Generic;

namespace Infnet.Aula3.Atm.Domain
{
    public class Conta
    {
        private static readonly int _numero = 123;
        private static readonly int _pin = 12345;

        public int Numero { get => _numero; }
        public virtual List<Transacao> Transacoes { get; } = new();

        public double Saldo()
        {
            double saldo = 0;
            Transacoes.ForEach(t =>
            {
                saldo += (t.Tipo == TipoDeTransacao.Entrada) ? t.Valor : -t.Valor;
            });

            return saldo;
        }

        public void Deposito(double valor)
        {
            Transacoes.Add(new Transacao()
            {
                Data = DateTime.Now,
                Tipo = TipoDeTransacao.Entrada,
                Valor = valor
            });
        }

        public double Saque(double valor)
        {
            if(Saldo() >= valor)
            {
                Transacoes.Add(new Transacao()
                {
                    Data = DateTime.Now,
                    Tipo = TipoDeTransacao.Saida,
                    Valor = valor
                });
            }
            else
            {
                throw new Exception("Saldo insuficiente para este saque.");
            }

            return valor;
        }



        public bool IsValid(int numeroDeConta, int pin)
        {
            return (_numero == numeroDeConta && _pin == pin);
        }
    }
}
