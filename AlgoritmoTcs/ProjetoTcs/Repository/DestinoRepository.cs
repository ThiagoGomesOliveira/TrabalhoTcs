using ProjetoTcs.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjetoTcs.Repository
{
    public class DestinoRepository : Repository<Destino, int>
    {
        public override void Delete(Destino entity)
        {
            throw new NotImplementedException();
        }

        public override void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Destino> GetAll()
        {
            string sql = @"
SELECT D.TEMPO , 
       PDV.NOMEEMPRESA,
	   PDV.INICIOATENDIMENTO,
	   PDV.TEMPOVISITACAO,
	   ENDER.Cidade,
	   ENDER.Rua
  FROM DESTINO AS D
 INNER JOIN PdvFuncionario AS PDV ON PDV.IdPdvFuncionario = D.IdPdvFuncionario
 INNER JOIN Endereco AS ENDER ON ENDER.IDEndereco = PDV.IDEndereco";
            using (var context = new SqlConnection(StringConnection))
            {
                var cmd = new SqlCommand(sql, context);
                List<Destino> lista = new List<Destino>();
                Destino e = null;
        
                try
                {

                    context.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            e = new Destino();
                            e.Tempo = (TimeSpan)reader["TEMPO"];
                            e.PdvFuncionario.NomeEmpresa = reader["NOMEEMPRESA"].ToString();
                            e.PdvFuncionario.InicioAtendimento = (TimeSpan)reader["INICIOATENDIMENTO"];
                            e.PdvFuncionario.TempoVisitacao = (TimeSpan)reader["TEMPOVISITACAO"];
                            e.Endereco.Cidade = reader["Cidade"].ToString();
                            e.Endereco.Rua = reader["Rua"].ToString();
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

        public override Destino GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override void Save(Destino entity)
        {
            using (var context = new SqlConnection(StringConnection))
            {
                string sql = "INSERT INTO DESTINO (TEMPO,DATA,IDPDVFUNCIONARIO,FUNCIONARIODESTINO) VALUES (@TEMPO,@DATA,@IDPDVF,@IDFUNC)";
                SqlCommand cmd = new SqlCommand(sql, context);
                cmd.Parameters.AddWithValue("@TEMPO", entity.Tempo);
                cmd.Parameters.AddWithValue("@DATA", entity.Data);
                cmd.Parameters.AddWithValue("@IDPDVF",entity.PdvFuncionario.IdPdvFuncionario);
                cmd.Parameters.AddWithValue("@IDFUNC", entity.PdvFuncionario.IdFuncionario);
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

        public override void Update(Destino entity)
        {
            throw new NotImplementedException();
        }
    }
}