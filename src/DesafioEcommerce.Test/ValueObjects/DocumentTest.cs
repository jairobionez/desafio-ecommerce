using DesafioEcommerce.Domain.Enums;
using DesafioEcommerce.Domain.ValueObjects;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DesafioEcommerce.Test.ValueObjects
{
    public class DocumentTest
    {

        [Fact(DisplayName = "Deve retornar erro quando o tipo de documento for CPF e ser inválido")]
        public void ShouldReturnErrorWhenCPFNumberIsInvalid()
        {
            var document = new Document("123", EDocumentTypeEnum.CPF);

            document.Validate().IsValid.Should().Be(false);
        }

        [Fact(DisplayName = "Deve retornar erro quando o tipo de documento for CNPJ e ser inválido")]
        public void ShouldReturnErrorWhenCNPJIsInvalid()
        {
            var document = new Document("123", EDocumentTypeEnum.CNPJ);

            document.Validate().IsValid.Should().Be(false);
        }

        [Fact(DisplayName = "Deve retornar sucesso quando o tipo de documento for CPF e ser válido")]
        public void ShouldReturnSuccessWhenCPFNumberIsValid()
        {
            var document = new Document("39022455068", EDocumentTypeEnum.CPF);

            document.Validate().IsValid.Should().Be(true);
        }

        [Fact(DisplayName = "Deve retornar sucesso quando o tipo de documento for CNPJ e ser válido")]
        public void ShouldReturnSuccessWhenCNPJIsValid()
        {
            var document = new Document("63577432000180", EDocumentTypeEnum.CNPJ);

            document.Validate().IsValid.Should().Be(true);
        }
    }
}
