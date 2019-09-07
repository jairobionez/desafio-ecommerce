using DesafioEcommerce.Domain.ValueObjects;
using FluentValidation;
using System.Text.RegularExpressions;

namespace DesafioEcommerce.Domain.Validations
{
    public class DocumentValidation : AbstractValidator<Document>
    {
        public DocumentValidation()
        {
            ValidateCPF();
            ValidateCNPJ();
        }

        protected void ValidateCPF()
        {
            RuleFor(p => p)
                .Custom((item, context) =>
                    {
                        if (!Regex.IsMatch(item.Number, @"/^\d{3}\.\d{3}\.\d{3}\-\d{2}$/") && item.Type != Enums.EDocumentTypeEnum.CPF)
                            context.AddFailure("Número do CPF inválido");
                    });
        }

        protected void ValidateCNPJ()
        {
            RuleFor(p => p)
                .Custom((item, context) =>
                {
                    if (!Regex.IsMatch(item.Number, @"/^\d{2}\.\d{3}\.\d{3}\/\d{4}\-\d{2}$/") && item.Type != Enums.EDocumentTypeEnum.CNPJ)
                        context.AddFailure("Número do CNPJ inválido");
                });
        }
    }
}
