using eAgenda.Controladores.Shared;
using eAgenda.Dominio.ContatoModule;
using System;
using System.Collections.Generic;
using System.Data;

namespace eAgenda.Controladores.ContatoModule
{
    public class ControladorContato : Controlador<Contato>
    {
        private const string sqlInserirContato =
            @"INSERT INTO TBCONTATO 
	                (
		                [NOME], 
		                [EMAIL], 
		                [TELEFONE],
                        [CARGO], 
		                [EMPRESA]
	                ) 
	                VALUES
	                (
                        @NOME, 
                        @EMAIL,
                        @TELEFONE,
		                @CARGO, 
		                @EMPRESA
	                )";

        private const string sqlEditarContato =
            @"UPDATE TBCONTATO
                    SET
                        [NOME] = @NOME,
		                [EMAIL] = @EMAIL, 
		                [TELEFONE] = @TELEFONE,
                        [CARGO] = @CARGO,
                        [EMPRESA] = @EMPRESA
                    WHERE 
                        ID = @ID";

        private const string sqlExcluirContato =
            @"DELETE 
	                FROM
                        TBCONTATO
                    WHERE 
                        ID = @ID";

        private const string sqlSelecionarContatoPorId =
            @"SELECT
                        [ID],
		                [NOME], 
		                [EMAIL], 
		                [TELEFONE],
                        [CARGO], 
		                [EMPRESA]
	                FROM
                        TBCONTATO
                    WHERE 
                        ID = @ID";

        private const string sqlSelecionarTodosContatos =
            @"SELECT
                        [ID],
		                [NOME], 
		                [EMAIL], 
		                [TELEFONE],
                        [CARGO], 
		                [EMPRESA]
	                FROM
                        TBCONTATO ORDER BY CARGO;";

        private const string sqlExisteContato =
            @"SELECT 
                COUNT(*) 
            FROM 
                [TBCONTATO]
            WHERE 
                [ID] = @ID";

        public override string InserirNovo(Contato registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                registro.Id = Db.Insert(sqlInserirContato, ObtemParametrosContato(registro));
            }

            return resultadoValidacao;
        }

        public override string Editar(int id, Contato registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                registro.Id = id;
                Db.Update(sqlEditarContato, ObtemParametrosContato(registro));
            }

            return resultadoValidacao;
        }

        public override bool Excluir(int id)
        {
            try
            {
                Db.Delete(sqlExcluirContato, AdicionarParametro("ID", id));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public override bool Existe(int id)
        {
            return Db.Exists(sqlExisteContato, AdicionarParametro("ID", id));
        }

        public override Contato SelecionarPorId(int id)
        {
            return Db.Get(sqlSelecionarContatoPorId, ConverterEmContato, AdicionarParametro("ID", id));
        }

        public override List<Contato> SelecionarTodos()
        {
            return Db.GetAll(sqlSelecionarTodosContatos, ConverterEmContato);
        }

        public List<GrupoContato> SelecionarContatosAgrupados(Func<Contato, string> campo)
        {
            var contatos = Db.GetAll(sqlSelecionarTodosContatos, ConverterEmContato);

            return new AgrupadorContato().Agrupar(contatos, campo);
        }

        private Dictionary<string, object> ObtemParametrosContato(Contato contato)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", contato.Id);
            parametros.Add("NOME", contato.Nome);
            parametros.Add("EMAIL", contato.Email);
            parametros.Add("TELEFONE", contato.Telefone);
            parametros.Add("CARGO", contato.Cargo);
            parametros.Add("EMPRESA", contato.Empresa);

            return parametros;
        }

        private Contato ConverterEmContato(IDataReader reader)
        {
            int id = Convert.ToInt32(reader["ID"]);
            string nome = Convert.ToString(reader["NOME"]);
            string email = Convert.ToString(reader["EMAIL"]);
            string telefone = Convert.ToString(reader["TELEFONE"]);
            string cargo = Convert.ToString(reader["CARGO"]);
            string empresa = Convert.ToString(reader["EMPRESA"]);

            Contato contato = new Contato(nome, email, telefone, empresa, cargo);

            contato.Id = id;

            return contato;
        }



    }
}
