using ProjetoTcs.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjetoTcs.Repository
{
    public class RotaDosFunionariosRepository : Repository<RotaDosFuncionarios, int>
    {
        public override void Delete(RotaDosFuncionarios entity)
        {
            throw new NotImplementedException();
        }

        public override void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public override List<RotaDosFuncionarios> GetAll()
        {
            string sql = @"
SELECT R.IDROTA, 
       P.NOMEEMPRESA,
       F.NOME,
       E.CIDADE,
       E.RUA 
  FROM ROTA AS R
 INNER JOIN PdvFuncionario AS P ON P.IdPdvFuncionario = R.IdPdvFuncionario
 INNER JOIN Funcionario AS F ON F.IDFuncionario = R.IDFuncionario
 INNER JOIN Endereco AS E ON E.IDEndereco = P.IDEndereco";
            using (var context = new SqlConnection(StringConnection))
            {
                var cmd = new SqlCommand(sql, context);
                List<RotaDosFuncionarios> lista = new List<RotaDosFuncionarios>();
                RotaDosFuncionarios e = null;
                try
                {

                    context.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            e = new RotaDosFuncionarios();
                            e.IdRota = (int)reader["IDROTA"];
                            e.PdvFuncionario = reader["NOMEEMPRESA"].ToString();
                            e.Funcionario = reader["NOME"].ToString();
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
        public List<RotaDosFuncionarios> BuscarRotas(DateTime dataInicio, DateTime dataFim)
        {
            string sql = @"
SELECT R.IDROTA, 
       R.DATAATENDIMENTO,
       P.NOMEEMPRESA,
       F.NOME,
       E.CIDADE,
       E.RUA 
  FROM ROTA AS R
 INNER JOIN PdvFuncionario AS P ON P.IdPdvFuncionario = R.IdPdvFuncionario
 INNER JOIN Funcionario AS F ON F.IDFuncionario = R.IDFuncionario
 INNER JOIN Endereco AS E ON E.IDEndereco = P.IDEndereco  
 WHERE R.DATAATENDIMENTO >= @DATAINICIO
    AND DATAATENDIMENTO <= @DATAFIM";
            using (var context = new SqlConnection(StringConnection))
            {
                var cmd = new SqlCommand(sql, context);
                cmd.Parameters.AddWithValue("@DATAINICIO", dataInicio);
                cmd.Parameters.AddWithValue("@DATAFIM", dataFim);
                List<RotaDosFuncionarios> lista = new List<RotaDosFuncionarios>();
                RotaDosFuncionarios e = null;
                try
                {

                    context.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            e = new RotaDosFuncionarios();
                            e.IdRota = (int)reader["IDROTA"];
                            e.PdvFuncionario = reader["NOMEEMPRESA"].ToString();
                            e.Funcionario = reader["NOME"].ToString();
                            e.Cidade = reader["CIDADE"].ToString();
                            e.Rua = reader["RUA"].ToString();
                            e.DataAtendimento = (DateTime)reader["DATAATENDIMENTO"];
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

        public override RotaDosFuncionarios GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override void Save(RotaDosFuncionarios entity)
        {
            throw new NotImplementedException();
        }

        public override void Update(RotaDosFuncionarios entity)
        {
            throw new NotImplementedException();
        }
    }
}