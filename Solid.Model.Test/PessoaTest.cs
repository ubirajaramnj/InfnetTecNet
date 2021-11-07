using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Solid.Model.Test
{
    [TestClass]
    public class PessoaTest
    {
        [TestMethod]
        public void GetPessoa()
        {
            Pessoa pessoa = new Fisica() { 
                DataDeNascimento = DateTime.Now
            };
            pessoa.Documento = "000.000.000-00";

            Assert.IsNotNull(pessoa);
            Assert.AreEqual("000.000.000-00", pessoa.Documento);
        }

        [TestMethod]
        public void GetPessoaJuridica()
        {
            Pessoa pessoa = new Juridica()
            {
                DataDaConstituicao = DateTime.Now
            };

            pessoa.Documento = "00.000.000/0000-00";
            
            Assert.IsNotNull(pessoa);
            Assert.AreEqual("00.000.000/0000-00", pessoa.Documento);
        }
    }
}
