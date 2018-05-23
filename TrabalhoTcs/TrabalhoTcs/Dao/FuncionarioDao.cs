using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using TrabalhoTcs.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;

namespace TrabalhoTcs.Dao
{
    public class FuncionarioDao
    {

      public IList<FUNCIONARIO> Listar()
        {
            using (var context = new BaseDadosEntities())
            {
                return context.FUNCIONARIO.ToList();
            }
        }

        public string GetEnderecoFuncionario()
        {
            
            using (var context = new BaseDadosEntities())
            {

                var query = from f in context.FUNCIONARIO select f;
                string endereco = string.Empty;
                foreach (var item in query)
                {
                     endereco = item.ENDERECO;
                }
                return endereco;
            }
            
        }
    }
}