using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GeneralData.UmbracoModels.Dtos
{
    public class ProductMediaDto
    {
        [JsonPropertyName("mediaKey")]
        public Guid MediaKey { get; set; }
    }

}
