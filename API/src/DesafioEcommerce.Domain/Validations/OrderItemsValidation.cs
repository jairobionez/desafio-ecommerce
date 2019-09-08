using DesafioEcommerce.Domain.Entities;
using FluentValidation;

namespace DesafioEcommerce.Domain.Validations
{
    public class OrderItemsValidation : AbstractValidator<OrderItems>
    {
        public OrderItemsValidation()
        {
            ValidateAmount();
            ValidateDescription();
            ValidateUnitPrice();
        }

        protected void ValidateAmount()
        {
            RuleFor(p => p.Amount)
                .GreaterThan(0).WithMessage("A quantidade deve ser maior que zero");
        }

        protected void ValidateDescription()
        {
            RuleFor(p => p.Description)
                .NotNull().WithMessage("É necessário informar uma descrição")
                .Length(0, 100).WithMessage("Quantidade máxima de caracteres é 100");
        }

        protected void ValidateUnitPrice()
        {
            RuleFor(p => p.UnitPrice)
                .GreaterThan(0).WithMessage("A valor unitário deve ser maior que zero");
        }
    }
}
