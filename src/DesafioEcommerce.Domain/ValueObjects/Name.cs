using DesafioEcommerce.Domain.Validations;
using FluentValidation.Results;

namespace DesafioEcommerce.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

        public ValidationResult Validate()
        {
            var result = new NameValidations().Validate(this);

            return result;
        }
    }
}
