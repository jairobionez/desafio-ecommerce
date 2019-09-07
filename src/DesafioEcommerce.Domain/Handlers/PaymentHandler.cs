using DesafioEcommerce.Domain.Commands;
using DesafioEcommerce.Domain.Entities;
using DesafioEcommerce.Domain.Enums;
using DesafioEcommerce.Domain.Interfaces;
using DesafioEcommerce.Domain.Interfaces.Repository;
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
        private readonly IProductRepository _productRepository;
        private readonly IPaymentRepository _paymentRepository;

        public PaymentHandler(INotifiable notifications,
            IProductRepository productRepository,
            IPaymentRepository paymentRepository)
        {
            _notifications = notifications;
            _productRepository = productRepository;
            _paymentRepository = paymentRepository;
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

                var name = new Name(command.FirsName, command.LastName);
                var document = new Document(command.Document, EDocumentTypeEnum.CPF);
                var email = new Email(command.Email);
                var address = new Address(command.Street, command.City, command.State, command.ZipCode, command.Neighborhood, command.Number);

                AddNotifications(name.Validate().Errors.ToList());
                AddNotifications(email.Validate().Errors.ToList());
                AddNotifications(document.Validate().Errors.ToList());
                AddNotifications(address.Validate().Errors.ToList());

                var payment = new BoletoPayment(name, address, command.BarCode, command.BoletoNumber, command.PaidDate,
                                                command.Total, command.TotalPaid, document, email);
                payment.AddItems(command.Products);

                AddNotifications(payment.Validate().Errors.ToList());

                _productRepository.CheckStock(command.Products);

                if (IsValid())
                {
                    var productDrop = (from product in _productRepository.GetTableNoTracking()
                                       join cart in command.Products on product.Id equals cart.Id
                                       select new Product
                                       {
                                           Amount = (product.Amount - cart.Amount),
                                           Description = product.Description,
                                           EanCode = product.EanCode,
                                           Id = product.Id,
                                           Image = product.Image,
                                           Value = product.Value,
                                           Weight = product.Weight
                                       }).ToList();

                    _paymentRepository.Post(payment);
                    _productRepository.PutRange(productDrop);

                    if (!payment.Validate().IsValid)
                        AddNotifications(payment.Validate().Errors.ToList());
                }

                return Task.FromResult(new CommandResult("Pagamento realizado com sucesso"));
            }
            catch (Exception ex)
            {
                return Task.FromResult(new CommandResult("Não foi possível realizar o pagamento"));
            }
        }

        public Task<CommandResult> Handle(CreateCreditCardPaymentCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (!command.Valdiate().IsValid)
                {
                    AddNotifications(command.Valdiate().Errors.ToList());
                    return Task.FromResult(new CommandResult("Não foi possível realizar o pagamento"));
                }

                var name = new Name(command.FirsName, command.LastName);
                var document = new Document(command.Document, EDocumentTypeEnum.CPF);
                var email = new Email(command.Email);
                var address = new Address(command.Street, command.City, command.State, command.ZipCode, command.ZipCode, command.Number);

                AddNotifications(name.Validate().Errors.ToList());
                AddNotifications(email.Validate().Errors.ToList());
                AddNotifications(document.Validate().Errors.ToList());
                AddNotifications(address.Validate().Errors.ToList());


                var payment = new CreditCardPayment(command.CardHolderName, command.CardNumber, name,
                                                    address, command.PaidDate, command.Total, command.TotalPaid,
                                                    document, email, command.SecurityCode, command.ValidDate);
                payment.AddItems(command.Products);

                AddNotifications(payment.Validate().Errors.ToList());

                _productRepository.CheckStock(command.Products);

                if (IsValid())
                {
                    var productDrop = (from product in _productRepository.GetTableNoTracking()
                                       join cart in command.Products on product.Id equals cart.Id
                                       select new Product
                                       {
                                           Amount = (product.Amount - cart.Amount),
                                           Description = product.Description,
                                           EanCode = product.EanCode,
                                           Id = product.Id,
                                           Image = product.Image,
                                           Value = product.Value,
                                           Weight = product.Weight
                                       }).ToList();

                    _paymentRepository.Post(payment);
                    _productRepository.PutRange(productDrop);

                    if (!payment.Validate().IsValid)
                        AddNotifications(payment.Validate().Errors.ToList());

                }

                return Task.FromResult(new CommandResult("Pagamento realizado com sucesso"));
            }
            catch (Exception ex)
            {
                return Task.FromResult(new CommandResult("Não foi possível realizar o pagamento"));
            }

        }

        public void AddNotifications(List<ValidationFailure> errors)
        {
            errors.ForEach(p =>
            {
                _notifications.AddNotification(p.PropertyName, p.ErrorMessage);
            });
        }

        public bool IsValid()
        {
            return !_notifications.HasNotifications();
        }
    }
}
