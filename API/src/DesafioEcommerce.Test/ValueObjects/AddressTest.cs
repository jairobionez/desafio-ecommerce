using DesafioEcommerce.Domain.ValueObjects;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DesafioEcommerce.Test.ValueObjects
{
    public class AddressTest
    {
        [Theory(DisplayName = "Deve retornar erro quando a cidade for nula ou vazia")]
        [InlineData("", false)]
        [InlineData(null, false)]
        public void ShouldReturnErrorWhenCityIsNullOrEmpty(string city, bool isValid)
        {
            var address = new Address("Rua teste", city, "Estado teste", "12658777", "bairro teste", "1234");

            address.Validate().IsValid.Should().Be(isValid);
        }

        [Theory(DisplayName = "Deve retornar erro quando o número for nulo ou vazio")]
        [InlineData("", false)]
        [InlineData(null, false)]
        public void ShouldReturnErrorWhenNumberIsNullOrEmpty(string number, bool isValid)
        {
            var address = new Address("Rua teste", "teste", "Estado teste", "12658777", "bairro teste", number);

            address.Validate().IsValid.Should().Be(isValid);
        }

        [Theory(DisplayName = "Deve retornar erro quando o estado for nulo ou vazio")]
        [InlineData("", false)]
        [InlineData(null, false)]
        public void ShouldReturnErrorWhenStateIsNullOrEmpty(string state, bool isValid)
        {
            var address = new Address("Rua teste", "teste", state, "12658777", "bairro teste", "1234");

            address.Validate().IsValid.Should().Be(isValid);
        }

        [Theory(DisplayName = "Deve retornar erro quando a rua for nula ou vazia")]
        [InlineData("", false)]
        [InlineData(null, false)]
        public void ShouldReturnErrorWhenStreetIsNullOrEmpty(string street, bool isValid)
        {
            var address = new Address(street, "estado", "Estado teste", "12658777", "bairro teste", "1234");

            address.Validate().IsValid.Should().Be(isValid);
        }

        [Theory(DisplayName = "Deve retornar erro quando o CEP for nulo ou vazio")]
        [InlineData("", false)]
        [InlineData(null, false)]
        public void ShouldReturnErrorWhenZipCodeIsNullOrEmpty(string zipCode, bool isValid)
        {
            var address = new Address("Rua teste", "teste", "Estado teste", zipCode, "bairro teste", "1234");

            address.Validate().IsValid.Should().Be(isValid);
        }
    }
}
