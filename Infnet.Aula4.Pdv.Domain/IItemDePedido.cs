using System;

namespace Infnet.Aula4.Pdv.Domain
{
    public interface IItemDePedido
    {
        int Quantidade { get; set; }
        Produto Produto { get; set; }
        double Total();
    }
}