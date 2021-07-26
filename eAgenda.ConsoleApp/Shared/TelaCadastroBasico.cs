using eAgenda.Controladores.Shared;
using eAgenda.Dominio.Shared;
using System;
using System.Collections.Generic;

namespace eAgenda.ConsoleApp.Shared
{
    public abstract class TelaCadastroBasico<T> : TelaBase, ICadastravel
        where T : EntidadeBase
    {
        protected Controlador<T> controlador;

        public TelaCadastroBasico(string titulo, Controlador<T> controlador)
            : base(titulo)
        {
            this.controlador = controlador;
        }

        //métodos ICadastrável
        public void InserirNovoRegistro()
        {
            ConfigurarTela(SubtituloDeInsercao());

            T registro = ObterRegistro(TipoAcao.Inserindo);

            string resultadoValidacao = controlador.InserirNovo(registro);

            if (resultadoValidacao == "ESTA_VALIDO")
                ApresentarMensagem(MensagemDeInsercaoComSucesso(), TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem(resultadoValidacao, TipoMensagem.Erro);
                InserirNovoRegistro();
            }
        }

        public virtual void EditarRegistro()
        {
            ConfigurarTela(SubtituloDeEdicao());

            bool temRegistros = VisualizarRegistros(TipoVisualizacao.Pesquisando);

            if (temRegistros == false)
                return;

            Console.Write("\n" + PerguntaEdicaoQualRegistro());
            int id = Convert.ToInt32(Console.ReadLine());

            bool numeroEncontrado = controlador.Existe(id);
            if (numeroEncontrado == false)
            {
                ApresentarMensagem(MensagemDeRegistroNaoEncontrado() + id, TipoMensagem.Erro);
                EditarRegistro();
                return;
            }

            T registro = ObterRegistro(TipoAcao.Editando);

            string resultadoValidacao = controlador.Editar(id, registro);

            if (resultadoValidacao == "ESTA_VALIDO")
                ApresentarMensagem(MensagemDeEdicaoComSucesso(), TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem(resultadoValidacao, TipoMensagem.Erro);
                EditarRegistro();
            }
        }

        public void ExcluirRegistro()
        {
            ConfigurarTela(SubtituloDeExclusao());

            bool temRegistros = VisualizarRegistros(TipoVisualizacao.Pesquisando);

            if (temRegistros == false)
                return;

            Console.Write("\n" + PerguntaExclusaoQualRegistro());
            int id = Convert.ToInt32(Console.ReadLine());

            bool numeroEncontrado = controlador.Existe(id);
            if (numeroEncontrado == false)
            {
                ApresentarMensagem(MensagemDeRegistroNaoEncontrado() + id, TipoMensagem.Erro);
                ExcluirRegistro();
                return;
            }

            bool conseguiuExcluir = controlador.Excluir(id);

            if (conseguiuExcluir)
                ApresentarMensagem(MensagemDeExclusaoComSucesso(), TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem(MensagemDeExclusaoComErro(), TipoMensagem.Erro);
                ExcluirRegistro();
            }
        }

        public virtual bool VisualizarRegistros(TipoVisualizacao tipo)
        {
            if (tipo == TipoVisualizacao.VisualizandoTela)
                ConfigurarTela(SubtituloDeVisualizacao());

            var registros = controlador.SelecionarTodos();

            if (registros.Count == 0)
            {
                ApresentarMensagem(MensagemDeRegistrosNaoCadastrados(), TipoMensagem.Atencao);
                return false;
            }

            ApresentarTabela(registros);

            return true;
        }

        //métodos virtuais
        public virtual string MensagemDeInsercaoComSucesso()
        {
            return "Registro inserido com sucesso!";
        }

        public virtual string MensagemDeEdicaoComSucesso()
        {
            return "Registro alterado com sucesso!";
        }

        public virtual string MensagemDeExclusaoComSucesso()
        {
            return "Registro excluído com sucesso!";
        }

        public virtual string MensagemDeExclusaoComErro()
        {
            return "Falha ao tentar excluir o registro!";
        }

        public virtual string MensagemDeRegistroNaoEncontrado()
        {
            return "Nenhum registro foi encontrado com este número: ";
        }

        public virtual string MensagemDeRegistrosNaoCadastrados()
        {
            return "Nenhum registro cadastrado!";
        }

        public virtual string SubtituloDeInsercao()
        {
            return "Inserindo um novo registro...";
        }

        public virtual string SubtituloDeEdicao()
        {
            return "Editando um registro...";
        }

        public virtual string SubtituloDeExclusao()
        {
            return "Excluindo um registro...";
        }

        public virtual string SubtituloDeVisualizacao()
        {
            return "Visualizando registros...";
        }

        public virtual string PerguntaEdicaoQualRegistro()
        {
            return "Digite o número do registro que deseja alterar:";
        }

        public virtual string PerguntaExclusaoQualRegistro()
        {
            return "Digite o número do registro que deseja excluir:";
        }

        //métodos abstratos
        public abstract void ApresentarTabela(List<T> registros);

        public abstract T ObterRegistro(TipoAcao tipoAcao);

    }
}
