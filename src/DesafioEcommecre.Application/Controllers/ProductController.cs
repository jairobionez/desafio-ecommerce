using DesafioEcommerce.Domain.Interfaces;
using DesafioEcommerce.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace DesafioEcommerce.Application.Controllers
{
    /// <summary>
    /// Controller of product management
    /// </summary>
    [Route("api/product")]
    [ApiController]
    public class ProductController : BaseController
    {
        private readonly ILogger _logger;
        private readonly IProductService _productService;

        public ProductController(ILoggerFactory loggerFactory, INotifiable notifications,
            IProductService productService) : base(notifications)
        {
            _logger = loggerFactory.CreateLogger<ProductController>();
            _productService = productService;
        }

        /// <summary>
        /// Get all registred products
        /// </summary>
        /// <returns></returns>
        [HttpGet]        
        public async Task<IActionResult> Get()
        {
            var result = _productService.Get();

            _logger.LogInformation("Dados retornados com sucesso");

            return Response(result);
        }
    }
}