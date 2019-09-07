using DesafioEcommerce.Domain.Entities;
using DesafioEcommerce.Domain.Enums;
using DesafioEcommerce.Domain.Interfaces;
using DesafioEcommerce.Domain.Validations;
using DesafioEcommerce.Domain.ViewModel;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;

namespace DesafioEcommerce.Domain.Commands
{
    public class CreateCreditCardPaymentCommand : ICommand, IRequest<CommandResult>
    {
        public string FirsName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public int SecurityCode { get; set; }
        public DateTime ValidDate { get; set; }
        public decimal Total { get; set; }
        public decimal TotalPaid { get; set; }
        public EDocumentTypeEnum PayerDocumentType { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public List<CartViewModel> Products { get; set; }

        public ValidationResult Valdiate()
        {
            var result = new CreateCreditCardPaymentCommandValidation().Validate(this);

            return result;
        }
    }
}
