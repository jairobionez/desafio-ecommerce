using DesafioEcommerce.Domain.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace DesafioEcommerce.Domain.Validations
{
    public class CreateBoletoPaymentCommandValidation : AbstractValidator<CreateBoletoPaymentCommand>
    {
        public CreateBoletoPaymentCommandValidation()
        {
            ValidateBoletoNumber();
        }

        protected void ValidateBoletoNumber()
        {
            RuleFor(p => p.BoletoNumber).Custom((item, context) =>
            {
                if (!Regex.IsMatch(item, @"\d{5}\.\d{5} \d{5}\.\d{6} \d{5}\.\d{6} \d \d{14}"))
                    context.AddFailure("Número do boleto incorreto");
            });
        }
    }
}
