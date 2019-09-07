using DesafioEcommerce.Domain.Entities;
using DesafioEcommerce.Domain.Interfaces;
using DesafioEcommerce.Domain.Interfaces.Services;
using DesafioEcommerce.Domain.Notifications;
using DesafioEcommerce.Domain.Services;
using DesafioEcommerce.Test.Repositoires;
using FluentAssertions;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace DesafioEcommerce.Test.Services
{
    public class ProductServiceTest
    {
        public List<Product> products = new List<Product>()
        {
            new Product(){ Amount = 15, Description = "Carne Bovina", EanCode = "1234567897894", Id = 1, Image = "", Value = 10, Weight = 2},
            new Product(){ Amount = 10, Description = "Sabão", EanCode = "2582582583698", Id = 2, Image = "", Value = 5, Weight = 1},
        };

        private readonly IProductService _productService;
        private readonly INotifiable notificationsFake;

        public ProductServiceTest()
        {
            notificationsFake = new Notifiable();
            var repositoryFake = new Mock<ProductRepositoryFake>();
            repositoryFake.Object.ListEntities = products;

            _productService = new ProductService(repositoryFake.Object, notificationsFake);
        }

        [Fact(DisplayName = "Deve retornar uma notificação quando o id for 0")]
        public void ShouldReturnANotification()
        {
            var result = _productService.GetById(0);

            notificationsFake.HasNotifications().Should().Be(true);
            result.Should().Be(null);
        }

        [Fact(DisplayName = "Deve retornar todos os produtos")]
        public void ShouldReturnAllProducts()
        {
            var result = _productService.Get();

            result.Should().HaveCount(2);
        }

        [Fact(DisplayName = "Deve inserir um produto e busca-lo")]
        public void ShouldInsertProductAndSearch()
        {
            var result = _productService.Post(new Product() { Amount = 1, Description = "Teste", EanCode = "2582582583698", Id = 3, Image = "", Value = 1, Weight = 1 });

            _productService.Get().Should().HaveCount(3);
            _productService.GetById(3).Should().NotBe(null);
        }

        [Fact(DisplayName = "Deve deletar um produto")]
        public void ShouldDeleteAProduct()
        {
            _productService.Delete(2);

            _productService.Get().Should().HaveCount(1);
            _productService.GetById(2).Should().Be(null);
        }

        [Theory(DisplayName = "Deve atualizar um produto e busca-lo")]
        [InlineData("Descricao 01")]
        [InlineData("Descricao 02")]
        [InlineData("Descricao 03")]
        public void ShouldUpdateAProduct(string descricao)
        {
            _productService.Put(new Product() { Amount = 15, Description = descricao, EanCode = "1234567897894", Id = 1, Image = "", Value = 10, Weight = 2 });

            notificationsFake.HasNotifications().Should().Be(false);
            _productService.GetById(1).Description.Should().Be(descricao);
        }
    }
}