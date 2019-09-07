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
                .GreaterThan(0).WithMessage("O total não pode ser menor ou igual 0");
        }

        protected void ValidateTotalPaid()
        {
            RuleFor(p => p.TotalPaid)
                .GreaterThan(0).WithMessage("O total pago não pode ser menor ou igual 0");
        }
    }
}
