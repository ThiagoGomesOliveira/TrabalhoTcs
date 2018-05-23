using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrabalhoTcs.Models;

namespace TrabalhoTcs.Dao
{
    public class EmpresaDao
    {

        public List<Empresa> ListarEmpresas()
        {
            using (var context = new BaseDadosEntities())
            {
                return context.Empresa.ToList();
            }
        }

        public void BuscarIdPorEndereco(int id)
        {

            using (var context = new BaseDadosEntities())
            {
               var teste =  context.Empresa.Where(e => e.IDEmpresa == id).FirstOrDefault();
                
            }


        }

    }
}