using DesafioEcommerce.Domain.Interfaces;
using DesafioEcommerce.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioEcommerce.Infra.Data.Transactions
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EcommerceContext _ecommerceContext;

        public UnitOfWork(EcommerceContext ecommerceContext)
        {
            _ecommerceContext = ecommerceContext;
        }

        public bool Commit()
        {
            try
            {
                return _ecommerceContext.SaveChanges() > 0;
            }catch(Exception ex)
            {
                return false;
            }
        }

        public void Dispose()
        {
            _ecommerceContext.Dispose();
        }
    }
}
