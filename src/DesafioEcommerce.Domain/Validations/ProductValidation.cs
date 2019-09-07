using DesafioEcommerce.Domain.Entities;
using FluentValidation;

namespace DesafioEcommerce.Domain.Validations
{
    public class ProductValidation : AbstractValidator<Product>
    {
        public ProductValidation()
        {
            ValidateDescription();
            ValidateAmount();
            ValidateWeight();
            ValidateValue();
            ValidateEan();
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
                .GreaterThanOrEqualTo(0).WithMessage("A quantidade não pode ser menor que 0");
        }

        protected void ValidateWeight()
        {
            RuleFor(p => p.Weight)
                .GreaterThanOrEqualTo(0).WithMessage("O peso não pode ser menor que 0kg");
        }

        protected void ValidateValue()
        {
            RuleFor(p => p.Value)
                .GreaterThanOrEqualTo(0).WithMessage("O valor do produto não pode ser menor que R$0.00");
        }

        protected void ValidateEan()
        {
            RuleFor(p => p.EanCode)                
                .Length(13).WithMessage("O Código EAN deve ter 13 números");
        }
    }
}
