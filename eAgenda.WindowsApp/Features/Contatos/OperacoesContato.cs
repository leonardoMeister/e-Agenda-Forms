using eAgenda.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eAgenda.Controladores.ContatoModule;
using eAgenda.Dominio.ContatoModule;

namespace eAgenda.WindowsApp.Features.Contatos
{
    public class OperacoesContato : ICadastravel
    {
        private readonly ControladorContato controlador;
        private readonly TabelaContatoControl tabelaContatos;

        public OperacoesContato(ControladorContato controlador)
        {
            this.controlador = controlador;
            tabelaContatos = new TabelaContatoControl();
        }
        public void InserirNovoRegistro()
        {
            TelaContatoForm tela = new TelaContatoForm();

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.InserirNovo(tela.Contato);

                List<Contato> tarefas = controlador.SelecionarTodos();

                tabelaContatos.AtualizarRegistros(tarefas);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Contato: [{tela.Contato.Nome}] inserido com sucesso");
            }
        }

        public void EditarRegistro()
        {
            int id = tabelaContatos.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um Contato para poder editar!", "Edição de Contatos",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Contato ContatoSelecionada = controlador.SelecionarPorId(id);

            TelaContatoForm tela = new TelaContatoForm();

            tela.Contato = ContatoSelecionada;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.Editar(id, tela.Contato);

                List<Contato> contatos = controlador.SelecionarTodos();

                tabelaContatos.AtualizarRegistros(contatos);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Contato: [{tela.Contato.Nome}] editado com sucesso");
            }
        }

        public void ExcluirRegistro()
        {

            int id = tabelaContatos.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um Contato para poder excluir!", "Exclusão de Contatos",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Contato contatoSelecionada = controlador.SelecionarPorId(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir o Contato: [{contatoSelecionada.Nome}] ?",
                "Exclusão de Contatos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                controlador.Excluir(id);

                List<Contato> tarefas = controlador.SelecionarTodos();

                tabelaContatos.AtualizarRegistros(tarefas);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Contato: [{contatoSelecionada.Nome}] removido com sucesso");
            }
        }        

        public UserControl ObterTabela()
        {
            List<Contato> tarefas = controlador.SelecionarTodos();

            tabelaContatos.AtualizarRegistros(tarefas);

            return tabelaContatos;
        }

        public void FiltrarRegistros()
        {
            throw new NotImplementedException();
        }

        public void AgruparRegistros()
        {
            throw new NotImplementedException();
        }
    }
}
