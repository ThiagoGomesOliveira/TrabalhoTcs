using ProjetoTcs.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjetoTcs.Repository
{
    public class FuncionarioRepository : Repository<Funcionario, int>
    {
        public override void Delete(Funcionario entity)
        {
            using (var context = new SqlConnection(StringConnection))
            {

                string sql = "DELETE FROM FUNCIONARIO WHERE IDFUNCIONARIO =@ID";
                SqlCommand cmd = new SqlCommand(sql, context);
                cmd.Parameters.AddWithValue("@ID", entity.IDFuncionario);
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

                string sql = "DELETE FROM FUNCIONARIO WHERE IDFUNCIONARIO = @ID";
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

        public override List<Funcionario> GetAll()
        {

            string sql = "SELECT IDFUNCIONARIO,NOME,JORNADATRABALHO,IDENDERECO, INICIOJORNADA FROM FUNCIONARIO";
            using (var context = new SqlConnection(StringConnection))
            {
                var cmd = new SqlCommand(sql, context);
                List<Funcionario> lista = new List<Funcionario>();
                Funcionario e = null;
                try
                {

                    context.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            e = new Funcionario();
                            e.IDFuncionario = (int)reader["IDFUNCIONARIO"];
                            e.Nome = reader["NOME"].ToString();
                            e.JornadaTrabalho =(TimeSpan) reader["JORNADATRABALHO"];
                            e.IDEndereco = (int)reader["IDENDERECO"];
                            e.InicioJornada = (TimeSpan)reader["INICIOJORNADA"];
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

        public override Funcionario GetById(int id)
        {
            using (var context = new SqlConnection(StringConnection))
            {
                string sql = "SELECT IDFUNCIONARIO,NOME,JORNADATRABALHO,IDENDERECO,INICIOJORNADA FROM FUNCIONARIO WHERE IDFUNCIONARIO = @ID";
                SqlCommand cmd = new SqlCommand(sql, context);
                cmd.Parameters.AddWithValue("@ID", id);
                Funcionario e = null;
                try
                {
                    context.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                e = new Funcionario();
                                e.IDFuncionario = (int)reader["IDFUNCIONARIO"];
                                e.Nome = reader["NOME"].ToString();
                                e.JornadaTrabalho =(TimeSpan) reader["JORNADATRABALHO"];
                                e.IDEndereco = (int)reader["IDENDERECO"];
                                e.InicioJornada = (TimeSpan)reader["INICIOJORNADA"];

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

        public override void Save(Funcionario entity)
        {
            using (var context = new SqlConnection(StringConnection))
            {
                string sql = @"INSERT INTO FUNCIONARIO (NOME,JORNADATRABALHO,IDENDERECO,INICIOJORNADA) 
                               VALUES (@NOME,@JORNADATRABALHO,@IDENDERECO,@INICIOJORNADA)";
                SqlCommand cmd = new SqlCommand(sql, context);
                cmd.Parameters.AddWithValue("@NOME",entity.Nome);
                cmd.Parameters.AddWithValue("@JORNADATRABALHO", entity.JornadaTrabalho);
                cmd.Parameters.AddWithValue("@IDENDERECO", entity.IDEndereco);
                cmd.Parameters.AddWithValue("@INICIOJORNADA",entity.InicioJornada);
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

        public override void Update(Funcionario entity)
        {
            using (var context = new SqlConnection(StringConnection))
            {
                string sql =       @"UPDATE FUNCIONARIO 
                                        SET NOME = @NOME , 
                                            JORNADATRABALHO = @JORNADATRABALHO ,
                                            IDENDERECO = @ENDERECO
                                            INICIOJORNADA = @INICIOJORNADA
                                      WHERE IDFUNCIONARIO = @ID";
                SqlCommand cmd = new SqlCommand(sql, context);
                cmd.Parameters.AddWithValue("@ID",entity.IDFuncionario);
                cmd.Parameters.AddWithValue("@NOME", entity.Nome);
                cmd.Parameters.AddWithValue("@JORNADATRABALHO", entity.JornadaTrabalho);
                cmd.Parameters.AddWithValue("@ENDERECO", entity.IDEndereco);
                cmd.Parameters.AddWithValue("@INICIOJORNADA", entity.InicioJornada);
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