using eAgenda.Controladores.Shared;
using eAgenda.Controladores.TarefaModule;
using eAgenda.Dominio.TarefaModule;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace eAgenda.Tests.TarefaModule
{
    [TestClass]
    [TestCategory("Controladores")]
    public class ControladorTarefaTest
    {
        ControladorTarefa controlador = null;

        public ControladorTarefaTest()
        {
            controlador = new ControladorTarefa();
            Db.Update("DELETE FROM [TBTAREFA]");
        }

        [TestMethod]
        public void DeveInserir_Tarefa()
        {
            //arrange
            Tarefa novaTarefa = new Tarefa("Corrigir provas", DateTime.Now, PrioridadeEnum.Alta);

            //action
            controlador.InserirNovo(novaTarefa);

            //assert
            Tarefa tarefaEncontrada = controlador.SelecionarPorId(novaTarefa.Id);            
            tarefaEncontrada.Should().Be(novaTarefa);
        }

        [TestMethod]
        public void DeveEditar_UmaTarefa()
        {
            //arrange
            Tarefa tarefa = new Tarefa("Preparar aula", DateTime.Now, PrioridadeEnum.Alta);            
            controlador.InserirNovo(tarefa);

            Tarefa novaTarefa = new Tarefa("Corrigir provas", DateTime.Now, PrioridadeEnum.Baixa);
            novaTarefa.AtualizarPercentual(100, DateTime.Today);

            //action
            controlador.Editar(tarefa.Id, novaTarefa);

            //assert
            Tarefa tarefaEncontrada = controlador.SelecionarPorId(tarefa.Id);
            tarefaEncontrada.Should().Be(novaTarefa);
        }

        [TestMethod]
        public void DeveExcluir_UmaTarefa()
        {
            //arrange            
            Tarefa tarefa = new Tarefa("Preparar aula", DateTime.Now, PrioridadeEnum.Alta);
            controlador.InserirNovo(tarefa);

            //action            
            controlador.Excluir(tarefa.Id);

            //assert
            Tarefa tarefaEncontrada = controlador.SelecionarPorId(tarefa.Id);
            tarefaEncontrada.Should().BeNull();
        }

        [TestMethod]
        public void DeveSelecionar_Tarefa_PorId()
        {
            //arrange
            Tarefa tarefa = new Tarefa("Preparar aula", DateTime.Now, PrioridadeEnum.Alta);
            controlador.InserirNovo(tarefa);

            //action
            Tarefa tarefaEncontrada = controlador.SelecionarPorId(tarefa.Id);

            //assert
            tarefaEncontrada.Should().Be(tarefa);
        }

        [TestMethod]
        public void DeveSelecionar_TodasTarefas_OrdenadasPorPrioridade()
        {
            //arrange
            Tarefa t1 = new Tarefa("Preparar aula", DateTime.Now, PrioridadeEnum.Baixa);
            controlador.InserirNovo(t1);
            
            Tarefa t3 = new Tarefa("Implementar Atividades", DateTime.Now, PrioridadeEnum.Alta);
            controlador.InserirNovo(t3);

            Tarefa t2 = new Tarefa("Corrigir Provas", DateTime.Now, PrioridadeEnum.Normal);
            controlador.InserirNovo(t2);
            

            //action
            var tarefas = controlador.SelecionarTodos();

            //assert
            tarefas.Should().HaveCount(3);
            tarefas[0].Titulo.Should().Be("Implementar Atividades");
            tarefas[1].Titulo.Should().Be("Corrigir Provas");
            tarefas[2].Titulo.Should().Be("Preparar aula");
        }

        [TestMethod]
        public void DeveSelecionar_TarefasConcluidas_OrdenadasPorPrioridade()
        {
            //arrange
            Tarefa t1 = new Tarefa("Preparar aula", DateTime.Now, PrioridadeEnum.Baixa);
            controlador.InserirNovo(t1);

            Tarefa t2 = new Tarefa("Corrigir Provas", DateTime.Now, PrioridadeEnum.Normal);
            controlador.InserirNovo(t2);

            Tarefa t3 = new Tarefa("Implementar Atividades", DateTime.Now, PrioridadeEnum.Alta);
            controlador.InserirNovo(t3);

            controlador.AtualizarPercentual(t2, 100);
            controlador.AtualizarPercentual(t3, 100);

            //action
            var tarefas = controlador.SelecionarTodasTarefasConcluidas();

            //assert
            tarefas.Should().HaveCount(2);
            tarefas[0].Titulo.Should().Be("Implementar Atividades");
            tarefas[1].Titulo.Should().Be("Corrigir Provas");
        }

        [TestMethod]
        public void DeveSelecionar_TarefasPendentes_OrdenadasPorPrioridade()
        {
            //arrange
            Tarefa t1 = new Tarefa("Preparar aula", DateTime.Now, PrioridadeEnum.Baixa);
            controlador.InserirNovo(t1);

            Tarefa t2 = new Tarefa("Corrigir Provas", DateTime.Now, PrioridadeEnum.Normal);
            controlador.InserirNovo(t2);

            Tarefa t3 = new Tarefa("Implementar Atividades", DateTime.Now, PrioridadeEnum.Alta);
            controlador.InserirNovo(t3);
            controlador.AtualizarPercentual(t3, 100);

            //action
            List<Tarefa> tarefas = controlador.SelecionarTodasTarefasPendentes();

            //assert
            tarefas.Should().HaveCount(2);
            tarefas[0].Titulo.Should().Be("Corrigir Provas");
            tarefas[1].Titulo.Should().Be("Preparar aula");
        }
    }
}
