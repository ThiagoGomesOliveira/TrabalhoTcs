using ProjetoTcs.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjetoTcs.Repository
{
    public class EnderecoRepository : Repository<Endereco, int>
    {
        public override void Delete(Endereco entity)
        {
            using (var context = new SqlConnection(StringConnection))
            {
                string sql = "DELETE FROM ENDERECO WHERE IDENDERECO =@ID";
                SqlCommand cmd = new SqlCommand(sql, context);
                cmd.Parameters.AddWithValue("@ID", entity.IDEndereco);
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

                string sql = "DELETE FROM ENDERECO WHERE IDENDERECO = @ID";
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

        public override List<Endereco> GetAll()
        {
            string sql = "SELECT IDENDERECO,RUA,CIDADE FROM ENDERECO";
            using (var context = new SqlConnection(StringConnection))
            {
                var cmd = new SqlCommand(sql, context);
                List<Endereco> lista = new List<Endereco>();
                Endereco e = null;
                try
                {

                    context.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            e = new Endereco();
                            e.IDEndereco = (int)reader["IDENDERECO"];
                            e.Rua = reader["RUA"].ToString();
                            e.Cidade = reader["CIDADE"].ToString();
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

        public override Endereco GetById(int id)
        {
            using (var context = new SqlConnection(StringConnection))
            {
                string sql = "SELECT IDENDERECO,RUA,CIDADE FROM ENDERECO WHERE IDENDERECO = @ID";
                SqlCommand cmd = new SqlCommand(sql, context);
                cmd.Parameters.AddWithValue("@ID", id);
                Endereco e = null;
                try
                {
                    context.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                e = new Endereco();
                                e.IDEndereco = (int)reader["IDENDERECO"];
                                e.Rua = reader["RUA"].ToString();
                                e.Rua = reader["CIDADE"].ToString();
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


        public override void Save(Endereco entity)
        {
            using (var context = new SqlConnection(StringConnection))
            {
                string sql = "INSERT INTO ENDERECO (RUA,CIDADE) VALUES (@RUA,@CIDADE)";
                SqlCommand cmd = new SqlCommand(sql, context);
                cmd.Parameters.AddWithValue("@Rua", entity.Rua);
                cmd.Parameters.AddWithValue("@CIDADE", entity.Cidade);
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

        public override void Update(Endereco entity)
        {
            using (var context = new SqlConnection(StringConnection))
            {
                string sql = "UPDATE  ENDERECO SET RUA = @RUA,CIDADE =@CIDADE WHERE IDENDERECO = @ID";
                SqlCommand cmd = new SqlCommand(sql, context);
                cmd.Parameters.AddWithValue("@id", entity.IDEndereco);
                cmd.Parameters.AddWithValue("@Rua", entity.Rua);
                cmd.Parameters.AddWithValue("@CIDADE", entity.Cidade);
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