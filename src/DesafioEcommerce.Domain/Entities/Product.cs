using DesafioEcommerce.Domain.Validations;
using FluentValidation.Results;

namespace DesafioEcommerce.Domain.Entities
{
    public class Product : BaseEntity
    {
        public Product(string description, int amount, decimal value, decimal weight)
        {
            Description = description;
            Amount = amount;
            Value = value;
            Weight = weight;
        }

        public string Description { get; set; }

        public int Amount { get; set; }

        public decimal Value { get; set; }

        public decimal Weight { get; set; }

        public ValidationResult Validation()
        {
            var validation = new ProductValidation().Validate(this);

            return validation;
        }
    }
}
