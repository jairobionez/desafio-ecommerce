using DesafioEcommerce.Domain.Entities;
using DesafioEcommerce.Domain.Interfaces;
using DesafioEcommerce.Domain.Interfaces.Repository;
using DesafioEcommerce.Domain.ViewModel;
using DesafioEcommerce.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DesafioEcommerce.Infra.Data.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly INotifiable _notifications;
        private readonly EcommerceContext _ecommerceContext;

        public ProductRepository(EcommerceContext ecommerce, INotifiable notifications): base(ecommerce, notifications)
        {
            _ecommerceContext = ecommerce;
            _notifications = notifications;
        }

        public void CheckStock(List<CartViewModel> cartProducts)
        {
            var stockProducts = _ecommerceContext.Products.AsNoTracking()
                                                          .AsEnumerable();

            cartProducts.ForEach(prod => {
                decimal stockAmount = stockProducts.Where(a => a.Id == prod.Id)
                                                   .FirstOrDefault()
                                                   .Amount;

                if (stockAmount - prod.Amount < 0)
                    _notifications.AddNotification(prod.Description, "Produto em falta no estoque");
            });            
        }
    }
}
