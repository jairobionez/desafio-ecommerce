using DesafioEcommerce.Domain.ValueObjects;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioEcommerce.Domain.Validations
{
    public class NameValidations : AbstractValidator<Name>
    {
        public NameValidations()
        {
            ValidateName();
        }

        protected void ValidateName()
        {
            RuleFor(p => p.FirstName)
                .Length(0, 30).WithMessage("Máximo de caracteres permitidos 30");

            RuleFor(p => p.LastName)
                .Length(0, 70).WithMessage("Máximo de caracteres permitidos 100");
        }
    }
}
