using eAgenda.ConsoleApp.Shared;
using eAgenda.Controladores.TarefaModule;
using eAgenda.Dominio.TarefaModule;
using System;
using System.Collections.Generic;

namespace eAgenda.ConsoleApp.TarefaModule
{
    public class TelaTarefa : TelaCadastroBasico<Tarefa>, ICadastravel
    {
        public readonly ControladorTarefa controladorTarefa;

        public TelaTarefa(ControladorTarefa controladorTarefa)
            : base("Cadastro de Tarefas", controladorTarefa)
        {
            this.controladorTarefa = controladorTarefa;
        }

        public override void EditarRegistro()
        {
            ConfigurarTela(SubtituloDeEdicao());

            string opcao = ObterOpcao();

            if (opcao == "1")
            {
                bool temRegistros = VisualizarTarefasPendentes();

                if (temRegistros == false)
                    return;

                Console.Write("\n" + PerguntaEdicaoQualRegistro());
                int id = Convert.ToInt32(Console.ReadLine());

                bool numeroEncontrado = base.controlador.Existe(id);
                if (numeroEncontrado == false)
                {
                    ApresentarMensagem(MensagemDeRegistroNaoEncontrado() + id, TipoMensagem.Erro);
                    EditarRegistro();
                    return;
                }

                Console.Write("Digite o percentual: ");
                int novoPercentual = Convert.ToInt32(Console.ReadLine());

                controladorTarefa.AtualizarPercentual(id, novoPercentual);

                ApresentarMensagem(MensagemDeEdicaoComSucesso(), TipoMensagem.Sucesso);
            }
            else if (opcao == "2")
            {
                base.EditarRegistro();
            }
        }

        public override bool VisualizarRegistros(TipoVisualizacao tipo)
        {
            if (tipo == TipoVisualizacao.Pesquisando)
                return base.VisualizarRegistros(TipoVisualizacao.VisualizandoTela);

            if (tipo == TipoVisualizacao.VisualizandoTela)
                ConfigurarTela(SubtituloDeVisualizacao());

            VisualizarTarefasConcluidas();

            VisualizarTarefasPendentes();

            return true;
        }

        private bool VisualizarTarefasPendentes()
        {
            bool temRegistros = true;

            var tarefasPendentes = controladorTarefa.SelecionarTodasTarefasPendentes();

            Console.WriteLine("\nTarefas Pendentes:\n");

            if (tarefasPendentes.Count == 0)
            {
                ApresentarMensagem("Nenhuma tarefa pendente", TipoMensagem.Atencao);
                temRegistros = false;
            }
            else
                ApresentarTabela(tarefasPendentes);

            return temRegistros;
        }

        private void VisualizarTarefasConcluidas()
        {
            var tarefasConcluidas = controladorTarefa.SelecionarTodasTarefasConcluidas();

            Console.WriteLine("\nTarefas Concluídas:\n");

            if (tarefasConcluidas.Count == 0)
                ApresentarMensagem("Nenhuma tarefa concluída", TipoMensagem.Atencao);
            else
                ApresentarTabela(tarefasConcluidas);
        }

        public override void ApresentarTabela(List<Tarefa> registros)
        {
            string configuracaoColunasTabela = "{0,-10} | {1,-55} | {2,-20} | {3,-15}";

            MontarCabecalhoTabela(configuracaoColunasTabela, "Id", "Título", "Prioridade", "Percentual");

            foreach (Tarefa tarefa in registros)
            {
                Console.WriteLine(configuracaoColunasTabela,
                    tarefa.Id, tarefa.Titulo, tarefa.Prioridade, tarefa.Percentual);
            }
        }

        public override Tarefa ObterRegistro(TipoAcao tipoAcao)
        {
            Console.Write("Digite o título da Tarefa: ");
            string titulo = Console.ReadLine();

            Console.WriteLine("\n0 para prioridade Baixa");
            Console.WriteLine("1 para prioridade Normal");
            Console.WriteLine("2 para prioridade Alta");

            Console.WriteLine("\nDigite a prioridade da Tarefa: ");

            int prioridade = Convert.ToInt32(Console.ReadLine());

            return new Tarefa(titulo, DateTime.Now.Date, (PrioridadeEnum)prioridade);
        }

        private new string ObterOpcao()
        {
            Console.WriteLine("Digite 1 para atualizar percentuais");
            Console.WriteLine("Digite 2 para editar os dados da tarefa");

            Console.WriteLine("Digite S para Voltar");
            Console.WriteLine();

            Console.Write("Opção: ");
            string opcao = Console.ReadLine();

            return opcao;
        }
    }
}