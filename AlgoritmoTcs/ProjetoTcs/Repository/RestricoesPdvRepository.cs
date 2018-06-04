using ProjetoTcs.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjetoTcs.Repository
{
    public class RestricoesPdvRepository : Repository<RestricoesPdv, int>
    {
        public override void Delete(RestricoesPdv entity)
        {
            throw new NotImplementedException();
        }

        public override void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public override List<RestricoesPdv> GetAll()
        {
            string sql = @"SELECT P.NOMEEMPRESA,     P.INICIOATENDIMENTO,
                                  P.FIMATENDIMENTO,  P.TEMPOVISITACAO,
                                  E.CIDADE,          E.RUA 
                                   
                             FROM
                                  PDVFUNCIONARIO AS P
                            INNER JOIN ENDERECO AS E ON E.IDENDERECO = P.IDENDERECO";
            using (var context = new SqlConnection(StringConnection))
            {
                var cmd = new SqlCommand(sql, context);
                List<RestricoesPdv> lista = new List<RestricoesPdv>();
                RestricoesPdv e = null;
                try
                {

                    context.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            e = new RestricoesPdv();
                            e.NomeEmpresa = reader["NOMEEMPRESA"].ToString();
                            e.InicioAtendimento = (TimeSpan)reader["INICIOATENDIMENTO"];
                            e.FimAtendimento = (TimeSpan)reader["TEMPOVISITACAO"];
                            e.Cidade = reader["CIDADE"].ToString();
                            e.Rua = reader["RUA"].ToString();
                            lista.Add(e);
                        }
                    }
                }
                catch (Exception p)
                {

                    throw p;
                }
                return lista;
            }
        }


        public override RestricoesPdv GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override void Save(RestricoesPdv entity)
        {
            throw new NotImplementedException();
        }

        public override void Update(RestricoesPdv entity)
        {
            throw new NotImplementedException();
        }
    }
}