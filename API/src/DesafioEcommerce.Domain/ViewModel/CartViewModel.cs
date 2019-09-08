using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioEcommerce.Domain.ViewModel
{
    /// <summary>
    /// Modelo que representa os itens no carrinho
    /// </summary>
    public class CartViewModel
    {
        public CartViewModel(int id, int amount, decimal unitPrice, int paymentNumber, string description)
        {
            Id = id;
            Amount = amount;
            UnitPrice = unitPrice;
            PaymentNumber = paymentNumber;
            Description = description;
        }

        /// <summary>
        /// Identificador do produto (SKU)
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Quantidade do produto
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// Preço unitário do produto
        /// </summary>
        public decimal UnitPrice { get; set; }

        [JsonIgnore]
        public int PaymentNumber { get; set; }

        /// <summary>
        /// Descrição do produto
        /// </summary>
        public string Description { get; set; }
    }
}
