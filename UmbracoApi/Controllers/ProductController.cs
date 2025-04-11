using GeneralData.Requests;
using GeneralData.UmbracoModels;
using Microsoft.AspNetCore.Mvc;
using NextStoreApi.Interfaces;

namespace NextStoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductDataProvider _productProvider;

        public ProductsController(IProductDataProvider productProvider)
        {
            _productProvider = productProvider;
        }

        [HttpPost]
        //[Route("Api/Products/GetProducts")]
        [Route("GetProducts")]
        public async Task<ActionResult<List<ProductModel>>> GetProducts(GetProductRequest request)
        {
            var products = await _productProvider.GetProductsAsync(request);

            return Ok(products);
        }

        [HttpGet("GetActiveSales")]
        public async Task<IActionResult> GetActiveSales()
        {
            var sales = await _productProvider.GetActiveSalesAsync();
            return Ok(sales);
        }


    }
}
