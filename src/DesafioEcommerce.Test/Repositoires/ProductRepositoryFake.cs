using DesafioEcommerce.Domain.Entities;
using DesafioEcommerce.Domain.Interfaces.Repository;
using DesafioEcommerce.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioEcommerce.Test.Repositoires
{
    public class ProductRepositoryFake : BaseRepositoryFake<Product>, IProductRepository
    {
        public ProductRepositoryFake()
        {
                
        }

        public void CheckStock(List<CartViewModel> cartProducts)
        {
            throw new NotImplementedException();
        }
    }
}
