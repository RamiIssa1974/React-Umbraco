using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralData.UmbracoModels
{
    public class SaleModel
    {
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public List<string> Specifications { get; set; } = new();
        public decimal NormalPrice { get; set; }
        public decimal SalePrice { get; set; }
        public string LegalInfo { get; set; }
        public DateTime SaleDate { get; set; }
    }

}
