using System;
using System.Collections.Generic;
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
            OrderNumber = orderNumber;
        }

        public int Amount { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Total { get; set; }
        public int OrderNumber { get; set; }

        public virtual Order Order { get; set; }
    }
}
