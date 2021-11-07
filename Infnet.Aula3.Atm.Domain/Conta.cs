using System;
using System.Collections.Generic;
using System.Linq;

namespace Infnet.Aula3.Atm.Domain
{
    public class Conta : IConta
    {

        private static readonly int _numero = 123;
        private static readonly int _pin = 12345;

        public int Numero { get => _numero; }
        public virtual List<Transacao> Transacoes { get; } = new();

        public virtual double Saldo()
        {
            double saldo = 0;
            Transacoes.ForEach(t =>
            {
                saldo += (t.Tipo == TipoDeTransacao.Entrada) ? t.Valor : -t.Valor;
            });

            return saldo;
        }

        public virtual void Deposito(double valor)
        {
            Transacoes.Add(new Transacao()
            {
                Data = DateTime.Now,
                Tipo = TipoDeTransacao.Entrada,
                Valor = valor
            });
        }

        public virtual double Saque(double valor)
        {
            if (Saldo() >= valor)
            {
                RegistrarSaque(valor);
            }
            else
            {
                throw new Exception("Saldo insuficiente para este saque.");
            }

            return valor;
        }

        protected void RegistrarSaque(double valor)
        {
            Transacoes.Add(new Transacao()
            {
                Data = DateTime.Now,
                Tipo = TipoDeTransacao.Saida,
                Valor = valor
            });
        }

        public Extrato Extrato(DateTime dataInicial, DateTime dataFinal)
        {
            var transacoesNoPeriodo = Transacoes.Where(t => t.Data >= dataInicial && t.Data <= dataFinal).ToList();
            return new Extrato(_numero, Saldo(), transacoesNoPeriodo);
        }

        public bool IsValid(int numeroDeConta, int pin)
        {
            return (_numero == numeroDeConta && _pin == pin);
        }
    }
}
