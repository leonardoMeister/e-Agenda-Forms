using System.Collections.Generic;
using System.Windows.Forms;
using eAgenda.Dominio.TarefaModule;
using eAgenda.WindowsApp.Shared;

namespace eAgenda.WindowsApp.Features.Tarefas
{
    public partial class TabelaTarefaControl : UserControl
    {
        public TabelaTarefaControl()
        {
            InitializeComponent();
            gridTarefas.ConfigurarGridZebrado();
            gridTarefas.ConfigurarGridSomenteLeitura();
            gridTarefas.Columns.AddRange(ObterColunas());
        }

        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Titulo", HeaderText = "Título"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Prioridade", HeaderText = "Prioridade"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Percentual", HeaderText = "Percentual"},

                new DataGridViewTextBoxColumn {DataPropertyName = "DataCriacao", HeaderText = "Data de Criação"},

                new DataGridViewTextBoxColumn {DataPropertyName = "DataConclusao", HeaderText = "Data de Conclusão"}
            };

            return colunas;
        }

        public int ObtemIdSelecionado()
        {
            return gridTarefas.SelecionarId<int>();
        }

        public void AtualizarRegistros(List<Tarefa> tarefas)
        {
            gridTarefas.Rows.Clear();

            foreach (Tarefa tarefa in tarefas)
            {
                gridTarefas.Rows.Add(tarefa.Id, tarefa.Titulo, tarefa.Prioridade,
                    tarefa.Percentual, tarefa.DataCriacao, tarefa.DataConclusao);
            }
        }
    }
}
