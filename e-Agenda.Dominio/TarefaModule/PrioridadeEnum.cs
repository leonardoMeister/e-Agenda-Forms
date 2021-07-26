using System.ComponentModel;

namespace eAgenda.Dominio.TarefaModule
{
    public enum PrioridadeEnum : int
    {
        [Description("Prioridade Baixa")]
        Baixa = 0,

        [Description("Prioridade Normal")]
        Normal = 1,

        [Description("Prioridade Alta")]
        Alta = 2
    }
}