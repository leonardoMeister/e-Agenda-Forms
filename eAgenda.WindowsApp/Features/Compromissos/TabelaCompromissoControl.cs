using System.Collections.Generic;
using System.Windows.Forms;
using eAgenda.WindowsApp.Shared;
using eAgenda.Dominio.CompromissoModule;

namespace eAgenda.WindowsApp.Features.Compromissos
{
    public partial class TabelaCompromissoControl : UserControl
    {
        public TabelaCompromissoControl()
        {
            InitializeComponent();
            gridCompromisso.ConfigurarGridZebrado();
            gridCompromisso.ConfigurarGridSomenteLeitura();
            gridCompromisso.Columns.AddRange(ObterColunas());
        }
        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Assunto", HeaderText = "Assunto"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Contato", HeaderText = "Contato"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Data", HeaderText = "Data"},

                new DataGridViewTextBoxColumn {DataPropertyName = "HoraInicio", HeaderText = "Hora de Inicio"},

                new DataGridViewTextBoxColumn {DataPropertyName = "HoraTermino", HeaderText = "Hora de Termino"}
            };

            return colunas;
        }
        public int ObtemIdSelecionado()
        {
            return gridCompromisso.SelecionarId<int>();
        }

        public void AtualizarRegistros(List<Compromisso> compros)
        {
            gridCompromisso.Rows.Clear();

            foreach (Compromisso compromisso in compros)
            {
                gridCompromisso.Rows.Add(compromisso.Id, compromisso.Assunto, compromisso.Contato,
                    compromisso.Data, compromisso.HoraInicio, compromisso.HoraTermino);
            }
        }
    }
}
