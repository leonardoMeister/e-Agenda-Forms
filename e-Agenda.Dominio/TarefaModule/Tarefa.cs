using eAgenda.Dominio.Shared;
using System;
using System.Collections.Generic;

namespace eAgenda.Dominio.TarefaModule
{
    public class Tarefa : EntidadeBase, IEquatable<Tarefa>
    {        
        public Tarefa(string titulo, DateTime dataCriacao, PrioridadeEnum prioridade)
        {            
            Titulo = titulo;
            DataCriacao = dataCriacao.Date;
            Prioridade = new Prioridade(prioridade);            
        }


        public string Titulo { get; }

        public Prioridade Prioridade { get; }

        public DateTime DataCriacao { get;  }

        public int Percentual { get; private set; }

        public DateTime? DataConclusao { get; private set; }        

        public void AtualizarPercentual(int percentual, DateTime dataConclusao)
        {
            Percentual = percentual;

            if (Percentual == 100)
            {
                DataConclusao = dataConclusao;
            }
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Tarefa);
        }

        public bool Equals(Tarefa other)
        {
            return other != null &&
                   Id == other.Id &&
                   Titulo == other.Titulo &&
                   DataConclusao == other.DataConclusao &&
                   Percentual == other.Percentual &&
                   EqualityComparer<Prioridade>.Default.Equals(Prioridade, other.Prioridade) &&
                   DataCriacao == other.DataCriacao;
        }

        public bool EstaConcluida()
        {
            return Percentual == 100;
        }

        public override int GetHashCode()
        {
            int hashCode = -1307587567;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Titulo);
            hashCode = hashCode * -1521134295 + DataConclusao.GetHashCode();
            hashCode = hashCode * -1521134295 + Percentual.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Prioridade>.Default.GetHashCode(Prioridade);
            hashCode = hashCode * -1521134295 + DataCriacao.GetHashCode();
            return hashCode;
        }

        public override string Validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(Titulo))            
                resultadoValidacao = "O campo Título é obrigatório";

            if (DataCriacao == DateTime.MinValue)           
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Data de Criação é obrigatório";
            
            if (resultadoValidacao == "")
                resultadoValidacao = "ESTA_VALIDO";

            return resultadoValidacao;
        }



    }
}