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
            List<CartViewModel> products,
            string barCode,
            string boletoNumber,
            DateTime paidDate,
            decimal total,
            decimal totalPaid,
            Document document,
            Email email) : base(
                name,
                address,
                products,
                total,
                paidDate,
                totalPaid,
                email,
                document)
        {
            BarCode = barCode;
            BoletoNumber = boletoNumber;
        }

        public string BarCode { get; private set; }
        public string BoletoNumber { get; private set; }
    }
}