using DesafioEcommerce.Domain.Validations;
using FluentValidation.Results;

namespace DesafioEcommerce.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public Email(string address)
        {
            Address = address;
        }
        
        public string Address { get; private set; }

        public ValidationResult Validate()
        {
            var ValidationResult = new EmailValidation().Validate(this);

            return ValidationResult;
        }
    }
}
