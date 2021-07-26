using eAgenda.Controladores.Shared;
using eAgenda.Dominio.CompromissoModule;
using eAgenda.Dominio.ContatoModule;
using System;
using System.Collections.Generic;
using System.Data;

namespace eAgenda.Controladores.CompromissoModule
{
    public class ControladorCompromisso : Controlador<Compromisso>
    {
        #region Queries
        private const string sqlInserirCompromisso =
            @"INSERT INTO [TBCOMPROMISSO]
                (
                    [LOCAL],       
                    [DATA], 
                    [ASSUNTO],
                    [HORAINICIO],                    
                    [HORATERMINO],                                                           
                    [ID_CONTATO],
                    [LINK]            
                )
            VALUES
                (
                    @LOCAL,
                    @DATA,
                    @ASSUNTO,
                    @HORAINICIO,
                    @HORATERMINO,
                    @ID_CONTATO,
                    @LINK
                )";

        private const string sqlEditarCompromisso =
            @" UPDATE [TBCOMPROMISSO]
                SET 
                    [LOCAL] = @LOCAL, 
                    [DATA] = @DATA, 
                    [ASSUNTO] = @ASSUNTO,
                    [HORAINICIO] = @HORAINICIO, 
                    [HORATERMINO] = @HORATERMINO,
                    [ID_CONTATO] =@ID_CONTATO,
                    [LINK] = @LINK

                WHERE [ID] = @ID";

        private const string sqlExcluirCompromisso =
            @"DELETE FROM [TBCOMPROMISSO] 
                WHERE [ID] = @ID";

        private const string sqlSelecionarTodosCompromissos =
            @"SELECT 
                CP.[ID],       
                CP.[DATA],
                CP.[ASSUNTO],
                CP.[LOCAL],             
                CP.[HORAINICIO],                    
                CP.[HORATERMINO],                                
                CP.[ID_CONTATO],
                CP.[LINK],
                CT.[NOME],       
                CT.[EMAIL],             
                CT.[TELEFONE],                    
                CT.[CARGO], 
                CT.[EMPRESA] 
            FROM
                [TBCOMPROMISSO] AS CP LEFT JOIN 
                [TBCONTATO] AS CT
            ON
                CT.ID = CP.ID_CONTATO";

        private const string sqlSelecionarCompromissoPorId =
            @"SELECT 
                CP.[ID],       
                CP.[DATA],
                CP.[ASSUNTO],
                CP.[LOCAL],             
                CP.[HORAINICIO],                    
                CP.[HORATERMINO],                                
                CP.[ID_CONTATO],
                CP.[LINK],
                CT.[NOME],       
                CT.[EMAIL],             
                CT.[TELEFONE],                    
                CT.[CARGO], 
                CT.[EMPRESA] 
            FROM
                [TBCOMPROMISSO] AS CP LEFT JOIN 
                [TBCONTATO] AS CT
            ON
                CT.ID = CP.ID_CONTATO
            WHERE 
                CP.[ID] = @ID";

        private const string sqlSelecionarTodosCompromissosPassados =
            @"SELECT 
                CP.[ID],       
                CP.[DATA],
                CP.[ASSUNTO],
                CP.[LOCAL],             
                CP.[HORAINICIO],                    
                CP.[HORATERMINO],                                
                CP.[ID_CONTATO],
                CP.[LINK],
                CT.[NOME],       
                CT.[EMAIL],             
                CT.[TELEFONE],                    
                CT.[CARGO], 
                CT.[EMPRESA] 
            FROM
                [TBCOMPROMISSO] AS CP LEFT JOIN 
                [TBCONTATO] AS CT
            ON
                CT.ID = CP.ID_CONTATO
            WHERE 
                CP.[DATA] <= @DATA";

        private const string sqlSelecionarTodosCompromissosFuturos =
            @"SELECT 
                CP.[ID],       
                CP.[DATA],
                CP.[ASSUNTO],
                CP.[LOCAL],             
                CP.[HORAINICIO],                    
                CP.[HORATERMINO],                                
                CP.[ID_CONTATO],
                CP.[LINK],
                CT.[NOME],       
                CT.[EMAIL],             
                CT.[TELEFONE],                    
                CT.[CARGO], 
                CT.[EMPRESA] 
            FROM
                [TBCOMPROMISSO] AS CP LEFT JOIN 
                [TBCONTATO] AS CT
            ON
                CT.ID = CP.ID_CONTATO
            WHERE 
                CP.[DATA] BETWEEN @DATAINICIO AND @DATAFIM";

        private const string sqlExisteCompromisso =
            @"SELECT 
                COUNT(*) 
            FROM 
                [TBCOMPROMISSO]
            WHERE 
                [ID] = @ID";

        private const string sqlVerificarHorarioOcupado =
            @"SELECT
	            COUNT(*)
            FROM 
	            TBCOMPROMISSO
            WHERE 
                [DATA] = @DATA 
            AND 
                @HORA_INICIO_DESEJADO BETWEEN HORAINICIO AND HORATERMINO 
            OR 
                @HORA_TERMINO_DESEJADO BETWEEN HORAINICIO AND HORATERMINO";

        #endregion

        public override string InserirNovo(Compromisso registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                bool horarioOcupado = VerificarHorarioOcupado(registro.Data, registro.HoraInicio, registro.HoraTermino);

                if (horarioOcupado)
                    resultadoValidacao = "Nesta data e horário já tem um compromisso agendado";
                else
                    registro.Id = Db.Insert(sqlInserirCompromisso, ObtemParametrosCompromisso(registro));
            }

            return resultadoValidacao;
        }

        public override string Editar(int id, Compromisso registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                registro.Id = id;
                Db.Update(sqlEditarCompromisso, ObtemParametrosCompromisso(registro));
            }

            return resultadoValidacao;
        }

        public override bool Excluir(int id)
        {
            try
            {
                Db.Delete(sqlExcluirCompromisso, AdicionarParametro("ID", id));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public override bool Existe(int id)
        {
            return Db.Exists(sqlExisteCompromisso, AdicionarParametro("ID", id));
        }

        public override Compromisso SelecionarPorId(int id)
        {
            return Db.Get(sqlSelecionarCompromissoPorId, ConverterEmCompromisso, AdicionarParametro("ID", id));
        }

        public override List<Compromisso> SelecionarTodos()
        {
            return Db.GetAll(sqlSelecionarTodosCompromissos, ConverterEmCompromisso);
        }

        public List<Compromisso> SelecionarCompromissosFuturos(DateTime dataInicio, DateTime dataFim)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("DATAINICIO", dataInicio);
            parametros.Add("DATAFIM", dataFim);

            return Db.GetAll(sqlSelecionarTodosCompromissosFuturos, ConverterEmCompromisso, parametros);
        }

        public List<Compromisso> SelecionarCompromissosPassados(DateTime data)
        {
            return Db.GetAll(sqlSelecionarTodosCompromissosPassados, ConverterEmCompromisso, AdicionarParametro("DATA", data));
        }

        /// <summary>
        /// //https://stackoverflow.com/questions/8503825/what-is-the-correct-sql-type-to-store-a-net-timespan-with-values-240000
        /// </summary>
        public bool VerificarHorarioOcupado(DateTime data, TimeSpan horaInicioDesejado, TimeSpan horaTerminoDesejado)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("DATA", data);

            parametros.Add("HORA_INICIO_DESEJADO", horaInicioDesejado.Ticks);
            parametros.Add("HORA_TERMINO_DESEJADO", horaTerminoDesejado.Ticks);

            return Db.Exists(sqlVerificarHorarioOcupado, parametros);
        }

        private Compromisso ConverterEmCompromisso(IDataReader reader)
        {
            var assunto = Convert.ToString(reader["ASSUNTO"]);
            var local = Convert.ToString(reader["LOCAL"]);
            var link = Convert.ToString(reader["LINK"]);
            var dataDoCompromisso = Convert.ToDateTime(reader["DATA"]);
            var horaInicio = TimeSpan.FromTicks(Convert.ToInt64(reader["HORAINICIO"]));
            var horaTermino = TimeSpan.FromTicks(Convert.ToInt64(reader["HORATERMINO"]));

            var email = Convert.ToString(reader["EMAIL"]);
            var nome = Convert.ToString(reader["NOME"]);
            var telefone = Convert.ToString(reader["TELEFONE"]);
            var empresa = Convert.ToString(reader["EMPRESA"]);
            var cargo = Convert.ToString(reader["CARGO"]);

            Contato contato = null;
            if (reader["ID_CONTATO"] != DBNull.Value)
            {
                contato = new Contato(nome, email, telefone, empresa, cargo);
                contato.Id = Convert.ToInt32(reader["ID_CONTATO"]);
            }

            Compromisso compromisso = new Compromisso(assunto, local, link, dataDoCompromisso, horaInicio, horaTermino, contato);
            compromisso.Id = Convert.ToInt32(reader["ID"]);

            return compromisso;
        }

        private Dictionary<string, object> ObtemParametrosCompromisso(Compromisso compromisso)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", compromisso.Id);
            parametros.Add("ASSUNTO", compromisso.Assunto);
            parametros.Add("LOCAL", compromisso.Local);
            parametros.Add("LINK", compromisso.Link);
            parametros.Add("DATA", compromisso.Data);
            parametros.Add("HORAINICIO", compromisso.HoraInicio.Ticks);
            parametros.Add("HORATERMINO", compromisso.HoraTermino.Ticks);
            parametros.Add("ID_CONTATO", compromisso.Contato?.Id);

            return parametros;
        }
    }
}
