using eAgenda.Controladores.CompromissoModule;
using eAgenda.Controladores.ContatoModule;
using eAgenda.Controladores.Shared;
using eAgenda.Dominio.CompromissoModule;
using eAgenda.Dominio.ContatoModule;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace eAgenda.Tests.CompromissoModule
{
    [TestClass]
    [TestCategory("Controladores")]
    public class ControladorCompromissoTest
    {
        ControladorCompromisso controladorCompromisso = null;
        ControladorContato controladorContato = null;

        public ControladorCompromissoTest()
        {
            controladorCompromisso = new ControladorCompromisso();
            controladorContato = new ControladorContato();

            Db.Update("DELETE FROM [TBCOMPROMISSO]");
            Db.Update("DELETE FROM [TBCONTATO]");
        }

        [TestMethod]
        public void DeveInserir_Compromisso()
        {
            //arrange
            Contato contato = new Contato("José Pedro", "jose.pedro@gmail.com", "321654987", "JP Ltda", "Dev");
            controladorContato.InserirNovo(contato);

            Compromisso novoCompromisso = new Compromisso("Montar plano de Marketing", "Padaria", "",
                DateTime.Today, new TimeSpan(13, 00, 00), new TimeSpan(14, 00, 00), contato);

            //action
            controladorCompromisso.InserirNovo(novoCompromisso);

            //assert
            var contatoEncontrado = controladorCompromisso.SelecionarPorId(novoCompromisso.Id);
            contatoEncontrado.Should().Be(novoCompromisso);
        }
       
        [TestMethod]
        public void DeveAtualizar_Compromisso()
        {
            //arrange
            var contato = new Contato("José Pedro", "jose.pedro@gmail.com", "321654987", "JP Ltda", "Dev");
            controladorContato.InserirNovo(contato);

            Compromisso compromisso = new Compromisso("Montar plano de Marketing", "Padaria", "",
                DateTime.Today, new TimeSpan(13, 00, 00), new TimeSpan(14, 00, 00), contato);

            controladorCompromisso.InserirNovo(compromisso);

            DateTime amanha = DateTime.Today.AddDays(1);

            var novoCompromisso = new Compromisso("Validar plano de Marketing", "Midilages", "",
                amanha, new TimeSpan(17, 00, 00), new TimeSpan(18, 00, 00), contato);

            //action
            controladorCompromisso.Editar(compromisso.Id, novoCompromisso);

            //assert
            Compromisso compromissoEncontrado = controladorCompromisso.SelecionarPorId(compromisso.Id);
            compromissoEncontrado.Should().Be(novoCompromisso);
        }

        [TestMethod]
        public void DeveExcluir_Compromisso()
        {
            var contato = new Contato("José Pedro", "jose.pedro@gmail.com", "321654987", "JP Ltda", "Dev");
            controladorContato.InserirNovo(contato);

            Compromisso compromisso = new Compromisso("Montar plano de Marketing", "Padaria", "",
                DateTime.Today, new TimeSpan(13, 00, 00), new TimeSpan(14, 00, 00), contato);

            controladorCompromisso.InserirNovo(compromisso);

            //action            
            controladorCompromisso.Excluir(compromisso.Id);

            //assert
            Compromisso contatoEncontrado = controladorCompromisso.SelecionarPorId(compromisso.Id);
            contatoEncontrado.Should().BeNull();
        }

        [TestMethod]
        public void DeveSelecionar_Compromisso_PorId()
        {
            //arrange
            Compromisso compromisso = new Compromisso("Montar plano de Marketing", "Padaria", "",
                DateTime.Today, new TimeSpan(13, 00, 00), new TimeSpan(14, 00, 00), null);
            controladorCompromisso.InserirNovo(compromisso);

            //action
            Compromisso compromissoEncontrado = controladorCompromisso.SelecionarPorId(compromisso.Id);

            //assert
            compromissoEncontrado.Should().NotBeNull();
        }

        [TestMethod]
        public void DeveSelecionar_TodosCompromissos()
        {
            //arrange
            var compromissos = new List<Compromisso>
            {
                new Compromisso("Montar plano de Marketing", "Agencia", "",
                    DateTime.Today, new TimeSpan(13, 00, 00), new TimeSpan(14, 00, 00), null),

                new Compromisso("Desenhar logotipo", "Agencia", "",
                    DateTime.Today, new TimeSpan(14, 05, 00), new TimeSpan(15, 00, 00), null),

                new Compromisso("Validar logotipo", "Agencia", "",
                    DateTime.Today, new TimeSpan(16, 00, 00), new TimeSpan(17, 00, 00), null),

                new Compromisso("Validar plano de marketing", "Agencia", "",
                    DateTime.Today, new TimeSpan(17, 05, 00), new TimeSpan(18, 00, 00), null)
            };

            foreach (var c in compromissos)
                controladorCompromisso.InserirNovo(c);

            //action
            var contatos = controladorCompromisso.SelecionarTodos();

            //assert
            contatos.Should().HaveCount(4);
        }

        [TestMethod]
        public void DeveSelecionar_CompromissosFuturos_PorPeriodo()
        {
            //arrange
            DateTime segunda = new DateTime(2021, 6, 28);
            DateTime terca = new DateTime(2021, 6, 29);
            DateTime quarta = new DateTime(2021, 6, 30);
            DateTime quinta = new DateTime(2021, 7, 1);
            DateTime sexta = new DateTime(2021, 7, 2);

            var compromissos = new List<Compromisso>
            {
                new Compromisso("Montar plano de Marketing", "Agencia", "",
                    segunda, new TimeSpan(13, 00, 00), new TimeSpan(14, 00, 00), null),

                new Compromisso("Montar plano de Marketing", "Agencia", "",
                    terca, new TimeSpan(13, 00, 00), new TimeSpan(14, 00, 00), null),

                new Compromisso("Desenhar logotipo", "Agencia", "",
                    quarta, new TimeSpan(14, 05, 00), new TimeSpan(15, 00, 00), null),

                new Compromisso("Validar logotipo", "Agencia", "",
                    quinta, new TimeSpan(16, 00, 00), new TimeSpan(17, 00, 00), null),

                new Compromisso("Validar plano de marketing", "Agencia", "",
                    sexta, new TimeSpan(17, 05, 00), new TimeSpan(18, 00, 00), null),               
            };

            foreach (var c in compromissos)
                controladorCompromisso.InserirNovo(c);

            //action
            DateTime hoje = new DateTime(2021, 7, 1);
            DateTime amanha = new DateTime(2021, 7, 2);
            var contatos = controladorCompromisso.SelecionarCompromissosFuturos(hoje, amanha);

            //assert
            contatos.Should().HaveCount(2);
        }

        [TestMethod]
        public void DeveSelecionar_Compromissos_NoPassado()
        {
            //arrange
            DateTime segunda = new DateTime(2021, 6, 28);
            DateTime terca = new DateTime(2021, 6, 29);
            DateTime quarta = new DateTime(2021, 6, 30);
            DateTime quinta = new DateTime(2021, 7, 1);
            DateTime sexta = new DateTime(2021, 7, 2);

            var compromissos = new List<Compromisso>
            {
                new Compromisso("Montar plano de Marketing", "Agencia", "",
                    segunda, new TimeSpan(13, 00, 00), new TimeSpan(14, 00, 00), null),

                new Compromisso("Montar plano de Marketing", "Agencia", "",
                    terca, new TimeSpan(13, 00, 00), new TimeSpan(14, 00, 00), null),

                new Compromisso("Desenhar logotipo", "Agencia", "",
                    quarta, new TimeSpan(14, 05, 00), new TimeSpan(15, 00, 00), null),

                new Compromisso("Validar logotipo", "Agencia", "",
                    quinta, new TimeSpan(16, 00, 00), new TimeSpan(17, 00, 00), null),

                new Compromisso("Validar plano de marketing", "Agencia", "",
                    sexta, new TimeSpan(17, 05, 00), new TimeSpan(18, 00, 00), null)
            };

            foreach (var c in compromissos)
                controladorCompromisso.InserirNovo(c);

            //action
            DateTime hoje = new DateTime(2021, 7, 1);
            var contatos = controladorCompromisso.SelecionarCompromissosPassados(hoje);

            //assert
            contatos.Should().HaveCount(3);
        }

        [TestMethod]
        public void NaoDeveInserir_Compromisso_NaMesmaData_NoMesmoHorario()
        {
            //arrange
            Compromisso compromisso = new Compromisso("Montar plano de Marketing", "Padaria", "",
                DateTime.Today, new TimeSpan(13, 00, 00), new TimeSpan(14, 00, 00), null);
            
            controladorCompromisso.InserirNovo(compromisso);

            Compromisso novoCompromisso = new Compromisso("Desenhar logotipo", "Agencia", "",
                    DateTime.Today, new TimeSpan(13, 00, 00), new TimeSpan(14, 00, 00), null);
            
            //action
            string resultado = controladorCompromisso.InserirNovo(novoCompromisso);

            //assert
            resultado.Should().Be("Nesta data e horário já tem um compromisso agendado");
            List<Compromisso> compromissos = controladorCompromisso.SelecionarTodos();

            compromissos.Should().HaveCount(1);
        }

        [TestMethod]
        public void DeveRetornarHorarioLivre_1()
        {
            //arrange
            DateTime hoje = DateTime.Today;            
            var compromisso = new Compromisso("Montar plano de Marketing", "Agencia", "",
                    hoje, new TimeSpan(12, 00, 00), new TimeSpan(13, 00, 00), null);
            controladorCompromisso.InserirNovo(compromisso);

            //action
            bool horarioOcupado = controladorCompromisso.VerificarHorarioOcupado(hoje, new TimeSpan(14, 00, 00), new TimeSpan(15, 00, 00));

            //assert
            horarioOcupado.Should().Be(false);
        }

        [TestMethod]
        public void DeveRetornarHorarioLivre_2()
        {
            //arrange
            DateTime hoje = DateTime.Today;            
            var compromissos = new List<Compromisso>
            {
                new Compromisso("Montar plano de Marketing", "Agencia", "",
                    hoje, new TimeSpan(12, 00, 00), new TimeSpan(13, 00, 00), null),

                new Compromisso("Desenhar logotipo", "Agencia", "",
                    hoje, new TimeSpan(14, 00, 00), new TimeSpan(15, 00, 00), null)              
            };

            foreach (var c in compromissos)
                controladorCompromisso.InserirNovo(c);

            //action
            bool horarioOcupado = controladorCompromisso.VerificarHorarioOcupado(hoje, new TimeSpan(13, 01, 00), new TimeSpan(13, 59, 00));

            //assert
            horarioOcupado.Should().Be(false);
        }

        [TestMethod]
        public void DeveRetornarHorarioOcupado_CasoHorarioDesejadoSejaIgual()
        {
            //arrange
            DateTime hoje = DateTime.Today;
            var compromisso = new Compromisso("Montar plano de Marketing", "Agencia", "",
                    hoje, new TimeSpan(12, 00, 00), new TimeSpan(13, 00, 00), null);
            controladorCompromisso.InserirNovo(compromisso);

            //action
            bool horarioOcupado = controladorCompromisso.VerificarHorarioOcupado(hoje, new TimeSpan(12, 00, 00), new TimeSpan(13, 00, 00));

            //assert
            horarioOcupado.Should().Be(true);
        }

        [TestMethod]
        public void DeveRetornarHorarioOcupado_CasoHorarioInicialDesejadoEstejaOcupado()
        {
            //arrange
            DateTime hoje = DateTime.Today;
            var compromisso = new Compromisso("Montar plano de Marketing", "Agencia", "",
                    hoje, new TimeSpan(12, 00, 00), new TimeSpan(13, 00, 00), null);
            controladorCompromisso.InserirNovo(compromisso);

            //action
            bool horarioOcupado = controladorCompromisso.VerificarHorarioOcupado(hoje, new TimeSpan(12, 30, 00), new TimeSpan(13, 30, 00));

            //assert
            horarioOcupado.Should().Be(true);
        }

        [TestMethod]
        public void DeveRetornarHorarioOcupado_CasoHorarioFinalDesejadoEstejaOcupado()
        {
            //arrange
            DateTime hoje = DateTime.Today;
            var compromisso = new Compromisso("Montar plano de Marketing", "Agencia", "",
                    hoje, new TimeSpan(12, 00, 00), new TimeSpan(13, 00, 00), null);
            controladorCompromisso.InserirNovo(compromisso);

            //action
            bool horarioOcupado = controladorCompromisso.VerificarHorarioOcupado(hoje, new TimeSpan(11, 30, 00), new TimeSpan(12, 30, 00));

            //assert
            horarioOcupado.Should().Be(true);
        }

    }
}