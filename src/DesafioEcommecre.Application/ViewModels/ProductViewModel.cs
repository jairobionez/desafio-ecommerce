using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DesafioEcommerce.Application.ViewModels
{
    /// <summary>
    /// Modelo que representa o produto cadastrado
    /// </summary>
    public class ProductViewModel
    {        
        /// <summary>
        /// Identificador do produto
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Descrição do produto
        /// </summary>
        [MaxLength(50)]
        [DisplayName("Descrição")]
        [Required(ErrorMessage = "A descrição é necessária")]
        public string Description { get; set; }

        /// <summary>
        /// Quantidade em estoque do produto
        /// </summary>
        [DisplayName("Quantidade")]
        [Required(ErrorMessage = "É necessário informar a quantiadde do produto")]
        public int Amount { get; set; }

        /// <summary>
        /// Valor do produto
        /// </summary>
        [DisplayName("Valor")]
        [Required(ErrorMessage = "É necessário informar o valor do produto")]
        public decimal Value { get; set; }

        /// <summary>
        /// Peso do produto
        /// </summary>
        [DisplayName("Peso")]
        [Required(ErrorMessage = "É necessário informar o peso do produto")]
        public decimal Weight { get; set; }
    }
}
