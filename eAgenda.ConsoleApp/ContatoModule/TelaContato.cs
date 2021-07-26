using eAgenda.ConsoleApp.Shared;
using eAgenda.Controladores.ContatoModule;
using eAgenda.Dominio.ContatoModule;
using System;
using System.Collections.Generic;

namespace eAgenda.ConsoleApp.ContatoModule
{
    public class TelaContato : TelaCadastroBasico<Contato>, ICadastravel
    {
        private readonly ControladorContato controladorContato;

        public TelaContato(ControladorContato controlador) : base("Cadastro de Contatos", controlador)
        {
            controladorContato = controlador;
        }

        public override bool VisualizarRegistros(TipoVisualizacao tipo)
        {
            if (tipo == TipoVisualizacao.Pesquisando)
                return base.VisualizarRegistros(TipoVisualizacao.VisualizandoTela);

            if (tipo == TipoVisualizacao.VisualizandoTela)
                ConfigurarTela(SubtituloDeVisualizacao());

            VisualizarContatosAgrupados();

            return true;
        }

        private void VisualizarContatosAgrupados()
        {
            var contatosAgrupadosPorCargo = controladorContato.SelecionarContatosAgrupados(c => c.Cargo);

            Console.WriteLine("\nContatos Agrupados\n");

            if (contatosAgrupadosPorCargo.Count == 0)
                ApresentarMensagem("Nenhum agrupamento encontrado", TipoMensagem.Atencao);

            else
                foreach (var grupo in contatosAgrupadosPorCargo)
                {
                    Console.WriteLine("\nCargo: " + grupo.Campo);
                    Console.WriteLine();
                    ApresentarTabela(grupo.Contatos);
                }
        }

        public override void ApresentarTabela(List<Contato> registros)
        {
            string configuracaoColunasTabela = "{0,-10} | {1,-45} | {2,-25} | {3,-15}";

            MontarCabecalhoTabela(configuracaoColunasTabela, "Id", "Nome", "E-mail", "Telefone");

            foreach (Contato contato in registros)
            {
                Console.WriteLine(configuracaoColunasTabela,
                    contato.Id, contato.Nome, contato.Email, contato.Telefone);
            }
        }

        public override Contato ObterRegistro(TipoAcao tipoAcao)
        {
            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o email: ");
            string email = Console.ReadLine();

            Console.Write("Digite o telefone: ");
            string telefone = Console.ReadLine();

            Console.Write("Digite o cargo: ");
            string cargo = Console.ReadLine();

            Console.Write("Digite a empresa: ");
            string empresa = Console.ReadLine();

            return new Contato(nome, email, telefone, empresa, cargo);
        }
    }
}
