using eAgenda.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eAgenda.Controladores.CompromissoModule;
using eAgenda.Controladores.ContatoModule;
using eAgenda.Dominio.CompromissoModule;

namespace eAgenda.WindowsApp.Features.Compromissos
{
    public class OperacoesCompromisso : ICadastravel
    {
        private readonly ControladorCompromisso controladorCompromisso = null;
        private readonly ControladorContato controladorContato = null;
        private readonly TabelaCompromissoControl tabelaCompromisso = null;

        public OperacoesCompromisso(ControladorCompromisso controlCompro, ControladorContato controlContato)
        {
            this.controladorContato = controlContato;
            this.controladorCompromisso = controlCompro;
            this.tabelaCompromisso = new TabelaCompromissoControl();
        }

        public void EditarRegistro()
        {
            int id = tabelaCompromisso.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um Compromisso para poder editar!", "Edição de Compromissos",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Compromisso compromissoSelecionado = controladorCompromisso.SelecionarPorId(id);

            TelaCompromissoForm tela = new TelaCompromissoForm(controladorContato);

            tela.Compromisso = compromissoSelecionado;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controladorCompromisso.Editar(id, tela.Compromisso);

                List<Compromisso> Compromissos = controladorCompromisso.SelecionarTodos();

                tabelaCompromisso.AtualizarRegistros(Compromissos);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Compromisso: [{tela.Compromisso.Assunto}] editado com sucesso");
            }
        }

        public void ExcluirRegistro()
        {
            int id = tabelaCompromisso.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um Compromisso para poder excluir!", "Exclusão de Compromissos",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Compromisso compromissoSelecionado = controladorCompromisso.SelecionarPorId(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir o Compromisso: [{compromissoSelecionado.Assunto}] ?",
                "Exclusão de Compromissos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                controladorCompromisso.Excluir(id);

                List<Compromisso> tarefas = controladorCompromisso.SelecionarTodos();

                tabelaCompromisso.AtualizarRegistros(tarefas);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Compromisso: [{compromissoSelecionado.Assunto}] removido com sucesso");
            }
        }

        public void FiltrarRegistros()
        {
            FiltroCompromissoForm telaFiltro = new FiltroCompromissoForm();

            if (telaFiltro.ShowDialog() == DialogResult.OK)
            {
                List<Compromisso> compromissos = new List<Compromisso>();
                string tipoCompromisso = "";

                switch (telaFiltro.TipoFiltro)
                {
                    case FiltroCompromissoEnum.FiltroTodosCompromissos:
                        compromissos = controladorCompromisso.SelecionarTodos();
                        break;

                    case FiltroCompromissoEnum.FiltroFuturos:
                        {
                            compromissos = controladorCompromisso.SelecionarCompromissosFuturos(DateTime.Now, new DateTime().AddYears(5));
                            tipoCompromisso = "futuro(s)";
                            break;
                        }

                    case FiltroCompromissoEnum.FiltroPassados:
                        {
                            compromissos = controladorCompromisso.SelecionarCompromissosPassados(DateTime.Now);
                            tipoCompromisso = "passado(s)";
                            break;
                        }

                    case FiltroCompromissoEnum.FiltroProximas24Horas:
                        {
                            compromissos = controladorCompromisso.SelecionarCompromissosFuturos(DateTime.Now, DateTime.Now.AddDays(1));
                            tipoCompromisso = "Proximas 24 horas";
                            break;
                        }

                    case FiltroCompromissoEnum.FiltroProximaSemana:
                        {
                            compromissos = controladorCompromisso.SelecionarCompromissosFuturos(DateTime.Now.Date, DateTime.Now.Date.AddDays(7));
                            tipoCompromisso = "Proxima semana";
                            break;
                        }

                    case FiltroCompromissoEnum.FiltroProximoMes:
                        {
                            compromissos = controladorCompromisso.SelecionarCompromissosFuturos(DateTime.Now.Date, DateTime.Now.Date.AddMonths(1));
                            tipoCompromisso = "Proximo mês";
                            break;
                        }

                    default:
                        break;
                }

                tabelaCompromisso.AtualizarRegistros(compromissos);
                TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {compromissos.Count} Compromisso(s) {tipoCompromisso}");
            }
        }

        public void InserirNovoRegistro()
        {
            TelaCompromissoForm tela = new TelaCompromissoForm(controladorContato);

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controladorCompromisso.InserirNovo(tela.Compromisso);

                List<Compromisso> compromissos = controladorCompromisso.SelecionarTodos();

                tabelaCompromisso.AtualizarRegistros(compromissos);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Compromisso: [{tela.Compromisso.Assunto}] inserido com sucesso");
            }
        }

        public UserControl ObterTabela()
        {
            List<Compromisso> compromissos = controladorCompromisso.SelecionarTodos();

            tabelaCompromisso.AtualizarRegistros(compromissos);
            return tabelaCompromisso;
        }
        public void AgruparRegistros()
        {
            throw new NotImplementedException();
        }
    }
}
