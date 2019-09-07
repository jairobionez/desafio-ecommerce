using DesafioEcommerce.Domain.ValueObjects;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DesafioEcommerce.Test.ValueObjects
{
    public class NameTest
    {
        [Fact(DisplayName = "Deve retornar erro quando o nome exceder o limite de caracteres")]
        public void ShouldReturnErrorWhenNameIsInvalid()
        {
            var name = new Name("TesteDeLimiteDeCaracteres12312312312312312312312", "Donizeti Bionez");

            name.Validate().IsValid.Should().Be(false);
        }

        [Fact(DisplayName = "Deve retornar erro quando o sobrenome exceder o limite de caracteres")]
        public void ShouldReturnErrorWhenLastNameIsInvalid()
        {
            var name = new Name("Jairo", " is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book." +
                                         " It has survived not only five centuries, but also the leap into electronic. Lorem Ipsum has been the industry's standard dummy text e");

            name.Validate().IsValid.Should().Be(false);
        }
    }
}
