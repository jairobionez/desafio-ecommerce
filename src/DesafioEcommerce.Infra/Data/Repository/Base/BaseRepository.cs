using DesafioEcommerce.Domain.Entities;
using DesafioEcommerce.Domain.Interfaces.Repository;
using DesafioEcommerce.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DesafioEcommerce.Infra.Data.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly EcommerceContext Db;        
        protected readonly DbSet<TEntity> DbSet;

        public BaseRepository(EcommerceContext ecommerceContext)
        {
            Db = ecommerceContext;
            DbSet = Db.Set<TEntity>();
        }

        public IEnumerable<TEntity> Get()
        {
            return DbSet;
        }

        public TEntity GetById(int id)
        {
            return DbSet.Find(id);
        }

        public TEntity Post(TEntity obj)
        {
            DbSet.Add(obj);

            return obj;
        }

        public TEntity Put(TEntity obj)
        {
            Db.Entry(obj).State = EntityState.Modified;

            return obj;
        }

        public void Delete(TEntity obj)
        {
            DbSet.Remove(obj);                       
        }
    }
}
