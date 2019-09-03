using DesafioEcommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioEcommerce.Domain.Interfaces.Services
{
    public interface IProductService
    {
        IEnumerable<Product> Get();
        Product GetById(int id);
    }
}
