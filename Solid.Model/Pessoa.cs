using System;

namespace Solid.Model
{
    public class Pessoa
    {
        public string Nome { get; set; }
        public string Documento { get; set; }
    }

    public class Fisica : Pessoa
    {
        public DateTime DataDeNascimento { get; set; }
    }

    public class Juridica : Fisica
    {
        public DateTime DataDaConstituicao { get; set; }
    }
}
