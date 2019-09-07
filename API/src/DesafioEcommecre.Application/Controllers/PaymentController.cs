using AutoMapper;
using DesafioEcommerce.Domain.Commands;
using DesafioEcommerce.Domain.Interfaces;
using MediatR;
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
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public PaymentController(INotifiable notifications,
            IMediator mediator,
            IUnitOfWork uow,
            IMapper mapper) : base(notifications, uow)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        /// <summary>
        /// Realiza o pagamento de uma compra por boleto
        /// </summary>
        /// <response code="200">Retorna se o pagamento por boleto foi realizado</response>
        /// <response code="400">Parâmetros inválidos</response>
        /// <response code="500">Retorna um erro interno</response>
        [HttpPost]
        [Route("boleto")]
        [ProducesResponseType(typeof(CommandResult), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Payment([FromBody] CreateBoletoPaymentCommand payment)
        {
            var commandResult = await _mediator.Send(payment);

            return TransactionResponse(commandResult);
        }

        /// <summary>
        /// Realiza o pagamento de uma compra por cartão de crédito
        /// </summary>        
        /// <response code="200">Retorna se o pagamento por cartão de crédito foi realizado</response>
        /// <response code="400">Parâmetros inválidos</response>
        /// <response code="500">Retorna um erro interno</response>
        [HttpPost]
        [ProducesResponseType(typeof(CommandResult), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("credit-card")]
        public async Task<IActionResult> Payment([FromBody] CreateCreditCardPaymentCommand payment)
        {
            var commandResult = await _mediator.Send(payment);

            return TransactionResponse(commandResult);
        }
    }
}