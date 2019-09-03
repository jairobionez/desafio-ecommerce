using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioEcommerce.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
