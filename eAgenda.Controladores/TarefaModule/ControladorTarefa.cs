using eAgenda.Controladores.Shared;
using eAgenda.Dominio.TarefaModule;
using System;
using System.Collections.Generic;
using System.Data;

namespace eAgenda.Controladores.TarefaModule
{
    public class ControladorTarefa : Controlador<Tarefa>
    {
        #region Queries
        private const string sqlInserirTarefa =
            @"INSERT INTO [TBTAREFA]
                (
                    [TITULO],       
                    [PRIORIDADE],             
                    [DATACRIACAO],                    
                    [DATACONCLUSAO], 
                    [PERCENTUAL]            
                )
            VALUES
                (
                    @TITULO,
                    @PRIORIDADE,
                    @DATACRIACAO,
                    @DATACONCLUSAO,
                    @PERCENTUAL
                )";

        private const string sqlEditarTarefa =
            @" UPDATE [TBTAREFA]
                SET 
                    [PRIORIDADE] = @PRIORIDADE, 
                    [TITULO] = @TITULO, 
                    [DATACRIACAO] = @DATACRIACAO, 
                    [DATACONCLUSAO] = @DATACONCLUSAO,
                    [PERCENTUAL] = @PERCENTUAL

                WHERE [ID] = @ID";

        private const string sqlExcluirTarefa =
            @"DELETE FROM [TBTAREFA] 
                WHERE [ID] = @ID";

        private const string sqlSelecionarTodasTarefas =
            @"SELECT 
                [ID],       
                [TITULO],       
                [PRIORIDADE],             
                [DATACRIACAO],                    
                [DATACONCLUSAO],
                [PERCENTUAL]
            FROM
                [TBTAREFA] T
            ORDER BY 
                T.PRIORIDADE DESC";

        private const string sqlSelecionarTarefaPorId =
            @"SELECT 
                [ID],
                [TITULO],       
                [PRIORIDADE],        
                [DATACRIACAO],       
                [DATACONCLUSAO],
                [PERCENTUAL]
             FROM
                [TBTAREFA]
             WHERE 
                [ID] = @ID";

        private const string sqlSelecionarTodasTarefasConcluidas =
            @"SELECT 
                [ID],
                [TITULO],       
                [PRIORIDADE],             
                [DATACRIACAO],                    
                [DATACONCLUSAO],
                [PERCENTUAL]
            FROM
                [TBTAREFA] T
            WHERE 
                T.[PERCENTUAL] = 100
            ORDER BY 
                T.[PRIORIDADE] DESC";

        private const string sqlSelecionarTodasTarefasPendentes =
            @"SELECT 
                [ID],
                [TITULO],       
                [PRIORIDADE],             
                [DATACRIACAO],                    
                [DATACONCLUSAO],
                [PERCENTUAL]
            FROM
                [TBTAREFA] T
            WHERE 
                T.[PERCENTUAL] <> 100
            ORDER BY 
                T.[PRIORIDADE] DESC";

        private const string sqlExisteTarefa =
            @"SELECT 
                COUNT(*) 
            FROM 
                [TBTAREFA]
            WHERE 
                [ID] = @ID";

        #endregion


        public override string InserirNovo(Tarefa registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                registro.Id = Db.Insert(sqlInserirTarefa, ObtemParametrosTarefa(registro));
            }

            return resultadoValidacao;
        }

        public override string Editar(int id, Tarefa registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                registro.Id = id;
                Db.Update(sqlEditarTarefa, ObtemParametrosTarefa(registro));
            }

            return resultadoValidacao;
        }

        public override bool Excluir(int id)
        {
            try
            {
                Db.Delete(sqlExcluirTarefa, AdicionarParametro("ID", id));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
        
        public override bool Existe(int id)
        {
            return Db.Exists(sqlExisteTarefa, AdicionarParametro("ID", id));
        }
        
        public override List<Tarefa> SelecionarTodos()
        {
            return Db.GetAll(sqlSelecionarTodasTarefas, ConverterEmTarefa);
        }
        
        public override Tarefa SelecionarPorId(int id)
        {
            return Db.Get(sqlSelecionarTarefaPorId, ConverterEmTarefa, AdicionarParametro("ID", id));
        }


        public void AtualizarPercentual(int id, int novoPercentual)
        {
            Tarefa tarefa = SelecionarPorId(id);

            AtualizarPercentual(tarefa, novoPercentual);
        }

        public void AtualizarPercentual(Tarefa tarefa, int novoPercentual)
        {
            tarefa.AtualizarPercentual(novoPercentual, DateTime.Today);

            Editar(tarefa.Id, tarefa);
        }
                      
        public List<Tarefa> SelecionarTodasTarefasConcluidas()
        {
            return Db.GetAll(sqlSelecionarTodasTarefasConcluidas, ConverterEmTarefa);
        }

        public List<Tarefa> SelecionarTodasTarefasPendentes()
        {
            return Db.GetAll(sqlSelecionarTodasTarefasPendentes, ConverterEmTarefa);
        }

        private Tarefa ConverterEmTarefa(IDataReader reader)
        {
            var titulo = Convert.ToString(reader["TITULO"]);
            var prioridade = Convert.ToInt32(reader["PRIORIDADE"]);
            var dataCriacao = Convert.ToDateTime(reader["DATACRIACAO"]);
            int percentual = Convert.ToInt32(reader["PERCENTUAL"]);

            Tarefa tarefa = new Tarefa(titulo, dataCriacao, (PrioridadeEnum)prioridade);

            DateTime dataConclusao = DateTime.MinValue;

            if (reader["DATACONCLUSAO"] != DBNull.Value)            
                dataConclusao = Convert.ToDateTime(reader["DATACONCLUSAO"]);            

            tarefa.Id = Convert.ToInt32(reader["ID"]);                            
            tarefa.AtualizarPercentual(percentual, dataConclusao);

            return tarefa;
        }

        private Dictionary<string, object> ObtemParametrosTarefa(Tarefa tarefa)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", tarefa.Id);
            parametros.Add("TITULO", tarefa.Titulo);
            parametros.Add("PRIORIDADE", tarefa.Prioridade.Chave);
            parametros.Add("DATACRIACAO", tarefa.DataCriacao);
            parametros.Add("DATACONCLUSAO", tarefa.DataConclusao);
            parametros.Add("PERCENTUAL", tarefa.Percentual);

            return parametros;
        }


    }
}