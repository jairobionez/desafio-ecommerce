using DesafioEcommerce.Domain.Commands;
using FluentValidation;

namespace DesafioEcommerce.Domain.Validations
{
    public class CreateCreditCardPaymentCommandValidation : AbstractValidator<CreateCreditCardPaymentCommand>
    {
        public CreateCreditCardPaymentCommandValidation()
        {

        }


        protected void ValidateName()
        {
            RuleFor(p => p.FirsName)
                .Length(0, 30).WithMessage("Máximo de caracteres permitidos 30");

            RuleFor(p => p.LastName)
                .Length(0, 100).WithMessage("Máximo de caracteres permitidos 100");
        }
    }
}
