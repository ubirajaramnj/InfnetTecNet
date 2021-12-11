using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.Aula4.Pdv.Domain
{
    public class ItemDePedido
    {
        public Guid Id { get; set; }
        public int Quantidade { get; set; }
        public virtual Produto Produto { get; set; }

        public double Total()
        {
            return Quantidade * Produto.Valor;
        }
    }
}
