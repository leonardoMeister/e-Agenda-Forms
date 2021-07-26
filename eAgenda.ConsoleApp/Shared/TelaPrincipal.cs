using eAgenda.ConsoleApp.CompromissoModule;
using eAgenda.ConsoleApp.ContatoModule;
using eAgenda.ConsoleApp.TarefaModule;
using eAgenda.Controladores.CompromissoModule;
using eAgenda.Controladores.ContatoModule;
using eAgenda.Controladores.TarefaModule;
using System;

namespace eAgenda.ConsoleApp.Shared
{
    public class TelaPrincipal : TelaBase
    {
        private readonly ControladorTarefa controladorTarefa;
        private readonly TelaTarefa telaTarefa;

        private readonly ControladorContato controladorContato;
        private readonly TelaContato telaContato;

        private readonly ControladorCompromisso controladorCompromisso;
        private readonly TelaCompromisso telaCompromisso;

        public TelaPrincipal() : base("Tela Principal")
        {
            controladorTarefa = new ControladorTarefa();
            telaTarefa = new TelaTarefa(controladorTarefa);

            controladorContato = new ControladorContato();
            telaContato = new TelaContato(controladorContato);

            controladorCompromisso = new ControladorCompromisso();
            telaCompromisso = new TelaCompromisso(controladorCompromisso, telaContato, controladorContato);

            PopularAplicacao();
        }

        private void PopularAplicacao()
        {

        }

        public TelaBase ObterTela()
        {
            ConfigurarTela("Escolha uma opção: ");

            TelaBase telaSelecionada = null;
            string opcao;
            do
            {
                Console.WriteLine("Digite 1 para o Cadastro de Tarefas");
                Console.WriteLine("Digite 2 para o Cadastro de Contatos");
                Console.WriteLine("Digite 3 para o Cadastro de Compromissos");

                Console.WriteLine("Digite S para Sair");
                Console.WriteLine();
                Console.Write("Opção: ");
                opcao = Console.ReadLine();

                if (opcao == "1")
                    telaSelecionada = telaTarefa;

                if (opcao == "2")
                    telaSelecionada = telaContato;

                if (opcao == "3")
                    telaSelecionada = telaCompromisso;

                else if (opcao.Equals("s", StringComparison.OrdinalIgnoreCase))
                    telaSelecionada = null;

            } while (OpcaoInvalida(opcao));

            return telaSelecionada;
        }

        private bool OpcaoInvalida(string opcao)
        {
            if (opcao != "1" && opcao != "2" && opcao != "3" /*&& opcao != "4" && opcao != "S"*/ && opcao != "s")
            {
                ApresentarMensagem("Opção inválida", TipoMensagem.Erro);
                return true;
            }
            else
                return false;
        }
    }

}
