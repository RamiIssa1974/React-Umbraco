using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralData.UmbracoModels
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal SalePrice { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public int StockQuantity { get; set; }

        public List<CategoryModel> Categories { get; set; } = new();
        public List<ProductVariationModel> ProductVariations { get; set; } = new();
        public List<ColorModel>? AvailableColors { get; set; }
        public List<string> Images { get; set; } = new();

    }
}
