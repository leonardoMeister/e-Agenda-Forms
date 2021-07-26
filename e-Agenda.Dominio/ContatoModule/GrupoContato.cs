using System.Collections.Generic;

namespace eAgenda.Dominio.ContatoModule
{
    public class GrupoContato
    {
        public GrupoContato(string campo)
        {
            Campo = campo;
            Contatos = new List<Contato>();
        }

        public string Campo { get; set; }

        public List<Contato> Contatos { get; set; }

        public void AdicionarContato(Contato c)
        {
            Contatos.Add(c);
        }
    }
}
