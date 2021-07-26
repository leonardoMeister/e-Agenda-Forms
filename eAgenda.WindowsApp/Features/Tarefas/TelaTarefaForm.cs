using eAgenda.Dominio.TarefaModule;
using System;
using System.IO;
using System.Windows.Forms;

namespace eAgenda.WindowsApp.Features.Tarefas
{
    public partial class TelaTarefaForm : Form
    {
        private Tarefa tarefa;

        public TelaTarefaForm()
        {
            InitializeComponent();

            CarregarPrioridades();
        }

        private void CarregarPrioridades()
        {
            cmbPrioridade.DataSource = Enum.GetValues(typeof(PrioridadeEnum));
        }

        public Tarefa Tarefa
        {
            get { return tarefa; }

            set 
            { 
                tarefa = value;

                txtId.Text = tarefa.Id.ToString();
                txtTitulo.Text = tarefa.Titulo;
                dateDataCriacao.Text = tarefa.DataCriacao.ToShortDateString();

                cmbPrioridade.SelectedIndex = tarefa.Prioridade.Chave;
                txtPercentual.Value = tarefa.Percentual;
                dateDataConclusao.Text = tarefa.DataConclusao.HasValue ? 
                    tarefa.DataConclusao.Value.ToShortDateString() : "";
            }
        }


        private void btnGravar_Click(object sender, EventArgs e)
        {
            string titulo = txtTitulo.Text;

            PrioridadeEnum prioridade = (PrioridadeEnum)cmbPrioridade.SelectedValue;

            DateTime dataCriacao, dataConclusao;

            if (string.IsNullOrEmpty(txtId.Text)) //inserindo
                dataCriacao = DateTime.Now;
            else
                dataCriacao = Convert.ToDateTime(dateDataCriacao.Text);

            if (txtPercentual.Value == 100 && string.IsNullOrEmpty(dateDataConclusao.Text))
                dataConclusao = DateTime.Now;

            else if (string.IsNullOrEmpty(dateDataConclusao.Text) == false)
                dataConclusao = Convert.ToDateTime(dateDataConclusao.Text);

            else
                dataConclusao = DateTime.MinValue;

            tarefa = new Tarefa(titulo, dataCriacao, prioridade);

            tarefa.AtualizarPercentual((int)txtPercentual.Value, dataConclusao);

            string resultadoValidacao = tarefa.Validar();

            if (resultadoValidacao != "ESTA_VALIDO")
            {
                string primeiroErro = new StringReader(resultadoValidacao).ReadLine();

                TelaPrincipalForm.Instancia.AtualizarRodape(primeiroErro);

                DialogResult = DialogResult.None;
            }
        }

        private void TelaTarefaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }
    }
}
