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
    public class PaymentViewModel
    {
        [Required]
        [DisplayName("Nome completo")]
        public Name Name { get; set; }

        [Required]
        [DisplayName("Endereço")]
        public Address Address { get; set; }

        [Required]
        [DisplayName("Produtos do carrinho")]
        public List<ProductViewModel> Products { get; set; }

        [Required]
        [DisplayName("Forma de pagamento")]
        public PaymentEnum PaymentForm { get; set; }

        [Required]
        [DisplayName("Total da compra")]
        public decimal Total { get; set; }
    }
}
