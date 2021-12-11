using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Infnet.Aula4.Pdv.Domain.Tests
{
    [TestClass]
    public class PedidoTests
    {
        [TestMethod]
        public void CalcularTotalDoPedido()
        {
            Pedido pedido = new Pedido();
            pedido.DataDoPedido = DateTime.Now;
            pedido.Itens.Add(new ItemDePedido()
            {
                Quantidade = 1,
                Produto = new Produto()
                {
                    Codigo = "1",
                    Valor = 5,
                }
            });

            pedido.Itens.Add(new ItemDePedido2()
            {
                Quantidade = 1,
                Produto = new Produto()
                {
                    Codigo = "2",
                    Valor = 5,
                },
                XPTO = 1
            });

            Assert.AreEqual(10, pedido.Total());
        }
    }
}
