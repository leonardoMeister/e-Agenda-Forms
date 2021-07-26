using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eAgenda.WindowsApp.Features.Compromissos
{
    public partial class FiltroCompromissoForm : Form
    {
        public FiltroCompromissoForm()
        {
            InitializeComponent();
        }

        public FiltroCompromissoEnum TipoFiltro
        {
            get
            {
                if (rdbCompromissosFuturos.Checked) return FiltroCompromissoEnum.FiltroFuturos;

                if (rdbCompromissosPassados.Checked) return FiltroCompromissoEnum.FiltroPassados;
                
                if (rdbProxima24Horas.Checked) return FiltroCompromissoEnum.FiltroProximas24Horas;

                if (rdbProximaSemana.Checked) return FiltroCompromissoEnum.FiltroProximaSemana;

                if (rdbProximoMes.Checked) return FiltroCompromissoEnum.FiltroProximoMes;

                return FiltroCompromissoEnum.FiltroTodosCompromissos;
            }
        }
    }
}
