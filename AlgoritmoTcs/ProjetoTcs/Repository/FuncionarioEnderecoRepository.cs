using ProjetoTcs.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjetoTcs.Repository
{
    public class FuncionarioEnderecoRepository : Repository<FuncionarioEndereco, int>
    {
        public override void Delete(FuncionarioEndereco entity)
        {
            throw new NotImplementedException();
        }

        public override void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public override List<FuncionarioEndereco> GetAll()
        {
            throw new NotImplementedException();
        }

        public override FuncionarioEndereco GetById(int id)
        {

            using (var context = new SqlConnection(StringConnection))
            {
                string aSql = @"
 SELECT  FUNC.NOME,
         FUNC.JORNADATRABALHO,
         FUNC.INICIOJORNADA,
         ENDR.CIDADE, 
         ENDR.RUA
   FROM  FUNCIONARIO AS FUNC
  INNER  JOIN ENDERECO AS ENDR ON ENDR.IDENDERECO = FUNC.IDENDERECO
  WHERE  FUNC.IDFUNCIONARIO = @ID";

                SqlCommand cmd = new SqlCommand(aSql, context);
                cmd.Parameters.AddWithValue("@ID", id);
                FuncionarioEndereco e = null;
                try
                {
                    context.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                e = new FuncionarioEndereco();
                                e.NomeFuncionario = reader["NOME"].ToString();
                                e.JornadaTrabalho = (TimeSpan)reader["JORNADATRABALHO"];
                                e.InicioJornada = (TimeSpan)reader["INICIOJORNADA"];
                                e.Cidade = reader["Cidade"].ToString();
                                e.Rua = reader["Rua"].ToString();
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


        public override void Save(FuncionarioEndereco entity)
        {
            throw new NotImplementedException();
        }

        public override void Update(FuncionarioEndereco entity)
        {
            throw new NotImplementedException();
        }

    }
}