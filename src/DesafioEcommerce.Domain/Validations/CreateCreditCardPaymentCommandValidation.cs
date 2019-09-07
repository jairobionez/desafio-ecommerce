using DesafioEcommerce.Domain.Commands;
using FluentValidation;

namespace DesafioEcommerce.Domain.Validations
{
    public class CreateCreditCardPaymentCommandValidation : AbstractValidator<CreateCreditCardPaymentCommand>
    {
        public CreateCreditCardPaymentCommandValidation()
        {
            ValidateCreditCard();
        }

        protected void ValidateCreditCard()
        {
            RuleFor(p => p.CardNumber)
                .CreditCard().WithMessage("Número do cartão de crédito inválido");
        }
    }
}
