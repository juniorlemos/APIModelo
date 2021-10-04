using Modelo.Domain.Entities;
using Modelo.Domain.Interfaces;
using Modelo.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Infra.Data.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly MySqlContext _mySqlContext;

        public BaseRepository(MySqlContext mySqlContext)
        {
            _mySqlContext = mySqlContext;
        }


        public void Delete(int id)
        {
            _mySqlContext.Set<TEntity>().Remove(Select(id));
            _mySqlContext.SaveChanges();
        }

        public void Insert(TEntity obj)
        {
            _mySqlContext.Set<TEntity>().Add(obj);
            _mySqlContext.SaveChanges();

        }

        public IList<TEntity> Select() =>
            _mySqlContext.Set<TEntity>().ToList();

        public TEntity Select(int id) =>
       _mySqlContext.Set<TEntity>().Find(id);

        public void Update(TEntity obj)
        {
            _mySqlContext.Entry(obj).State =
          Microsoft.EntityFrameworkCore.EntityState.Modified;
            _mySqlContext.SaveChanges();
        }
    }
}
