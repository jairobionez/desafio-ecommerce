using DesafioEcommerce.Domain.Entities;
using FluentValidation;

namespace DesafioEcommerce.Domain.Validations
{
    public class PaymentValidation : AbstractValidator<Payment>
    {
        public PaymentValidation()
        {
            ValidateTotal();
            ValidateTotalPaid();
        }

        protected void ValidateTotal()
        {
            RuleFor(p => p.Total)
                .LessThanOrEqualTo(0).WithMessage("O total não pode ser 0");
        }

        protected void ValidateTotalPaid()
        {
            RuleFor(p => p.TotalPaid)
                .LessThanOrEqualTo(p => p.Total).WithMessage("O valor pago é menor que o valor do pagamento");
        }
    }
}
