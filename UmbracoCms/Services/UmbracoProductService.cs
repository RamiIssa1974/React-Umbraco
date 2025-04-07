using GeneralData.UmbracoModels;
using UmbracoApi.Interfaces.Umbraco;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common;
using UmbracoApi.Interfaces;
using Umbraco.Cms.Core;
using Newtonsoft.Json;
using GeneralData.UmbracoModels.Dtos;



namespace UmbracoApi.Services.Umbraco
{
    public class UmbracoProductService : IUmbracoProductService
    {
        private readonly IContentService _contentService;
        private readonly IMediaService _mediaService;

        public UmbracoProductService(IContentService contentService, IMediaService mediaService)
        {
            _contentService = contentService;
            _mediaService = mediaService;

        }
        public List<ProductModel> GetAllProducts()
        {
            var allProducts = new List<ProductModel>();

            // Get the "All Products" folder node
            var root = _contentService.GetRootContent().FirstOrDefault(x => x.ContentType.Alias == "productFolder");
            if (root == null) return allProducts;

            var products = _contentService.GetPagedChildren(root.Id, 0, 1000, out long totalItems)
                            .Where(x => x.ContentType.Alias == "product");

            foreach (var item in products)
            {
                List<CategoryModel> categories = GetCategories(item);
                List<ColorModel>? colors = GetAvailableColors(item);
                List<string> images = GetImages(item);

                allProducts.Add(new ProductModel
                {
                    Id = item.Id,
                    ProductName = item.GetValue<string>("productName"),
                    Price = item.GetValue<decimal>("price"),
                    SalePrice = item.GetValue<decimal>("salePrice"),
                    Barcode = item.GetValue<string>("barcode"),
                    Description = item.GetValue<string>("description"),
                    StockQuantity = item.GetValue<int>("stockQuantity"),
                    Categories = categories,
                    AvailableColors = colors,
                    Images = images,
                });
            }

            return allProducts;
        }

        private List<string> GetImages(IContent item)
        {
            var images = new List<string>();

            var json = item.GetValue<string>("productImages");

            if (!string.IsNullOrWhiteSpace(json))
            {
                try
                {
                    var mediaItems = JsonConvert.DeserializeObject<List<ProductMediaDto>>(json);

                    foreach (var mediaItem in mediaItems)
                    {
                        var media = _mediaService.GetById(mediaItem.MediaKey);
                        if (media != null)
                        {
                            var path = media.GetValue<string>("umbracoFile");
                            if (!string.IsNullOrWhiteSpace(path))
                            {
                                var imagePath = JsonConvert.DeserializeObject<ImageFileDto>(path)?.Src;
                                if (!string.IsNullOrWhiteSpace(imagePath))
                                {
                                    images.Add(imagePath);
                                }
                                
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // log if needed
                }
            }

            return images;
        }

        List<CategoryModel> GetCategories(IContent item)
        {
            var categoryIds = item.GetValue<string>("categories");
            var categories = new List<CategoryModel>();
            if (!string.IsNullOrWhiteSpace(categoryIds))
            {
                var udis = categoryIds.Split(',')
                                      .Select(UdiParser.Parse)
                                      .OfType<GuidUdi>();
                foreach (var udi in udis)
                {
                    if (udi is GuidUdi guidUdi)
                    {
                        var categoryContent = _contentService.GetById(guidUdi.Guid);
                        if (categoryContent != null)
                        {
                            categories.Add(new CategoryModel
                            {
                                Id = categoryContent.Id,
                                Name = categoryContent.GetValue<string>("categoryName")
                            });
                        }
                    }
                }
            }

            return categories;
        }
        private static List<ColorModel>? GetAvailableColors(IContent item)
        {
            var colors = new List<ColorModel>();
            var json = item.GetValue<string>("availableColors");

            if (!string.IsNullOrWhiteSpace(json))
            {
                try
                {
                    colors = JsonConvert.DeserializeObject<List<ColorModel>>(json);
                }
                catch (Exception ex)
                {
                    // log or ignore
                }
            }

            return colors;
        }
    }
}
