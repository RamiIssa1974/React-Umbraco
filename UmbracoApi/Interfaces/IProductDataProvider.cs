using GeneralData.Requests;
using GeneralData.UmbracoModels;

namespace NextStoreApi.Interfaces
{
    public interface IProductDataProvider
    {
        Task<List<ProductModel>> GetProductsAsync(GetProductRequest request);
        Task<List<SaleModel>> GetActiveSalesAsync();


    }
}
