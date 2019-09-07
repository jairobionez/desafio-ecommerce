using DesafioEcommerce.Domain.ValueObjects;
using FluentValidation;

namespace DesafioEcommerce.Domain.Validations
{
    public class AddressValidation : AbstractValidator<Address>
    {
        public AddressValidation()
        {
            ValidateLength();
            ValidateRequired();
        }

        protected void ValidateLength()
        {
            RuleFor(p => p.City)
                .Length(0, 30).WithMessage("Máximo de caracteres permitidos 30");

            RuleFor(p => p.Neighborhood)
                .Length(0, 20).WithMessage("Máximo de caracteres permitidos 20");

            RuleFor(p => p.Number)
                .Length(0, 6).WithMessage("Máximo de caracteres permitidos 6");

            RuleFor(p => p.State)
                .Length(0, 20).WithMessage("Máximo de caracteres permitidos 20");

            RuleFor(p => p.Street)
                .Length(0, 60).WithMessage("Máximo de caracteres permitidos 60");

            RuleFor(p => p.ZipCode)
                .Length(0, 8).WithMessage("Máximo de caracteres permitidos 8");
        }

        protected void ValidateRequired()
        {
            RuleFor(p => p.City)
                .NotNull().WithMessage("Campo obrigatório")
                .NotEmpty().WithMessage("Campo obrigatório");

            RuleFor(p => p.Number)
                .NotNull().WithMessage("Campo obrigatório")
                .NotEmpty().WithMessage("Campo obrigatório");

            RuleFor(p => p.State)
                .NotNull().WithMessage("Campo obrigatório")
                .NotEmpty().WithMessage("Campo obrigatório");

            RuleFor(p => p.Street)
                .NotNull().WithMessage("Campo obrigatório")
                .NotEmpty().WithMessage("Campo obrigatório");

            RuleFor(p => p.ZipCode)
                .NotNull().WithMessage("Campo obrigatório")
                .NotEmpty().WithMessage("Campo obrigatório");
        }
    }
}
