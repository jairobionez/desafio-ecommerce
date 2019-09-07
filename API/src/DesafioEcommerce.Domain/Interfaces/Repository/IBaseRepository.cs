using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioEcommerce.Domain.Interfaces.Repository
{
    public interface IBaseRepository<TEntity>
    {
        IEnumerable<TEntity> Get();
        IEnumerable<TEntity> GetTableNoTracking();
        TEntity GetById(int id);
        TEntity Post(TEntity obj);
        TEntity Put(TEntity obj);
        void Delete(TEntity obj);
        void PutRange(List<TEntity> obj);
    }
}
