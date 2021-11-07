using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Infnet.Aula3.Atm.Domain.Tests
{
    [TestClass]
    public class AtmTests
    {
        [TestMethod]
        public void ValidarDeContaContraPin()
        {
            int numeroDeConta = 123;
            int pin = 12345;

            Conta conta = new Conta();
            var contaValida = conta.IsValid(numeroDeConta, pin);

            Assert.IsTrue(contaValida);
        }

        [TestMethod]
        public void VisualizarSaldoDaConta()
        {
            int numeroDeConta = 123;
            int pin = 12345;

            Conta conta = new Conta();
            var contaValida = conta.IsValid(numeroDeConta, pin);
            Assert.IsTrue(contaValida);

            Assert.AreEqual(0, conta.Saldo());
        }

        [TestMethod]
        public void RealizarDepositoEmConta()
        {
            int numeroDeConta = 123;
            int pin = 12345;

            Conta conta = new Conta();
            var contaValida = conta.IsValid(numeroDeConta, pin);
            Assert.IsTrue(contaValida);
            Assert.AreEqual(0, conta.Saldo());

            conta.Deposito(15);

            Assert.AreEqual(15, conta.Saldo());
        }

        [TestMethod]
        public void RealizarSaqueDeConta()
        {
            int numeroDeConta = 123;
            int pin = 12345;

            Conta conta = new Conta();
            var contaValida = conta.IsValid(numeroDeConta, pin);
            Assert.IsTrue(contaValida);
            Assert.AreEqual(0, conta.Saldo());

            conta.Deposito(20);
            var valorDoSaque= conta.Saque(15);

            Assert.AreEqual(15, valorDoSaque);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Saldo insuficiente para este saque.")]
        public void RealizarSaqueInvalidoDeConta()
        {
            int numeroDeConta = 123;
            int pin = 12345;

            Conta conta = new Conta();
            var contaValida = conta.IsValid(numeroDeConta, pin);
            Assert.IsTrue(contaValida);
            Assert.AreEqual(0, conta.Saldo());

            var valorDoSaque = conta.Saque(15);
        }

        [TestMethod]
        public void GerarExtrato()
        {
            int numeroDeConta = 123;
            int pin = 12345;

            Conta conta = new ContaEspecial();
            var contaValida = conta.IsValid(numeroDeConta, pin);
            Assert.IsTrue(contaValida);
            Assert.AreEqual(0, conta.Saldo());

            conta.Deposito(10);
            Assert.AreEqual(10, conta.Saldo());

            conta.Saque(5);
            Assert.AreEqual(5, conta.Saldo());

            var extrato = conta.Extrato(DateTime.Now.AddMinutes(-10), DateTime.Now.AddMinutes(2));
            Assert.AreEqual(numeroDeConta, extrato.NumeroDaConta);
            Assert.AreEqual(5, extrato.Saldo);
            Assert.AreEqual(2, extrato.Transacoes.Count);

            Assert.AreEqual(1, actual: extrato.Transacoes.Where(t => t.Tipo == TipoDeTransacao.Entrada).ToList().Count);
            Assert.AreEqual(1, actual: extrato.Transacoes.Where(t => t.Tipo == TipoDeTransacao.Saida).ToList().Count);
            Assert.AreEqual(10, extrato.Transacoes.First(t => t.Tipo == TipoDeTransacao.Entrada).Valor);
            Assert.AreEqual(5, extrato.Transacoes.First(t => t.Tipo == TipoDeTransacao.Saida).Valor);
        }


        [TestMethod]
        public void RealizarSaqueDeContaEspecial()
        {
            int numeroDeConta = 123;
            int pin = 12345;

            IConta conta = new ContaEspecial()
            {
                Limite = 50
            };

            var contaValida = conta.IsValid(numeroDeConta, pin);
            Assert.IsTrue(contaValida);
            Assert.AreEqual(0, conta.Saldo());

            conta.Deposito(20);
            Assert.AreEqual(20, conta.Saldo());

            var valorDoSaque = conta.Saque(10);
            Assert.AreEqual(10, valorDoSaque);
            Assert.AreEqual(10, conta.Saldo());

            valorDoSaque = conta.Saque(10);
            Assert.AreEqual(10, valorDoSaque);
            Assert.AreEqual(0, conta.Saldo());

            valorDoSaque = conta.Saque(10);
            Assert.AreEqual(10, valorDoSaque);
            Assert.AreEqual(-10, conta.Saldo());
        }
    }
}
