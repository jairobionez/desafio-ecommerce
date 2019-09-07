using DesafioEcommerce.Domain.ValueObjects;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DesafioEcommerce.Test.ValueObjects
{
    public class EmailTest
    {

        [Fact(DisplayName = "Deve retornar erro quando o e-mail for inválido")]
        public void ShouldReturnErrorWhenEmailIsInvalid()
        {
            var email = new Email("jairoemail.com");

            email.Validate().IsValid.Should().Be(false);
        }

        [Fact(DisplayName = "Deve retornar sucesso quando o e-mail for válido")]
        public void ShouldReturnSuccessWhenEmailIsValid()
        {
            var email = new Email("jairo@email.com");

            email.Validate().IsValid.Should().Be(true);
        }
    }
}
