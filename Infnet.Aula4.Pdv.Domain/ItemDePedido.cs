using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.Aula4.Pdv.Domain
{
    public class ItemDePedido : IItemDePedido
    {
        public Guid Id { get; set; }
        public int Quantidade { get; set; }
        public virtual Produto Produto { get; set; }

        public double Total()
        {
            return Quantidade * Produto.Valor;
        }
    }

    public class ItemDePedido2 : IItemDePedido
    {
        public int Quantidade { get; set; }
        public virtual Produto Produto { get; set; }
        public int XPTO { get; set; }
        
        public double Total()
        {
            return Quantidade * Produto.Valor;
        }
    }
}
