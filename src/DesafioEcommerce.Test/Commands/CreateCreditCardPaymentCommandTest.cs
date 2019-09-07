using DesafioEcommerce.Domain.Commands;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DesafioEcommerce.Test.Commands
{
    public class CreateCreditCardPaymentCommandTest
    {
        [Fact(DisplayName = "Deve retornar erro quando o número do cartão estiver incorreto")]
        public void ShouldReturnErrorWhenCreditCardNumberIsInvalid()
        {
            var command = new CreateCreditCardPaymentCommand();
            command.CardNumber = "12346546";

            command.Valdiate().IsValid.Should().Be(false);            
        }

        [Fact(DisplayName = "Deve retornar sucesso quando o número do cartão estiver correto")]
        public void ShouldReturnSuccessWhenCreditCardNumberIsValid()
        {
            // Para gerar o cartão foi usado https://ccardgenerator.com/generat-visa-card-numbers.php

            var command = new CreateCreditCardPaymentCommand();
            command.CardNumber = "4296770761965717";

            command.Valdiate().IsValid.Should().Be(true);            
        }
    }
}
