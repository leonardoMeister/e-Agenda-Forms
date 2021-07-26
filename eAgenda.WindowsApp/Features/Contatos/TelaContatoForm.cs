using eAgenda.Dominio.ContatoModule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eAgenda.WindowsApp.Features.Contatos
{
    public partial class TelaContatoForm : Form
    {
        private Contato contato;
        public TelaContatoForm()
        {
            InitializeComponent();
        }
        public Contato Contato
        {
            get { return contato; }

            set
            {
                contato = value;

                txtId.Text = contato.Id.ToString();
                txtNome.Text = contato.Nome;
                txtEmpresa.Text = contato.Email;
                txtEmail.Text = contato.Email;
                txtCargo.Text = contato.Cargo;
                mkTelefone.Text = contato.Telefone;
            }
        }
        private Contato GerarObjeto()
        {
            contato = new Contato(txtNome.Text, txtEmail.Text,mkTelefone.Text, txtEmpresa.Text, txtCargo.Text);
            contato.Id = (txtId.Text != "") ? Convert.ToInt32(txtId.Text) : 0;

            return contato;
        }
        private void btnGravar_Click(object sender, EventArgs e)
        {
            contato = GerarObjeto();

            string resultadoValidacao = contato.Validar();

            if (resultadoValidacao != "ESTA_VALIDO")
            {
                string primeiroErro = new StringReader(resultadoValidacao).ReadLine();

                TelaPrincipalForm.Instancia.AtualizarRodape(primeiroErro);

                DialogResult = DialogResult.None;
            }
        }

        private void TelaContatoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }
    }
}
