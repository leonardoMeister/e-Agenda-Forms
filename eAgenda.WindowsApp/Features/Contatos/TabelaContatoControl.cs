using eAgenda.Dominio.ContatoModule;
using eAgenda.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eAgenda.WindowsApp.Features.Contatos
{
    public partial class TabelaContatoControl : UserControl
    {
        public TabelaContatoControl()
        {
            InitializeComponent();
            gridContato.ConfigurarGridZebrado();
            gridContato.ConfigurarGridSomenteLeitura();
            gridContato.Columns.AddRange(ObterColunas());
        }
       
        private void AgruparDados()
        {
            Subro.Controls.DataGridViewGrouper grupperListaEmpleados = new Subro.Controls.DataGridViewGrouper(gridContato);
            grupperListaEmpleados.RemoveGrouping();
            grupperListaEmpleados.SetGroupOn("Empresa");
            grupperListaEmpleados.Options.ShowGroupName = false;
            grupperListaEmpleados.Options.GroupSortOrder = System.Windows.Forms.SortOrder.None;
            gridContato.Columns["Empresa"].Visible = false;
        }
        private DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
                        {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Empresa", HeaderText = "Empresa"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Cargo", HeaderText = "Cargo"},

                new DataGridViewTextBoxColumn {DataPropertyName = "Telefone", HeaderText = "Telefone"},

                        };

            return colunas;
        }
        public int ObtemIdSelecionado()
        {
            return gridContato.SelecionarId<int>();
        }
        public void AtualizarRegistros(List<Contato> tarefas)
        {
            gridContato.Rows.Clear();

            foreach (Contato tarefa in tarefas)
            {
                gridContato.Rows.Add(tarefa.Id, tarefa.Nome, tarefa.Empresa,
                    tarefa.Cargo, tarefa.Telefone);
            }
        }
    }
}
