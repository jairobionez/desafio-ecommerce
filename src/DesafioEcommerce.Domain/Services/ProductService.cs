using DesafioEcommerce.Domain.Entities;
using DesafioEcommerce.Domain.Interfaces;
using DesafioEcommerce.Domain.Interfaces.Repository;
using DesafioEcommerce.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace DesafioEcommerce.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly INotifiable _notifications;
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository, INotifiable notifications)
        {
            _productRepository = productRepository;
            _notifications = notifications;
        }

        public IEnumerable<Product> Get()
        {
            return _productRepository.Get();
        }

        public Product GetById(int id)
        {
            if (id == 0)
                _notifications.AddNotification("Id", "Identificador de busca não pode ser 0");

            if (!_notifications.HasNotifications())           
                return _productRepository.GetById(id);

            return null;
        }
    }
}
