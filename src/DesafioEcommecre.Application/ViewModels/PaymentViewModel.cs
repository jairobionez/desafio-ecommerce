using DesafioEcommerce.Domain.Enums;
using DesafioEcommerce.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioEcommerce.Application.ViewModels
{
    /// <summary>
    /// Modelo para realizar um pagamento
    /// </summary>
    public class PaymentViewModel
    {
        /// <summary>
        /// Nome do usuário
        /// </summary>
        [Required]
        [DisplayName("Nome")]
        public string FirstName { get; set; }

        /// <summary>
        /// Sobrenome do usuário
        /// </summary>
        [Required]
        [DisplayName("Sobrenome")]
        public string LastName { get; set; }

        /// <summary>
        /// Rua
        /// </summary>
        [MaxLength(100)]
        [DisplayName("Rua")]
        public string Street { get; private set; }

        /// <summary>
        /// Cidade
        /// </summary>
        [MaxLength(100)]
        [DisplayName("Cidade")]
        public string City { get; private set; }

        /// <summary>
        /// Estado
        /// </summary>
        [MaxLength(50)]
        [DisplayName("Estado")]
        public string State { get; private set; }

        /// <summary>
        /// CEP
        /// </summary>
        [MaxLength(8)]
        [DisplayName("CEP")]
        public string ZipCode { get; private set; }

        /// <summary>
        /// Bairro
        /// </summary>
        [DisplayName("Bairro")]
        [MaxLength(30)]
        public string Neighborhood { get; private set; }

        /// <summary>
        /// Número residencial
        /// </summary>
        [DisplayName("Numero")]
        public int Number { get; private set; }

        /// <summary>
        /// Produtos no carrinho
        /// </summary>
        [Required]
        [DisplayName("Produtos do carrinho")]
        public List<ProductViewModel> Products { get; set; }

        /// <summary>
        /// Forma de pagamento
        /// </summary>
        [Required]
        [DisplayName("Forma de pagamento")]
        public PaymentEnum PaymentForm { get; set; }

        /// <summary>
        /// Total da compra
        /// </summary>
        [Required]
        [DisplayName("Total da compra")]
        public decimal Total { get; set; }
        
        /// <summary>
        /// Número do cartão de crédito
        /// </summary>
        [DisplayName("Cartão de crédito")]
        public int CreditCardNumber { get; set; }
    }
}
