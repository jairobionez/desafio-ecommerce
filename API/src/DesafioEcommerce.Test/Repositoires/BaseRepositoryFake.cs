using DesafioEcommerce.Domain.Entities;
using DesafioEcommerce.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioEcommerce.Test.Repositoires
{
    public class BaseRepositoryFake<T> : IBaseRepository<T> where T : BaseEntity 
    {
        public List<T> ListEntities = new List<T>();

        public void Delete(T obj)
        {
            ListEntities.Remove(obj);
        }

        public IEnumerable<T> Get()
        {
            return ListEntities;
        }

        public T GetById(int id)
        {
            return ListEntities.Where(p => p.Id == id)
                               .FirstOrDefault();
        }

        public IEnumerable<T> GetTableNoTracking()
        {
            throw new NotImplementedException();
        }

        public T Post(T obj)
        {
            ListEntities.Add(obj);

            return obj;
        }

        public T Put(T obj)
        {
            var index = ListEntities.FindIndex(p => p.Id == obj.Id);

            ListEntities[index] = obj;
            return obj;
        }

        public void PutRange(List<T> obj)
        {
            throw new NotImplementedException();
        }
    }
}
