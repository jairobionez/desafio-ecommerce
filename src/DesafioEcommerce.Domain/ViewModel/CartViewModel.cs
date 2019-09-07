using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioEcommerce.Domain.ViewModel
{
    public class CartViewModel
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Total { get; set; }
        public int PaymentNumber { get; set; }
        public string Description { get; set; }
    }
}
