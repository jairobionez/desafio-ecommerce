using DesafioEcommerce.Domain.Entities;
using DesafioEcommerce.Domain.ViewModel;
using System.Collections.Generic;

namespace DesafioEcommerce.Domain.Interfaces.Repository
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        void CheckStock(List<CartViewModel> cartProducts);
    }
}
