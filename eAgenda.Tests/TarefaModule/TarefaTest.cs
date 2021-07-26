using eAgenda.Dominio.TarefaModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FluentAssertions;

namespace eAgenda.Tests.TarefaModule
{
    [TestClass]
    [TestCategory("Dominio")]
    public class TarefaTest
    {
        [TestMethod]
        public void DeveCriar_Tarefa()
        {
            //action
            Tarefa tarefa = new Tarefa("Preparar aula", DateTime.Now, PrioridadeEnum.Baixa);

            //assert
            tarefa.DataCriacao.Should().Be(DateTime.Now.Date);
            tarefa.DataConclusao.Should().BeNull();
            tarefa.Percentual.Should().Be(0);
            tarefa.Prioridade.ToString().Should().Be("Prioridade Baixa");
        }

        [TestMethod]
        public void DeveRegistrarDataConclusao()
        {
            //arrange
            Tarefa tarefa = new Tarefa("Preparar aula", DateTime.Now, PrioridadeEnum.Baixa);

            //action
            tarefa.AtualizarPercentual(100, DateTime.Today);

            //assert
            tarefa.Percentual.Should().Be(100);
            tarefa.DataConclusao.Should().Be(DateTime.Today);            
        }

        [TestMethod]
        public void DeveRetornar_TarefaValida()
        {
            //arrange
            Tarefa tarefa = new Tarefa("Preparar aula", DateTime.Now, PrioridadeEnum.Baixa);
            tarefa.AtualizarPercentual(100, DateTime.Today);

            //action
            var resultado = tarefa.Validar();

            //assert
            resultado.Should().Be("ESTA_VALIDO");
        }

        [TestMethod]
        public void DeveValidar_DataCriacao()
        {
            //arrange
            var tarefa = new Tarefa("Preparar Aula", DateTime.MinValue, PrioridadeEnum.Baixa);

            //action
            var resultado = tarefa.Validar();

            //assert
            resultado.Should().Be("O campo Data de Criação é obrigatório");
        }

        [TestMethod]
        public void DeveValidar_Titulo()
        {
            //arrange
            var tarefa = new Tarefa("", DateTime.Today, PrioridadeEnum.Baixa);

            //action
            var resultado = tarefa.Validar();

            //assert
            resultado.Should().Be("O campo Título é obrigatório");
        }

        [TestMethod]
        public void DeveValidar_QuebraDeLinha_Titulo_DataCriacao()
        {
            //arrange
            var tarefa = new Tarefa("", DateTime.MinValue, PrioridadeEnum.Baixa);            

            //action
            var resultado = tarefa.Validar();

            //assert
            var resultadoEsperado =
                "O campo Título é obrigatório"
                + Environment.NewLine
                + "O campo Data de Criação é obrigatório";
            
            resultado.Should().Be(resultadoEsperado);
        }
    }
}
