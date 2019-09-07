using DesafioEcommerce.Domain.Validations;
using DesafioEcommerce.Domain.ViewModel;
using FluentValidation.Results;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace DesafioEcommerce.Domain.Entities
{
    public class Product : BaseEntity
    {
        public Product()
        {

        }

        public Product(string description, string image, int amount, decimal value, decimal weight, string eanCode)
        {
            Description = description;
            Image = image;
            Amount = amount;
            Value = value;
            Weight = weight;
            EanCode = eanCode;
        }

        public string Description { get; set; }
        public string Image { get; set; }
        public int Amount { get; set; }
        public decimal Value { get; set; }
        public decimal Weight { get; set; }
        public string EanCode { get; set; }

        public ValidationResult Validate()
        {
            var validation = new ProductValidation().Validate(this);

            return validation;
        }
    }
}
