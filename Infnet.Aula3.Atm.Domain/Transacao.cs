using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.Aula3.Atm.Domain
{
    public class Transacao
    {
        public double Valor { get; set; }
        public TipoDeTransacao Tipo { get; set; }
        public DateTime Data { get; set; }

    }

    public enum TipoDeTransacao
    {
        Entrada,
        Saida
    }
}
