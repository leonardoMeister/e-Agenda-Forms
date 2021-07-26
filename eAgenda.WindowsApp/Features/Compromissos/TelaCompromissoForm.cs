using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eAgenda.Dominio.CompromissoModule;
using eAgenda.Controladores.ContatoModule;
using System.IO;
using eAgenda.Dominio.ContatoModule;

namespace eAgenda.WindowsApp.Features.Compromissos
{
    public partial class TelaCompromissoForm : Form
    {
        private Compromisso compromisso;
        private readonly ControladorContato controlador;
        public TelaCompromissoForm(ControladorContato controlador)
        {
            InitializeComponent();
            this.controlador = controlador;
            AtualizarContatos();

            //Eventos Radio 
            radioOnline.CheckedChanged += new EventHandler(AlterarMeioCompromisso);
            radioPresencial.CheckedChanged += new EventHandler(AlterarMeioCompromisso);

        }

        private void AtualizarContatos()
        {
            cmbContato.Items.Clear();

            foreach (var item in controlador.SelecionarTodos())
            {
                cmbContato.Items.Add(item);
            }
        }

        public Compromisso Compromisso
        {
            get { return compromisso; }
            set
            {
                compromisso = value;

                txtId.Text = compromisso.Id.ToString();
                txtAssunto.Text = compromisso.Assunto;
                dateCompromisso.Text = compromisso.Data.ToShortDateString();
                horaInicio.Text = compromisso.HoraInicio.ToString();
                horaConclusao.Text = compromisso.HoraTermino.ToString();
            }
        }
        private Compromisso GerarObjeto()
        {
            string link, local;

            if (EhPresencial())
            {
                link = "";
                local = txtEndereco.Text;
            }else
            {
                local = "";
                link = txtEndereco.Text;
            }

            Contato contato = (!(cmbContato.SelectedItem is null)) ? (Contato)cmbContato.SelectedItem : null;

            compromisso = new Compromisso(txtAssunto.Text,local,link,dateCompromisso.Value,horaInicio.Value.TimeOfDay,horaConclusao.Value.TimeOfDay, contato);

            if (txtId.Text != "") compromisso.Id = Convert.ToInt32( txtId.Text);

            return compromisso;
        }
        private void btnGravar_Click(object sender, EventArgs e)
        {
            compromisso = GerarObjeto();

            string resultadoValidacao = compromisso.Validar();

            if (resultadoValidacao != "ESTA_VALIDO")
            {
                string primeiroErro = new StringReader(resultadoValidacao).ReadLine();

                TelaPrincipalForm.Instancia.AtualizarRodape(primeiroErro);

                DialogResult = DialogResult.None;
            }
        }
        private void TelaCompromissoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }
        private bool EhPresencial()
        {
            return (radioPresencial.Checked == true) ? true : false;
        }
        private void AlterarMeioCompromisso(object sender, EventArgs e)
        {
            RadioButton radio = ((RadioButton)sender);
            labelLocal.Text = (radio.Text == "Presencial") ? "Local" : "Link";
        }

    }
}
