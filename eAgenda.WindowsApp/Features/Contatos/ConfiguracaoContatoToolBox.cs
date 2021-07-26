using eAgenda.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgenda.WindowsApp.Features.Contatos
{
    public class ConfiguracaoContatoToolBox : IConfiguracaoToolBox
    {        
        public string TipoCadastro
        {
            get { return "Cadastro de Contatos"; }            
        }

        public string ToolTipAdicionar
        {
            get { return "Adicionar um novo Contato"; }
        }

        public string ToolTipEditar
        {
            get { return "Editar um Contato existente"; }
        }

        public string ToolTipExcluir
        {
            get { return "Excluir um Contato existente"; }
        }

    }
}
