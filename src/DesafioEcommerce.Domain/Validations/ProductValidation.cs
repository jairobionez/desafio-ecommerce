using DesafioEcommerce.Domain.Entities;
using FluentValidation;

namespace DesafioEcommerce.Domain.Validations
{
    public  class ProductValidation : AbstractValidator<Product>
    {
        public ProductValidation()
        {
            ValidateDescription();
            ValidateAmount();
            ValidateWeight();
            ValidateValue();
        }

        protected void ValidateDescription()
        {
            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("Por favor informe uma descrição para o produto")
                .Length(0, 50).WithMessage("A descrição possuí um máximo de 50 caracteres");
        }

        protected void ValidateAmount()
        {
            RuleFor(p => p.Amount)
                .NotEmpty().WithMessage("A quantidade do produto não pode ser nula")
                .GreaterThanOrEqualTo(0).WithMessage("A quantidade não pode ser menor que 0");
        }

        protected void ValidateWeight()
        {
            RuleFor(p => p.Weight)
                .NotEmpty().WithMessage("O peso do produto não pode ser nulo")
                .GreaterThanOrEqualTo(0).WithMessage("O peso não pode ser menor que 0kg");
        }

        protected void ValidateValue()
        {
            RuleFor(p => p.Value)
                .NotEmpty().WithMessage("O produto precisa de um valor")
                .GreaterThanOrEqualTo(0).WithMessage("O valor do produto não pode ser menor que R$0.00");
        }
    }
}
