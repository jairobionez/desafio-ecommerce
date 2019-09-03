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

        TEntity GetById(int id);
    }
}
