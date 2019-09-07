using DesafioEcommerce.Domain.Enums;
using DesafioEcommerce.Domain.ValueObjects;
using FluentValidation;
using System.Text.RegularExpressions;

namespace DesafioEcommerce.Domain.Validations
{
    public class DocumentValidation : AbstractValidator<Document>
    {
        public DocumentValidation()
        {
            ValidateCPFCNPJ();
        }

        protected void ValidateCPFCNPJ()
        {
            RuleFor(p => p)
                .Custom((item, context) =>
                    {
                        switch (item.Type)
                        {
                            case EDocumentTypeEnum.CPF:
                                if (!(Regex.IsMatch(item.Number, @"^[a-zA-Z0-9]{11}$")))
                                    context.AddFailure("Número do CPF inválido");
                                break;
                            case EDocumentTypeEnum.CNPJ:
                                if (!(Regex.IsMatch(item.Number, @"^[A-Za-z0-9]{14}$")))
                                    context.AddFailure("Número do CNPJ inválido");
                                break;
                        }
                    });
        }
    }
}
