using eAgenda.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgenda.WindowsApp.Features.Tarefas
{
    public class ConfiguracaoTarefaToolBox : IConfiguracaoToolBox
    {
        public string TipoCadastro
        {
            get { return "Cadastro de Tarefas"; }
        }

        public string ToolTipAdicionar
        {
            get { return "Adicionar uma nova Tarefa"; }
        }

        public string ToolTipEditar
        {
            get { return "Editar uma Tarefa existente"; }
        }

        public string ToolTipExcluir
        {
            get { return "Excluir uma Tarefa existente"; }
        }
    }
}
