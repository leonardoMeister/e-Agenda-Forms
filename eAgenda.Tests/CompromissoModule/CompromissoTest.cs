using eAgenda.Dominio.CompromissoModule;
using eAgenda.Dominio.ContatoModule;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace eAgenda.Tests.CompromissoModule
{
    [TestClass]
    [TestCategory("Dominio")]
    public class CompromissoTest
    {
        [TestMethod]
        public void DeveRetornar_CompromissoValido()
        {
            //arrange
            var contato = new Contato("José Pedro", "jose.pedro@gmail.com", "321654987", "JP Ltda", "Dev");

            Compromisso compromisso = new Compromisso("Montar plano de Marketing","Padaria","",
                DateTime.Today, new TimeSpan(13,00,00), new TimeSpan(14, 00, 00), contato);

            //action
            var resultado = compromisso.Validar();

            //assert
            resultado.Should().Be("ESTA_VALIDO");
        }

        [TestMethod]
        public void DeveValidar_Data_HoraInicio_HoraTermino()
        {
            //arrange
            Compromisso compromisso = new Compromisso("Montar plano de Marketing", "Padaria", "",
                 DateTime.MinValue, TimeSpan.MinValue, TimeSpan.MinValue, null);

            //action
            var resultado = compromisso.Validar();

            //assert
            var resultadoEsperado =
               "O campo Data é obrigatório"
               + Environment.NewLine
               + "O campo Hora Início é obrigatório"
               + Environment.NewLine
               + "O campo Hora Término é obrigatório";

            resultado.Should().Be(resultadoEsperado);
        }

        

       
    }
}
