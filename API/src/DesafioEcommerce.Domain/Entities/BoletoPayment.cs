using DesafioEcommerce.Domain.Entities;
using DesafioEcommerce.Domain.ValueObjects;
using DesafioEcommerce.Domain.ViewModel;
using System;
using System.Collections.Generic;

namespace PaymentContext.Domain.Entities
{
    public class BoletoPayment : Payment
    {
        public BoletoPayment(
            Name name,
            Address address,
            string boletoNumber,
            DateTime paidDate,
            decimal total,
            decimal totalPaid,
            Document document,
            Email email) : base(
                name,
                address,                
                total,
                paidDate,
                totalPaid,
                email,
                document)
        {
            BoletoNumber = boletoNumber;
        }

        public string BoletoNumber { get; private set; }
    }
}