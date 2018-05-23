using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data.Objects.DataClasses;

namespace ProjetoTcs.Repository
{
    public abstract class  Repository <TEntity,Tkey> where TEntity : class
    {
        
        protected string StringConnection { get; } = WebConfigurationManager.ConnectionStrings["BaseDados"].ConnectionString;
        public abstract List<TEntity> GetAll();
        public abstract TEntity GetById(Tkey id);
        public abstract void Save(TEntity entity);
        public abstract void Update(TEntity entity);
        public abstract void Delete(TEntity entity);
        public abstract void DeleteById(Tkey id);

    }
}