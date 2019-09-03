using DesafioEcommerce.Domain.Entities;
using DesafioEcommerce.Domain.Interfaces.Repository;
using DesafioEcommerce.Infra.Data.Context;

namespace DesafioEcommerce.Infra.Data.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(EcommerceContext ecommerce): base(ecommerce)
        {

        }
    }
}
