using eAgenda.Dominio.ContatoModule;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace eAgenda.Tests.ContatoModule
{
    [TestClass]
    [TestCategory("Dominio")]
    public class ContatoTest
    {
        [TestMethod]
        public void DeveValidar_Email()
        {
            //arrange
            var contato = new Contato("José Pedro", "jose.pedro@gmail", "321654987", "JP Ltda", "Desenvolvedor");

            //action
            var resultadoValidacao = contato.Validar();
            
            //assert
            resultadoValidacao.Should().Be("O campo Email está inválido");
        }

        [TestMethod]
        public void DeveValidar_Telefone()
        {
            //arrange
            var contato = new Contato("José Pedro", "jose.pedro@gmail.com", "32164", "JP Ltda", "Desenvolvedor");
            
            //action
            var resultadoValidacao = contato.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Telefone está inválido");
        }

        [TestMethod]
        public void DeveValidar_Email_Telefone()
        {
            //arrange
            var contato = new Contato("José Pedro", "jose.pedro@gmail", "32164", "JP Ltda", "Desenvolvedor");

            //action
            var resultadoValidacao = contato.Validar();

            //assert
            var resultadoEsperado =
                "O campo Telefone está inválido"
                + Environment.NewLine
                + "O campo Email está inválido";
            resultadoValidacao.Should().Be(resultadoEsperado);
        }
    }
}
