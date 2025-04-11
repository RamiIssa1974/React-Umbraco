using GeneralData.UmbracoModels;

namespace UmbracoApi.Interfaces.Umbraco
{
    public interface IUmbracoProductService
    {
        List<ProductModel> GetAllProducts();
        Task<List<SaleModel>> GetActiveSalesAsync();


    }
}
