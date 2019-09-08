using DesafioEcommerce.Domain.Validations;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DesafioEcommerce.Domain.Entities
{
    public class OrderItems : BaseEntity
    {
        public OrderItems()
        {
                
        }

        public OrderItems(int amount, decimal unitPrice, int orderNumber, string description)
        {
            Amount = amount;
            UnitPrice = unitPrice;
            PaymentNumber = orderNumber;
            Description = description;
        }

        public int Amount { get; set; }
        public decimal UnitPrice { get; set; }
        public int PaymentNumber { get; set; }
        public string Description { get; set; }

        public virtual Payment Payment { get; set; }

        public ValidationResult Validate()
        {
            var result = new OrderItemsValidation().Validate(this);

            return result;
        }
    }
}
