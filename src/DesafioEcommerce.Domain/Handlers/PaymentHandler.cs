using DesafioEcommerce.Domain.Commands;
using DesafioEcommerce.Domain.Entities;
using DesafioEcommerce.Domain.Enums;
using DesafioEcommerce.Domain.Interfaces;
using DesafioEcommerce.Domain.ValueObjects;
using FluentValidation.Results;
using MediatR;
using PaymentContext.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DesafioEcommerce.Domain.Handlers
{
    public class PaymentHandler : 
        IRequestHandler<CreateCreditCardPaymentCommand, CommandResult>,
        IRequestHandler<CreateBoletoPaymentCommand, CommandResult>
    {
        private readonly INotifiable _notifications;

        public PaymentHandler(INotifiable notifications)
        {
            _notifications = notifications;
        }              

        public Task<CommandResult> Handle(CreateBoletoPaymentCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (!command.Valdiate().IsValid)
                {
                    AddNotifications(command.Valdiate().Errors.ToList());
                    return Task.FromResult(new CommandResult("Não foi possível realizar o pagamento"));
                }

                // Gerar VOs
                var name = new Name(command.FirsName, command.LastName);
                var document = new Document(command.Document, EDocumentTypeEnum.CPF);
                var email = new Email(command.Email);
                var address = new Address(command.Street, command.City, command.State, command.ZipCode, command.Neighborhood, command.Number);

                // Gerar entidades
                var payment = new BoletoPayment(name, address, command.Products, command.BarCode, command.BoletoNumber, command.PaidDate,
                                                command.Total, command.TotalPaid, document, email);

                // Dar baixa no estoque

                if (!payment.Validate().IsValid)
                    AddNotifications(payment.Validate().Errors.ToList());

                // Persistência

                return Task.FromResult(new CommandResult("Pagamento realizado com sucesso"));
            }
            catch(Exception ex)
            {
                return Task.FromResult(new CommandResult("Não foi possível realizar o pagamento"));
            }
        }

        public Task<CommandResult> Handle(CreateCreditCardPaymentCommand command, CancellationToken cancellationToken)
        {
            command.Valdiate();
            if (!command.Valdiate().IsValid)
            {
                AddNotifications(command.Valdiate().Errors.ToList());
                return Task.FromResult(new CommandResult("Não foi possível realizar o pagamento"));
            }

            // Gerar VOs
            var name = new Name(command.FirsName, command.LastName);
            var document = new Document(command.Document, EDocumentTypeEnum.CPF);
            var email = new Email(command.Email);
            var address = new Address(command.Street, command.City, command.State, command.ZipCode, command.ZipCode, command.Number);

            // Gerar entidades
            var payment = new CreditCardPayment(command.CardHolderName, command.CardNumber, name,
                                                address, command.Products, command.PaidDate, command.Total, command.TotalPaid,
                                                document, email, command.SecurityCode, command.ValidDate);

            // Dar baixa no estoque

            if (!payment.Validate().IsValid)
                AddNotifications(payment.Validate().Errors.ToList());

            // Persistência

            return Task.FromResult(new CommandResult( "Pagamento realizado com sucesso"));
        }

        public void AddNotifications(List<ValidationFailure> errors)
        {
            errors.ForEach(p =>
            {
                _notifications.AddNotification(p.PropertyName, p.ErrorMessage);
            });
        }
    }
}
