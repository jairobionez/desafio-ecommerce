using DesafioEcommerce.Domain.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DesafioEcommerce.Test.Entities
{
    public class OrderItemsTest
    {
        private readonly OrderItems _items;

        public OrderItemsTest()
        {
            _items = new OrderItems();
        }

        [Theory(DisplayName = "Deve retornar erro quando a quantidade for menor ou igual que zero")]
        [InlineData(0, false)]
        [InlineData(-1, false)]
        public void ShouldReturnErrorWhenAmountIsLessOrEqualThanZero(int amount, bool isValid)
        {
            _items.Amount = amount;

            _items.Validate().IsValid.Should().Be(isValid);            
        }

        [Fact(DisplayName = "Deve retornar erro quando a descrição ultrapassar seu limite de caracteres")]
        public void ShouldReturnErrorWhenDescriptionExceedTheLimit()
        {
            _items.Description = "is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standa";

            _items.Validate().IsValid.Should().Be(false);
        }

        [Theory(DisplayName = "Deve retornar erro quando a o preço unitário for menor ou igual que zero")]
        [InlineData(0, false)]
        [InlineData(-1, false)]
        public void ShouldReturnErrorWhenUnitPriceIsLessOrEqualThanZero(int unitPrice, bool isValid)
        {
            _items.UnitPrice = unitPrice;

            _items.Validate().IsValid.Should().Be(isValid);

        }

        [Theory(DisplayName = "Deve retornar erro quando o valor total for menor ou igual que zero")]
        [InlineData(0, false)]
        [InlineData(-1, false)]
        public void ShouldReturnErrorWhenTotalIsLessOrEqualThanZero(int total, bool isValid)
        {
            _items.Total = total;

            _items.Validate().IsValid.Should().Be(isValid);            
        }
    }
}
