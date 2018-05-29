using ProjetoTcs.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjetoTcs.Repository
{
    public class RotaRepository : Repository<Rota, int>
    {
        public override void Delete(Rota entity)
        {
            using (var context = new SqlConnection(StringConnection))
            {

                string sql = "DELETE FROM ROTA WHERE IDROTA =@ID";
                SqlCommand cmd = new SqlCommand(sql, context);
                cmd.Parameters.AddWithValue("@ID", entity.IDRota);
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

                string sql = "DELETE FROM ROTA WHERE IDROTA = @ID";
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
        

        public override List<Rota> GetAll()
        {
            string sql = @"SELECT  IDROTA,  IDPDVFUNCIONARIO, IDFUNCIONARIO,DATAATENDIMENTO
                             FROM  ROTA";
            using (var context = new SqlConnection(StringConnection))
            {
                var cmd = new SqlCommand(sql, context);
                List<Rota> lista = new List<Rota>();
                Rota e = null;
                try
                {

                    context.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            e = new Rota();
                            e.IDRota = (int)reader["IDROTA"];
                            e.IDPdvFuncionario = (int)reader["IDPDVFUNCIONARIO"];
                            e.IDFuncionario = (int)reader["IDFUNCIONARIO"];
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

        public override Rota GetById(int id)
        {
            using (var context = new SqlConnection(StringConnection))
            {
                string sql = @"SELECT IDROTA,  IDPDVFUNCIONARIO, IDFUNCIONARIO ,DATAATENDIMENTO
                                 FROM ROTA
                                WHERE IDROTA = @ID";
                SqlCommand cmd = new SqlCommand(sql, context);
                cmd.Parameters.AddWithValue("@ID", id);
                Rota e = null;
                try
                {
                    context.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                e = new Rota();
                                e.IDRota = (int)reader["IDROTA"];
                                e.IDPdvFuncionario =(int) reader["IDPDVFUNCIONARIO"];
                                e.IDFuncionario = (int)reader["IDFUNCIONARIO"];
                                e.DataAtendimento = (DateTime)reader["DATAATENDIMENTO"];
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

        public override void Save(Rota entity)
        {
            using (var context = new SqlConnection(StringConnection))
            {
                string sql = @"INSERT INTO ROTA (IDPDVFUNCIONARIO,IDFUNCIONARIO,DATAATENDIMENTO) 
                               VALUES (@IDPDVFUNCIONARIO,@IDFUNCIONARIO,@DATAATENDIMENTO)";
                SqlCommand cmd = new SqlCommand(sql, context);
                cmd.Parameters.AddWithValue("@IDPDVFUNCIONARIO",entity.IDPdvFuncionario);
                cmd.Parameters.AddWithValue("@IDFUNCIONARIO", entity.IDFuncionario);
                cmd.Parameters.AddWithValue("@DATAATENDIMENTO", entity.DataAtendimento);
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

        public override void Update(Rota entity)
        {
            using (var context = new SqlConnection(StringConnection))
            {
                string sql = @"UPDATE ROTA 
                                  SET IDPDVFUNCIONARIO = @IDPDVFUNCIONARIO , 
                                      IDFUNCIONARIO = @IDFUNCIONARIO ,
                                      DATAATENDIMENTO = @DATAATENDIMENTO
                                WHERE ROTA = @ID";
                SqlCommand cmd = new SqlCommand(sql, context);
                cmd.Parameters.AddWithValue("@ID", entity.IDRota);
                cmd.Parameters.AddWithValue("@IDPDVFUNCIONARIO", entity.IDPdvFuncionario);
                cmd.Parameters.AddWithValue("@IDFUNCIONARIO", entity.IDPdvFuncionario);
                cmd.Parameters.AddWithValue("@DATAATENDIMENTO",entity.DataAtendimento);
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