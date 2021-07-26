using eAgenda.ConsoleApp.ContatoModule;
using eAgenda.ConsoleApp.Shared;
using eAgenda.Controladores.CompromissoModule;
using eAgenda.Controladores.ContatoModule;
using eAgenda.Dominio.CompromissoModule;
using eAgenda.Dominio.ContatoModule;
using System;
using System.Collections.Generic;

namespace eAgenda.ConsoleApp.CompromissoModule
{
    public class TelaCompromisso : TelaCadastroBasico<Compromisso>, ICadastravel
    {
        private readonly ControladorCompromisso controladorCompromisso;
        private readonly TelaContato telaContato;
        private readonly ControladorContato controladorContato;

        public TelaCompromisso(
            ControladorCompromisso ctrl,
            TelaContato tela,
            ControladorContato ctrlContato)
            : base("Cadastro de Compromissos", ctrl)
        {
            controladorCompromisso = ctrl;
            telaContato = tela;
            controladorContato = ctrlContato;
        }

        public override bool VisualizarRegistros(TipoVisualizacao tipo)
        {
            if (tipo == TipoVisualizacao.Pesquisando)
                return base.VisualizarRegistros(TipoVisualizacao.VisualizandoTela);

            if (tipo == TipoVisualizacao.VisualizandoTela)
                ConfigurarTela(SubtituloDeVisualizacao());

            string opcao = ObterOpcao();            

            if (opcao.Equals("1"))
                VisualizarCompromissosFuturos();

            else if (opcao.Equals("2"))
                VisualizarCompromissosPassados();

            return true;
        }

        private void VisualizarCompromissosFuturos()
        {
            Console.WriteLine("\nCompromissos Futuros:\n");

            Console.WriteLine("Filtros");

            Console.Write("Digite a data inicial: ");
            var dataInicio = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Digite a data final: ");
            var dataFim = Convert.ToDateTime(Console.ReadLine());

            List<Compromisso> compromissosFuturos = 
                controladorCompromisso.SelecionarCompromissosFuturos(dataInicio, dataFim);

            if (compromissosFuturos.Count == 0)
                ApresentarMensagem("Nenhum compromisso futuro encontrado", TipoMensagem.Atencao);
            else
                ApresentarTabela(compromissosFuturos);
        }

        private void VisualizarCompromissosPassados()
        {
            Console.WriteLine("\nCompromissos Passados:\n");

            List<Compromisso> compromissosPassados = 
                controladorCompromisso.SelecionarCompromissosPassados(DateTime.Now.Date);

            if (compromissosPassados.Count == 0)
                ApresentarMensagem("Nenhum compromisso passado encontrado", TipoMensagem.Atencao);
            else
                ApresentarTabela(compromissosPassados);
        }

        private new string ObterOpcao()
        {
            Console.WriteLine("Digite 1 para visualizar compromissos futuros");
            Console.WriteLine("Digite 2 para visualizar compromissos passados");

            Console.WriteLine("Digite S para Voltar");
            Console.WriteLine();

            Console.Write("Opção: ");
            string opcao = Console.ReadLine();

            return opcao;
        }

        public override void ApresentarTabela(List<Compromisso> registros)
        {
            string configuracaoColunasTabela = "{0,-10} | {1,-20} | {2,-20} | {3,-15} | {4,-15} | {5,-15}";

            MontarCabecalhoTabela(configuracaoColunasTabela, "Id", "Assunto", "Data", "Hora de início", "Hora de término", "Contato");

            foreach (Compromisso compromisso in registros)
            {
                Console.WriteLine(configuracaoColunasTabela,
                    compromisso.Id, compromisso.Assunto, compromisso.Data.ToShortDateString(), compromisso.HoraInicio, compromisso.HoraTermino, compromisso.Contato?.Nome);
            }
        }

        public override Compromisso ObterRegistro(TipoAcao tipoAcao)
        {
            Console.Write("Digite o assunto do compromisso: ");
            string assunto = Console.ReadLine();

            Console.Write("Digite a data do compromisso: ");
            DateTime data = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Digite a hora de inicio do compromisso [12:00]: ");
            string[] strHoraInicio = Console.ReadLine().Split(':');

            TimeSpan horaInicio = new TimeSpan(int.Parse(strHoraInicio[0]), int.Parse(strHoraInicio[1]), 0);

            Console.Write("Digite a hora de inicio do compromisso [12:00]: ");
            string[] strHoraFim = Console.ReadLine().Split(':');

            TimeSpan horaFim = new TimeSpan(int.Parse(strHoraFim[0]), int.Parse(strHoraFim[1]), 0);

            Console.WriteLine("Deseja marcar um contato neste compromisso [S/N]? ");

            string adicionarContato = Console.ReadLine();

            Contato contato = null;
            if (adicionarContato.Equals("s", StringComparison.OrdinalIgnoreCase))
            {
                var contatos = controladorContato.SelecionarTodos();
                telaContato.ApresentarTabela(contatos);

                Console.Write("Digite o id do contato: ");
                int idContato = Convert.ToInt32(Console.ReadLine());
                contato = controladorContato.SelecionarPorId(idContato);
            }

            Console.WriteLine("\n1 para compromisso presencial");
            Console.WriteLine("2 para compromisso remoto");
            Console.Write("\nDigite a forma como será o compromisso: ");

            string local, link;
            int forma = Convert.ToInt32(Console.ReadLine());
            if (forma == 1)
            {
                Console.Write("Digite o local do compromisso: ");
                local = Console.ReadLine();
                link = "Presencial";
            }
            else
            {
                Console.Write("Digite o link da video chamada: ");
                link = Console.ReadLine();
                local = "Remoto";
            }

            return new Compromisso(assunto, local, link, data, horaInicio, horaFim, contato);
        }
    }
}