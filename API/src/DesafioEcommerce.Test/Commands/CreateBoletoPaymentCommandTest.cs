using DesafioEcommerce.Domain.Commands;
using FluentAssertions;
using Xunit;

namespace DesafioEcommerce.Test.Commands
{
    public class CreateBoletoPaymentCommandTest
    {
        [Fact(DisplayName = "Deve retornar erro quando o número do boleto estiver incorreto")]
        public void ShouldReturnErrorWhenBoletoNumberIsInvalid()
        {
            var command = new CreateBoletoPaymentCommand();
            command.BoletoNumber = "000-000";

            command.Valdiate().IsValid.Should().Be(false);
        }

        [Fact(DisplayName = "Deve retornar sucesso quando o número do boleto estiver correto")]
        public void ShouldReturnSuccessWhenBoletoNumberIsValid()
        {
            var command = new CreateBoletoPaymentCommand();
            command.BoletoNumber = "00000.00000 00000.000000 00000.000000 0 00000000000000";

            command.Valdiate().IsValid.Should().Be(true);
        }
    }
}
