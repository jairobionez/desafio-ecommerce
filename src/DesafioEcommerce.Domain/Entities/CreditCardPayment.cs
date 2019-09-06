using DesafioEcommerce.Domain.ValueObjects;
using DesafioEcommerce.Domain.ViewModel;
using System;
using System.Collections.Generic;

namespace DesafioEcommerce.Domain.Entities
{
    public class CreditCardPayment : Payment
    {
        public CreditCardPayment(
           string cardHolderName,
           string cardNumber,
           Name name,
           Address address,
           List<CartViewModel> products,
           DateTime paidDate,
           decimal total,
           decimal totalPaid,
           Document document,
           Email email,
           int security,
           DateTime validDate) : base(
               name,
               address,
               products,
               total,
               paidDate,
               totalPaid,
               email,
               document)
        {
            CardHolderName = cardHolderName;
            CardNumber = cardNumber;
            SecurityCode = security;
            ValidDate = validDate;
        }

        public string CardHolderName { get; private set; }
        public string CardNumber { get; private set; }
        public int SecurityCode { get; set; }
        public DateTime ValidDate { get; set; }
    }
}
