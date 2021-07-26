using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eAgenda.WindowsApp.Features.Tarefas
{
    public partial class FiltroTarefaForm : Form
    {
        public FiltroTarefaForm()
        {
            InitializeComponent();
        }

        public FiltroTarefaEnum TipoFiltro
        {
            get
            {
                if (rdbTarefasConcluidas.Checked)
                    return FiltroTarefaEnum.TarefasConcluidas;

                else if (rdbTarefasPendentes.Checked)
                    return FiltroTarefaEnum.TarefasPendentes;

                else
                    return FiltroTarefaEnum.TodasTarefas;
            }
        }
       
    }
}
