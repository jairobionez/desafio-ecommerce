using DesafioEcommerce.Domain.ValueObjects;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioEcommerce.Domain.Validations
{
    public class EmailValidation : AbstractValidator<Email>
    {
        public EmailValidation()
        {
            ValidateEmail();
        }

        protected void ValidateEmail()
        {
            RuleFor(p => p.Address)
                .EmailAddress();
        }
    }
}
