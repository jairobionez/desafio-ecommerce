using DesafioEcommerce.Domain.Entities;
using DesafioEcommerce.Domain.Enums;
using DesafioEcommerce.Domain.Interfaces;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;

namespace DesafioEcommerce.Domain.Commands
{
    public class CreateBoletoPaymentCommand : ICommand, IRequest<CommandResult>
    {
        public string FirsName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string BarCode { get; set; }
        public string BoletoNumber { get; set; }
        public string PayerNumber { get; set; }
        public DateTime PaidDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public decimal Total { get; set; }
        public decimal TotalPaid { get; set; }
        public string Payer { get; set; }
        public string PayerDocument { get; set; }
        public EDocumentTypeEnum PayerDocumentType { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string PayerEmail { get; set; }
        public List<Product> Products { get; set; }

        public ValidationResult Valdiate()
        {
            //var result = new CreateBoletoSubscriptionCommandValidation().Validate(this);

            //return result.IsValid;

            return new ValidationResult();
        }
    }
}
