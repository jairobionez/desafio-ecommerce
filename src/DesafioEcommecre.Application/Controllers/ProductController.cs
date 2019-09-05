using AutoMapper;
using DesafioEcommerce.Application.ViewModels;
using DesafioEcommerce.Domain.Entities;
using DesafioEcommerce.Domain.Interfaces;
using DesafioEcommerce.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioEcommerce.Application.Controllers
{
    /// <summary>
    /// Controlador de produtos
    /// </summary>
    [Route("api/product")]
    [ApiController]
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public ProductController(INotifiable notifications,
            IUnitOfWork uow,
            ILoggerFactory loggerFactory,
            IProductService productService,
            IMapper mapper) : base(notifications, uow)
        {
            _productService = productService;
            _logger = loggerFactory.CreateLogger<ProductController>();
            _mapper = mapper;
        }

        /// usar fluent assetion para test

        /// <summary>
        /// Método para buscar os produtos cadastrados
        /// </summary>
        /// <returns>Retorna uma lista contendo todos os produtos cadastrados</returns>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Get()
        {
            var result = _mapper.Map<IEnumerable<ProductViewModel>>(_productService.Get());

            return Response(result);
        }

        /// <summary>
        /// Método para buscar um produto especifíco
        /// </summary>
        /// <param name="id">Representa o identicador de pesquisa</param>
        /// <returns>Retorna o produto com o identificador informado</returns>        
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetById(int id)
        {
            var result = _mapper.Map<ProductViewModel>(_productService.GetById(id));

            return Response(result);
        }

        /// <summary>
        /// Inseri um novo produto
        /// </summary>
        /// <param name="obj">Representa o produto a ser inserido</param>
        /// <returns>Retorna o produto inserido</returns>        
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Post([FromBody] ProductViewModel obj)
        {
            var result = _mapper.Map<ProductViewModel>(_productService.Post(_mapper.Map<Product>(obj)));

            return TransactionResponse(result);
        }

        /// <summary>
        /// Atualiza um produto
        /// </summary>
        /// <param name="obj">Representa o produto a ser alterado</param>
        /// <returns>Retorna o produto atualizado</returns>        
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Put([FromBody] ProductViewModel obj)
        {
            var result = _mapper.Map<ProductViewModel>(_productService.Put(_mapper.Map<Product>(obj)));

            return TransactionResponse(result);
        }

        /// <summary>
        /// Deleta um produto
        /// </summary>
        /// <param name="id">Representa o identificador do produto a ser excluído</param>        
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Delete(int id)
        {
            _productService.Delete(id);

            return TransactionResponse();
        }
    }
}