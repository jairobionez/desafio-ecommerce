using DesafioEcommerce.Application.ViewModels;
using DesafioEcommerce.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DesafioEcommerce.Application.Controllers
{
    /// <summary>
    /// Controlador de venda
    /// </summary>
    [Route("api/payment")]
    [ApiController]
    public class PaymentController : BaseController
    {        
        public PaymentController(INotifiable notifications, IUnitOfWork uow) : base(notifications, uow)
        {

        }

        /// <summary>
        /// Realiza o pagamento de uma compra
        /// </summary>        
        [HttpPost]
        public async Task<IActionResult> Payment([FromBody] PaymentViewModel payment)
        {
            return null;
        }
    }
}