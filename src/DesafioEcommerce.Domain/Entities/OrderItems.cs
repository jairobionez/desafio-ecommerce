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

        public OrderItems(int amount, decimal unitPrice, decimal total, int orderNumber)
        {
            Amount = amount;
            UnitPrice = unitPrice;
            Total = total;
            PaymentNumber = orderNumber;
        }

        public int Amount { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Total { get; set; }
        public int PaymentNumber { get; set; }
        public string Description { get; set; }

        public virtual Payment Payment { get; set; }
    }
}
