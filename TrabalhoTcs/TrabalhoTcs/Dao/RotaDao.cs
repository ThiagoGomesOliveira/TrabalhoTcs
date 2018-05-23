using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrabalhoTcs.Models;

namespace TrabalhoTcs.Dao
{
    public class RotaDao
    {

        public void Adicionar(Rota rota)
        {
            using (var context = new BaseDadosEntities())
            {
                context.Rota.Add(rota);
                context.SaveChanges();
            }
        }


    }
}