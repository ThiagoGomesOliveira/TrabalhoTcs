using ProjetoTcs.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjetoTcs.Repository
{
    public class PdvFuncionarioRepository : Repository<PdvFuncionario, int>
    {
        public override void Delete(PdvFuncionario entity)
        {
            using (var context = new SqlConnection(StringConnection))
            {

                string sql = "DELETE FROM PDVFUNCIONARIO WHERE IDPDVFUNCIONARIO =@ID";
                SqlCommand cmd = new SqlCommand(sql, context);
                cmd.Parameters.AddWithValue("@ID", entity.IdPdvFuncionario);
                try
                {
                    context.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {

                    throw e;
                }
            }
        }

        public override void DeleteById(int id)
        {
            using (var context = new SqlConnection(StringConnection))
            {

                string sql = "DELETE FROM PDVFUNCIONARIO WHERE IDPDVFUNCIONARIO = @ID";
                SqlCommand cmd = new SqlCommand(sql, context);
                cmd.Parameters.AddWithValue("@ID", id);
                try
                {
                    context.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public List<PdvFuncionario> GetPdvsId(int idFuncionario)
        {

            string sql = @"SELECT IDPDVFUNCIONARIO , NOMEEMPRESA,
                                  INICIOATENDIMENTO, FIMATENDIMENTO,
                                  TEMPOVISITACAO, IDENDERECO ,IDFUNCIONARIO
                             FROM PDVFUNCIONARIO
                            WHERE IDFUNCIONARIO = @ID";
            using (var context = new SqlConnection(StringConnection))
            {
                var cmd = new SqlCommand(sql, context);
                cmd.Parameters.AddWithValue("@ID", idFuncionario);
                List<PdvFuncionario> lista = new List<PdvFuncionario>();
                PdvFuncionario e = null;
                try
                {

                    context.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            e = new PdvFuncionario();
                            e.IdPdvFuncionario = (int)reader["IDPDVFUNCIONARIO"];
                            e.NomeEmpresa = reader["NOMEEMPRESA"].ToString();
                            e.InicioAtendimento = (TimeSpan)reader["INICIOATENDIMENTO"];
                            e.FimAtendimento = (TimeSpan)reader["FIMATENDIMENTO"];
                            e.TempoVisitacao = (TimeSpan)reader["TEMPOVISITACAO"];
                            e.IdEndereco = (int)reader["IDENDERECO"];
                            e.IdFuncionario = (int)reader["IDFUNCIONARIO"];
                            lista.Add(e);
                        }

                    }
                }catch (Exception p)
                {

                    throw p;
                }
                return lista;
            }

        }

        public override List<PdvFuncionario> GetAll()
        {
            string sql = @"SELECT  IDPDVFUNCIONARIO,  NOMEEMPRESA,
                                  INICIOATENDIMENTO,  FIMATENDIMENTO,
                                     TEMPOVISITACAO,  IDENDERECO , 
                                     IDFUNCIONARIO
                             FROM
                                  PDVFUNCIONARIO";
            using (var context = new SqlConnection(StringConnection))
            {
                var cmd = new SqlCommand(sql, context);
                List<PdvFuncionario> lista = new List<PdvFuncionario>();
                PdvFuncionario e = null;
                try
                {

                    context.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            e = new PdvFuncionario();
                            e.IdPdvFuncionario = (int)reader["IDPDVFUNCIONARIO"];
                            e.NomeEmpresa = reader["NOMEEMPRESA"].ToString();
                            e.InicioAtendimento = (TimeSpan)reader["INICIOATENDIMENTO"];
                            e.FimAtendimento = (TimeSpan)reader["FIMATENDIMENTO"];
                            e.FimAtendimento = (TimeSpan)reader["TEMPOVISITACAO"];
                            e.IdEndereco = (int)reader["IDENDERECO"];
                            e.IdFuncionario = (int)reader["IDFUNCIONARIO"];
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

        public override PdvFuncionario GetById(int id)
        {
            using (var context = new SqlConnection(StringConnection))
            {
                string sql = @"SELECT IDPDVFUNCIONARIO,  NOMEEMPRESA,
                                      INICIOATENDIMENTO, FIMATENDIMENTO
                                      TEMPOVISITACAO, IDENDERECO ,
                                      IDFUNCIONARIO
                                 FROM PDVFUNCIONARIO
                                WHERE IDPDVFUNCIONARIO = @ID";
                SqlCommand cmd = new SqlCommand(sql, context);
                cmd.Parameters.AddWithValue("@ID", id);
                PdvFuncionario e = null;
                try
                {
                    context.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                e = new PdvFuncionario();
                                e.IdPdvFuncionario = (int)reader["IDPDVFUNCIONARIO"];
                                e.NomeEmpresa = reader["NOMEEMPRESA"].ToString();
                                e.InicioAtendimento = (TimeSpan)reader["INCIOATENDIMENTO"];
                                e.FimAtendimento = (TimeSpan)reader["FIMATENDIMENTO"];
                                e.TempoVisitacao = (TimeSpan)reader["TEMPOVISITACAO"];
                                e.IdEndereco = (int)reader["IDENDERECO"];
                                e.IdFuncionario = (int)reader["IDFUNCIONARIO"];
                            }
                        }
                    }
                }
                catch (Exception p)
                {

                    throw p;
                }
                return e;
            }
        }

        public override void Save(PdvFuncionario entity)
        {
            using (var context = new SqlConnection(StringConnection))
            {
                string sql = @"INSERT 
                                 INTO PDVFUNCIONARIO 
                                      (NOMEEMPRESA,   INICIOATENDIMENTO,
                                       FIMATENDIMENTO,TEMPOVISITACAO,
                                       IDENDERECO, IDFUNCIONARIO) 
                               VALUES 
                                       (@NOMEEMPRESA,   @INICIOATENDIMENTO,
                                        @FIMATENDIMENTO @TEMPOVISITACAO,
                                        @IDENDERECO,@IDFUNCIONARIO)";
                SqlCommand cmd = new SqlCommand(sql, context);
                cmd.Parameters.AddWithValue("@NOMEEMPRESA", entity.NomeEmpresa);
                cmd.Parameters.AddWithValue("@INICIOATENDIMENTO", entity.InicioAtendimento);
                cmd.Parameters.AddWithValue("@FIMATENDIMENTO", entity.FimAtendimento);
                cmd.Parameters.AddWithValue("@TEMPOVISITACAO", entity.TempoVisitacao);
                cmd.Parameters.AddWithValue("@IDENDERECO", entity.IdEndereco);
                cmd.Parameters.AddWithValue("@IDFUNCIONARIO", entity.IdFuncionario);
                try
                {
                    context.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception p)
                {

                    throw p;
                }
            }
        }

        public override void Update(PdvFuncionario entity)
        {
            using (var context = new SqlConnection(StringConnection))
            {
                string sql = @"UPDATE PDVFUNCIONARIO 
                                  SET NOMEEMPRESA = @NOMEEMPRESA , 
                                      INICIOATENDIMENTO = @INICIOATENDIMENTO ,
                                      FIMATENDIMENTO = @FIMATENDIMENTO
                                      TEMPOVISITACAO = @TEMPOVISITACAO
                                      IDENDERECO = @IDENDERECO
                                      IDFUNCIONARIO = @IDFUNCIONARIO
                                WHERE IDPDVFUNCIONARIO = @ID";
                SqlCommand cmd = new SqlCommand(sql, context);
                cmd.Parameters.AddWithValue("@ID", entity.IdPdvFuncionario);
                cmd.Parameters.AddWithValue("@NOMEEMPRESA", entity.NomeEmpresa);
                cmd.Parameters.AddWithValue("@INICIOATENDIMENTO", entity.InicioAtendimento);
                cmd.Parameters.AddWithValue("@FIMATENDIMENTO", entity.FimAtendimento);
                cmd.Parameters.AddWithValue("@TEMPOVISITACAO", entity.TempoVisitacao);
                cmd.Parameters.AddWithValue("@ENDERECO", entity.IdEndereco);
                cmd.Parameters.AddWithValue("@IDFUNCIOANRIO", entity.IdFuncionario);
                try
                {
                    context.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception p)
                {

                    throw p;
                }
            }
        }
    }
}