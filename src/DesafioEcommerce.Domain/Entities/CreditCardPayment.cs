using DesafioEcommerce.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioEcommerce.Domain.Entities
{
    public class CreditCardPayment : Payment
    {
        public CreditCardPayment(
           string cardHolderName,
           string cardNumber,
           string lastTransactionNumber,
           Name name,
           Address address,
           List<Product> products,
           DateTime paidDate,
           DateTime expireDate,
           decimal total,
           decimal totalPaid,
           Document document,
           Email email) : base(
               name,
               address,
               products,
               total,
               paidDate,
               expireDate,
               totalPaid,
               email,
               document)
        {
            CardHolderName = cardHolderName;
            CardNumber = cardNumber;
            LastTransactionNumber = lastTransactionNumber;
        }

        public string CardHolderName { get; private set; }
        public string CardNumber { get; private set; }
        public string LastTransactionNumber { get; private set; }
    }
}
