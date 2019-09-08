using DesafioEcommerce.Domain.Validations;
using DesafioEcommerce.Domain.ValueObjects;
using DesafioEcommerce.Domain.ViewModel;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace DesafioEcommerce.Domain.Entities
{
    public class Payment : BaseEntity
    {
        private IList<OrderItems> _items;

        private Payment()
        {

        }

        public Payment(Name name, Address address, decimal total, DateTime paidDate,
            decimal totalPaid, Email email, Document document)
        {
            Name = name;
            Address = address;
            Total = total;
            PaidDate = paidDate;
            TotalPaid = totalPaid;
            Email = email;
            Document = document;
            _items = new List<OrderItems>();
        }

        public Name Name{ get; set; }

        public Address Address{ get; set; }

        public decimal Total { get; set; }

        public decimal TotalPaid { get; set; }

        public Email Email { get; set; }

        public DateTime PaidDate { get; set; }

        public Document Document { get; set; }

        public virtual IReadOnlyCollection<OrderItems> Items{ get { return _items.ToArray(); } }

        public bool AddItems(List<CartViewModel> items)
        {
            bool isValid = true;

            items.ForEach(i =>
            {
                if (!isValid) return;

                var item = new OrderItems(i.Amount, i.UnitPrice, i.PaymentNumber, i.Description);

                if (item.Validate().IsValid)                    
                    _items.Add(item);
                else {
                    isValid = false;
                    return;
                }
            });

            return isValid;
        }

        public ValidationResult Validate()
        {
            var validationResult = new PaymentValidation().Validate(this);

            return validationResult;
        }
    }
}
