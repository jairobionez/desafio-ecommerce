using DesafioEcommerce.Domain.Entities;
using DesafioEcommerce.Domain.Enums;
using DesafioEcommerce.Domain.ValueObjects;
using DesafioEcommerce.Domain.ViewModel;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace DesafioEcommerce.Test.Entities
{
    public class PaymentTest
    {
        private readonly List<CartViewModel> _items;
        private readonly Payment _payment;
        private readonly Name _name;
        private readonly Address _address;
        private readonly Document _document;
        private readonly Email _email;

        public PaymentTest()
        {
            _items = new List<CartViewModel>() {
                new CartViewModel(1, 2, -1, 0, "CARNE BOVINA"),
                new CartViewModel(2, 3, 45, 0, "SABÃO EM PÓ")
            };

            _name = new Name("Jairo", "Donizeti Bionez");
            _address = new Address("Rua teste", "Cidade teste", "estado teste", "12123111", "bairro teste", "123");
            _document = new Document("44454478915", EDocumentTypeEnum.CPF);
            _email = new Email("jairo@email.com");
            _payment = new Payment(_name, _address, 10, DateTime.Now, 15, _email, _document);
        }

        [Theory(DisplayName = "Deve retornar erro quando o total for menor ou igual a zero")]
        [InlineData(0, false)]
        [InlineData(-1, false)]
        public void ShouldReturnErrorWhenTotalIsLessOrEqualThanZero(decimal total, bool isValid)
        {
            _payment.Total = total;

            _payment.Validate().IsValid.Should().Be(isValid);
        }

        [Theory(DisplayName = "Deve retornar erro quando o valor pago for menor ou igual a zero")]
        [InlineData(0, false)]
        [InlineData(-1, false)]
        public void ShouldReturnErrorWhenTotalPaidIsLessThanOrEqualZero(decimal totalPago, bool isValid)
        {            
            _payment.TotalPaid = totalPago;

            _payment.Validate().IsValid.Should().Be(isValid);
        }

        [Fact(DisplayName = "Deve retornar erro quando algum produto do carrinho estiver invalido")]
        public void ShouldReturnErrorWhenCartProductIsInValid()
        {
            var isValid =_payment.AddItems(_items);

            isValid.Should().Be(false);
        }
    }
}
