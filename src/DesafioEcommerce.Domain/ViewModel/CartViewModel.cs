using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioEcommerce.Domain.ViewModel
{
    public class CartViewModel
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public decimal Value { get; set; }
    }
}
