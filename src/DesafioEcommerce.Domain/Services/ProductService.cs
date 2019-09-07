using DesafioEcommerce.Domain.Entities;
using DesafioEcommerce.Domain.Interfaces;
using DesafioEcommerce.Domain.Interfaces.Repository;
using DesafioEcommerce.Domain.Interfaces.Services;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

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
            try
            {
                if (id == 0)
                    _notifications.AddNotification("Id", "Identificador de busca não pode ser 0");

                if (!_notifications.HasNotifications())
                    return _productRepository.GetById(id);

            }
            catch (Exception ex)
            {
                _notifications.AddNotification("Error", ex.Message);
            }

            return null;
        }

        public Product Post(Product obj)
        {
            try
            {
                if (obj.Validation().IsValid)
                    return _productRepository.Post(obj);
                else
                    AddNotifications(obj.Validation().Errors.ToList());
            }
            catch (Exception ex)
            {
                _notifications.AddNotification("Error", ex.Message);
            }

            return null;
        }

        public Product Put(Product obj)
        {
            try
            {
                if (obj.Validation().IsValid)
                    return _productRepository.Put(obj);
                else
                {
                    AddNotifications(obj.Validation().Errors.ToList());
                }

            }
            catch (Exception ex)
            {
                _notifications.AddNotification("Error", ex.Message);
            }

            return null;
        }

        public void Delete(int id)
        {
            try
            {
                if (id == 0)
                    _notifications.AddNotification("Id", "Identificador de busca não pode ser 0");

                Product obj = _productRepository.GetById(id);

                if (obj == null)
                    _notifications.AddNotification("Objeto", "Não foi encotrado nenhum produto com este identificador");

                if (!_notifications.HasNotifications())
                    _productRepository.Delete(obj);
            }
            catch (Exception ex)
            {
                _notifications.AddNotification("Error", ex.Message);
            }
        }

        public void AddNotifications(List<ValidationFailure> errors)
        {
            errors.ForEach(p =>
            {
                _notifications.AddNotification(p.PropertyName, p.ErrorMessage);
            });
        }
    }
}
