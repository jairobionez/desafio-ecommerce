using DesafioEcommerce.Domain.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DesafioEcommerce.Test.Entities
{
    public class ProductTest
    {
        private readonly Product _product;

        public ProductTest()
        {
            _product = new Product("CARNE BOVINA", null, 15, 15, 15, "1231231231231");
        }

        [Fact(DisplayName = "Deve retornar erro quando descrição passar de seu limite")]
        public void ShouldReturnErrorWhenDescriptionExceedTheLimit()
        {
            _product.Description = "is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standa";

            _product.Validate().IsValid.Should().Be(false);
        }

        [Fact(DisplayName = "Deve retornar sucesso quando descrição for estiver dentro do limite")]
        public void ShouldReturnSuccessWhenDescriptionIsWithinTheLimite()
        {
            _product.Validate().IsValid.Should().Be(true);
        }

        [Fact(DisplayName = "Deve retornar erro quando a quantidade for menor que zero")]
        public void ShouldReturnErrorWhenAmountIsLessThanZero()
        {
            _product.Amount = -1;
            _product.Validate().IsValid.Should().Be(false);
        }

        [Fact(DisplayName = "Deve retornar sucesso quando a quantidade for positiva")]
        public void ShouldReturnSucessWhenAmountIsPositive()
        {
            _product.Validate().IsValid.Should().Be(true);
        }

        [Fact(DisplayName = "Deve retornar erro quando o peso for menor que zero")]
        public void ShouldReturnErrorWhenWeightIsLessThanZero()
        {
            _product.Weight = -1;
            _product.Validate().IsValid.Should().Be(false);
        }

        [Fact(DisplayName = "Deve retornar erro quando o valor do produto for menor que zero")]
        public void ShouldReturnErrorWhenValueIsLessThanZero()
        {
            _product.Value = -1;
            _product.Validate().IsValid.Should().Be(false);
        }

        [Fact(DisplayName = "Deve retornar erro quando o código EAN não ter contagem igual a 13")]
        public void ShouldReturnErrorWhenEanIsNotEqualThirteen()
        {
            _product.EanCode = "123456258791";
            _product.Validate().IsValid.Should().Be(false);
        }
    }
}
