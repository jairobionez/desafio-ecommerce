using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioEcommerce.Domain.ViewModel
{
    public class CartViewModel
    {
        public CartViewModel(int id, int amount, decimal unitPrice, decimal total, int paymentNumber, string description)
        {
            Id = id;
            Amount = amount;
            UnitPrice = unitPrice;
            Total = total;
            PaymentNumber = paymentNumber;
            Description = description;
        }

        public int Id { get; set; }
        public int Amount { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Total { get; set; }
        public int PaymentNumber { get; set; }
        public string Description { get; set; }
    }
}
