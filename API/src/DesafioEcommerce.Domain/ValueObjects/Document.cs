using DesafioEcommerce.Domain.Enums;
using DesafioEcommerce.Domain.Validations;
using FluentValidation.Results;

namespace DesafioEcommerce.Domain.ValueObjects
{
    public class Document : ValueObject
    {
        public Document(string number, EDocumentTypeEnum type)
        {
            Number = number;
            Type = type;
        }

        public string Number { get; private set; }
        
        public EDocumentTypeEnum Type { get; private set; }

        public ValidationResult Validate()
        {
            var validation = new DocumentValidation().Validate(this);

            return validation;
        }
    }
}
