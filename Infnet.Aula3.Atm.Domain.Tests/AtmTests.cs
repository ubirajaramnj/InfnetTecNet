using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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
    }
}
