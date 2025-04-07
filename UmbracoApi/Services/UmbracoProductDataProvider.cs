 
using GeneralData.Requests;
using GeneralData.UmbracoModels;
using NextStoreApi.Interfaces;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace NextStoreApi.Services.Umbraco
{
    public class UmbracoProductDataProvider : IProductDataProvider
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<UmbracoProductDataProvider> _logger;

        public UmbracoProductDataProvider(HttpClient httpClient, ILogger<UmbracoProductDataProvider> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<List<ProductModel>> GetProductsAsync(GetProductRequest request)
        {
            try
            {
                var url = "http://umbraco.creativehandsco.com/api/products/GetProducts";
                var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(url, content);
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError($"Failed to fetch products: {response.StatusCode}");
                    return new List<ProductModel>();
                }

                var responseContent = await response.Content.ReadAsStringAsync();
                var products = JsonSerializer.Deserialize<List<ProductModel>>(responseContent, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return products ?? new List<ProductModel>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception while calling Umbraco for products");
                return new List<ProductModel>();
            }
        }
    }
}
