using DesafioEcommerce.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioEcommerce.Domain.Entities
{
    public class Order : BaseEntity
    {
        //private List<OrderItems> _items;
        public Order()
        {

        }

        public Order(string user,
            string zipCode,
            DateTime paymentDate,
            Address address,
            Email email,
            decimal total,
            decimal totalPayd)
        {
            User = user;
            ZipCode = zipCode;
            PaymentDate = paymentDate;
            Address = address;
            Email = email;
            Total = total;
            TotalPayd = totalPayd;
            //_items = new List<OrderItems>();
        }

        public string User { get; set; }
        public string ZipCode { get; set; }
        public DateTime PaymentDate { get; set; }
        public Address Address { get; set; }
        public Email Email { get; set; }
        public decimal Total { get; set; }
        public decimal TotalPayd { get; set; }

        public virtual ICollection<OrderItems> Items { get; set; }

        //public void AddItems(List<OrderItems> items)
        //{
        //    //if (items) // validar
        //        _items.AddRange(items);
        //}
    }
}
