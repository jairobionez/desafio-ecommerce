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

        public Product(string description, byte[] image, int amount, decimal value, decimal weight, string eanCode)
        {
            Description = description;
            Image = image;
            Amount = amount;
            Value = value;
            Weight = weight;
            EanCode = eanCode;
        }

        public string Description { get; set; }
        public byte[] Image { get; set; }
        public int Amount { get; set; }
        public decimal Value { get; set; }
        public decimal Weight { get; set; }
        public string EanCode { get; set; }

        public void CheckSotck(List<CartViewModel> cartProducts)
        {

        }

        public ValidationResult Validation()
        {
            var validation = new ProductValidation().Validate(this);

            return validation;
        }
    }
}
