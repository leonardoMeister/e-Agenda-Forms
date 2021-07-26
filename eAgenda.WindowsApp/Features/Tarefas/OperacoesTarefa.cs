using eAgenda.Controladores.TarefaModule;
using eAgenda.Dominio.TarefaModule;
using eAgenda.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eAgenda.WindowsApp.Features.Tarefas
{
    public class OperacoesTarefa : ICadastravel
    {
        private readonly ControladorTarefa controlador = null;
        private readonly TabelaTarefaControl tabelaTarefas = null;

        public OperacoesTarefa(ControladorTarefa ctrlTarefa)
        {
            controlador = ctrlTarefa;
            tabelaTarefas = new TabelaTarefaControl();
        }

        public void InserirNovoRegistro()
        {
            TelaTarefaForm tela = new TelaTarefaForm();

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.InserirNovo(tela.Tarefa);

                List<Tarefa> tarefas = controlador.SelecionarTodos();

                tabelaTarefas.AtualizarRegistros(tarefas);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Tarefa: [{tela.Tarefa.Titulo}] inserido com sucesso");
            }
        }

        public void EditarRegistro()
        {
            int id = tabelaTarefas.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione uma tarefa para poder editar!", "Edição de Tarefas",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Tarefa tarefaSelecionada = controlador.SelecionarPorId(id);

            if (tarefaSelecionada.EstaConcluida())
            {
                MessageBox.Show("Não é permitido a edição de tarefas já concluídas!", "Edição de Tarefas",
                  MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaTarefaForm tela = new TelaTarefaForm();

            tela.Tarefa = tarefaSelecionada;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.Editar(id, tela.Tarefa);

                List<Tarefa> tarefas = controlador.SelecionarTodos();

                tabelaTarefas.AtualizarRegistros(tarefas);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Tarefa: [{tela.Tarefa.Titulo}] editada com sucesso");
            }
        }

        public void ExcluirRegistro()
        {
            int id = tabelaTarefas.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione uma tarefa para poder excluir!", "Exclusão de Tarefas",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Tarefa tarefaSelecionada = controlador.SelecionarPorId(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir a tarefa: [{tarefaSelecionada.Titulo}] ?",
                "Exclusão de Tarefas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                controlador.Excluir(id);

                List<Tarefa> tarefas = controlador.SelecionarTodos();

                tabelaTarefas.AtualizarRegistros(tarefas);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Tarefa: [{tarefaSelecionada.Titulo}] removida com sucesso");
            }
        }

        public void FiltrarRegistros()
        {
            FiltroTarefaForm telaFiltro = new FiltroTarefaForm();

            if (telaFiltro.ShowDialog() == DialogResult.OK)
            {
                List<Tarefa> tarefas = new List<Tarefa>();
                string tipoTarefa = "";

                switch (telaFiltro.TipoFiltro)
                {
                    case FiltroTarefaEnum.TodasTarefas:
                        tarefas = controlador.SelecionarTodos();
                        break;

                    case FiltroTarefaEnum.TarefasPendentes:
                        {
                            tarefas = controlador.SelecionarTodasTarefasPendentes();
                            tipoTarefa = "pendente(s)";
                            break;
                        }

                    case FiltroTarefaEnum.TarefasConcluidas:
                        {
                            tarefas = controlador.SelecionarTodasTarefasConcluidas(); 
                            tipoTarefa = "concluída(s)";
                            break;
                        }

                    default:
                        break;
                }

                tabelaTarefas.AtualizarRegistros(tarefas);
                TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {tarefas.Count} tarefa(s) {tipoTarefa}");
            }
        }

        public UserControl ObterTabela()
        {
            List<Tarefa> tarefas = controlador.SelecionarTodos();

            tabelaTarefas.AtualizarRegistros(tarefas);

            return tabelaTarefas;
        }

        public void AgruparRegistros()
        {
            throw new NotImplementedException();
        }
    }
}
