using DesafioEcommerce.Domain.Validations;
using DesafioEcommerce.Domain.ValueObjects;
using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace DesafioEcommerce.Domain.Entities
{
    public class Payment : BaseEntity
    {
        public Payment(Name name, Address address, List<Product> products, decimal total, DateTime paidDate, DateTime expireDate, decimal totalPaid, Email email, Document document)
        {
            Name = name;
            Address = address;
            Products = products;
            Total = total;
            PaidDate = paidDate;
            ExpireDate = expireDate;
            TotalPaid = totalPaid;
            Email = email;
            Document = document;
        }

        public Name Name{ get; set; }

        public Address Address{ get; set; }

        public List<Product> Products { get; set; }

        public decimal Total { get; set; }

        public decimal TotalPaid { get; set; }

        public Email Email { get; set; }

        public DateTime PaidDate { get; private set; }

        public DateTime ExpireDate { get; private set; }

        public Document Document { get; set; }

        public ValidationResult Validate()
        {
            var validationResult = new PaymentValidation().Validate(this);

            return validationResult;
        }
    }
}
