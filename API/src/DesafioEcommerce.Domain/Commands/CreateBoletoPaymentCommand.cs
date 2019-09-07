using DesafioEcommerce.Domain.Enums;
using DesafioEcommerce.Domain.Interfaces;
using DesafioEcommerce.Domain.Validations;
using DesafioEcommerce.Domain.ViewModel;
using MediatR;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Required]
        [MaxLength(30)]
        public string FirsName { get; set; }

        /// <summary>
        /// Sobrenome
        /// </summary>
        [Required]
        [MaxLength(70)]
        public string LastName { get; set; }

        /// <summary>
        /// CPF / CNPJ
        /// </summary>
        [Required]    
        public string Document { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        /// <summary>
        /// Código de barra do boleto
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string BarCode { get; set; }

        /// <summary>
        /// Número do boleto
        /// </summary>
        [Required]
        [MaxLength(60)]
        public string BoletoNumber { get; set; }

        /// <summary>
        /// Total
        /// </summary>
        [Required]
        public decimal Total { get; set; }

        /// <summary>
        /// Total Pago
        /// </summary>
        [Required]
        public decimal TotalPaid { get; set; }

        /// <summary>
        /// Tipo do documento (1-CPF /2-CNPJ)
        /// </summary>]
        [Required]
        public EDocumentTypeEnum PayerDocumentType { get; set; }

        /// <summary>
        /// Rua
        /// </summary>
        [Required]
        [MaxLength(60)]
        public string Street { get; set; }

        /// <summary>
        /// Número residêncial
        /// </summary>
        [Required]
        [MaxLength(6)]
        public string Number { get; set; }

        /// <summary>
        /// Bairro
        /// </summary>
        [Required]
        public string Neighborhood { get; set; }

        /// <summary>
        /// Cidade
        /// </summary>
        [Required]
        [MaxLength(30)]
        public string City { get; set; }

        /// <summary>
        /// Estado
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string State { get; set; }

        /// <summary>
        /// Pais
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string Country { get; set; }

        /// <summary>
        /// CEP
        /// </summary>
        [Required]
        [MaxLength(8)]
        public string ZipCode { get; set; }

        /// <summary>
        /// Produtos no carrinho
        /// </summary>
        [Required]
        public List<CartViewModel> Products { get; set; }

        public FluentValidation.Results.ValidationResult Valdiate()
        {
            var result = new CreateBoletoPaymentCommandValidation().Validate(this);

            return result;            
        }
    }
}
