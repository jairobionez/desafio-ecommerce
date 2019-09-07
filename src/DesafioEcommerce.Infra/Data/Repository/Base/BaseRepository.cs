using DesafioEcommerce.Domain.Entities;
using DesafioEcommerce.Domain.Interfaces;
using DesafioEcommerce.Domain.Interfaces.Repository;
using DesafioEcommerce.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DesafioEcommerce.Infra.Data.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly EcommerceContext Db;
        protected readonly DbSet<TEntity> DbSet;
        private readonly INotifiable _notifications;

        public BaseRepository(EcommerceContext ecommerceContext, INotifiable notifications)
        {
            Db = ecommerceContext;
            DbSet = Db.Set<TEntity>();
            _notifications = notifications;
        }

        public IEnumerable<TEntity> Get()
        {
            try
            {
                return DbSet;
            }
            catch (Exception ex)
            {
                _notifications.AddNotification("Get", ex.Message);
                return null;
            }
        }

        public IEnumerable<TEntity> GetTableNoTracking()
        {
            try
            {
                return DbSet.AsNoTracking();
            }
            catch (Exception ex)
            {
                _notifications.AddNotification("Get", ex.Message);
                return null;
            }
        }

        public TEntity GetById(int id)
        {
            try
            {
                return DbSet.Find(id);
            }
            catch (Exception ex)
            {
                _notifications.AddNotification("GetById", ex.Message);
                return null;
            }
        }

        public TEntity Post(TEntity obj)
        {
            try
            {
                DbSet.Add(obj);

                return obj;

            }
            catch (Exception ex)
            {
                _notifications.AddNotification("Post", ex.Message);
                return null;
            }
        }

        public TEntity Put(TEntity obj)
        {
            try
            {
                Db.Entry(obj).State = EntityState.Modified;

                return obj;
            }
            catch (Exception ex)
            {
                _notifications.AddNotification("Put", ex.Message);
                return null;
            }
        }

        public void PutRange(List<TEntity> obj)
        {
            try
            {
                DbSet.UpdateRange(obj);
            }
            catch (Exception ex)
            {
                _notifications.AddNotification("PutRange", ex.Message);
            }
        }

        public void Delete(TEntity obj)
        {
            try
            {
                DbSet.Remove(obj);
            }
            catch (Exception ex)
            {
                _notifications.AddNotification("Delete", ex.Message);
            }
        }
    }
}
