using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GeneralData.UmbracoModels.Dtos
{
    public class ImageFileDto
    {
        [JsonPropertyName("mediaKey")]
        public string Src { get; set; }
    }

}
