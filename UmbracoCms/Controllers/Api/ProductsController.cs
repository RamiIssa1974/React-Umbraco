using GeneralData.Requests;
using GeneralData.UmbracoModels;
using Microsoft.AspNetCore.Mvc;
using UmbracoApi.Interfaces.Umbraco;
 

namespace UmbracoCms.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IUmbracoProductService _productService;

        public ProductsController(IUmbracoProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("GetProducts")]
        public async Task<ActionResult<List<ProductModel>>> GetProducts(GetProductRequest request)
        {
            var products = _productService.GetAllProducts();
            return Ok(products);
        }
        [HttpGet("GetSales")]
        public async Task<ActionResult<List<SaleModel>>> GetSales()
        {
            var sales = await _productService.GetActiveSalesAsync();
            return Ok(sales);
        }
    }
}
