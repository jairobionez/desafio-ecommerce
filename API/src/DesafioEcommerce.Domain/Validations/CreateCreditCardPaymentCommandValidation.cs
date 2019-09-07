using DesafioEcommerce.Domain.Commands;
using FluentValidation;
using System;

namespace DesafioEcommerce.Domain.Validations
{
    public class CreateCreditCardPaymentCommandValidation : AbstractValidator<CreateCreditCardPaymentCommand>
    {
        public CreateCreditCardPaymentCommandValidation()
        {
            ValidateCreditCard();
            ValidateValidDate();
        }

        protected void ValidateCreditCard()
        {
            RuleFor(p => p.CardNumber)
                .CreditCard().WithMessage("Número do cartão de crédito inválido");
        }

        protected void ValidateValidDate()
        {
            RuleFor(p => p.ValidDate)
                .GreaterThanOrEqualTo(DateTime.Now).WithMessage("Data de validade do cartão deve ser maior ou igual ao dia de hoje");
        }
    }
}
