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
    /// <summary>
    /// Comando para realizar um pagamento por boleto
    /// </summary>
    public class CreateBoletoPaymentCommand : ICommand, IRequest<CommandResult>
    {
        /// <summary>
        /// Nome
        /// </summary>
        public string FirsName { get; set; }

        /// <summary>
        /// Sobrenome
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// CPF / CNPJ
        /// </summary>
        public string Document { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Código de barra do boleto
        /// </summary>
        public string BarCode { get; set; }

        /// <summary>
        /// Número do boleto
        /// </summary>
        public string BoletoNumber { get; set; }

        /// <summary>
        /// Total
        /// </summary>
        public decimal Total { get; set; }

        /// <summary>
        /// Total Pago
        /// </summary>
        public decimal TotalPaid { get; set; }

        /// <summary>
        /// Tipo do documento (1-CPF /2-CNPJ)
        /// </summary>
        public EDocumentTypeEnum PayerDocumentType { get; set; }

        /// <summary>
        /// Rua
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Número residêncial
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Bairro
        /// </summary>
        public string Neighborhood { get; set; }

        /// <summary>
        /// Cidade
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Estado
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Pais
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// CEP
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// Produtos no carrinho
        /// </summary>
        public List<CartViewModel> Products { get; set; }

        public ValidationResult Valdiate()
        {
            var result = new CreateBoletoPaymentCommandValidation().Validate(this);

            return result;            
        }
    }
}
