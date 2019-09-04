using DesafioEcommerce.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DesafioEcommerce.Application.Controllers
{
    /// <summary>
    /// Controlador de venda
    /// </summary>
    [Route("api/checkout")]
    [ApiController]
    public class CheckOutController : BaseController
    {        
        public CheckOutController(INotifiable notifications, IUnitOfWork uow) : base(notifications, uow)
        {

        }
    }
}