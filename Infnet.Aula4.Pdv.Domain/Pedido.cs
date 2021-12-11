using System;
using System.Collections.Generic;

namespace Infnet.Aula4.Pdv.Domain
{
    public class Pedido
    {
        public Guid Id { get; set; }
        public DateTime DataDoPedido { get; set; }
        public List<ItemDePedido> Itens { get; set; } = new();

        public double Total()
        {
            double total = 0;
            foreach (var item in Itens)
            {
                total += item.Total();
            }

            return total;
        }
    }
}
