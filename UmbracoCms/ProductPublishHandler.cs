using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Infrastructure.Scoping;
using Microsoft.Extensions.Logging;
using System.Net.Http.Headers;
using System.Net.Http;
using Newtonsoft.Json;

public class ProductPublishHandler : INotificationHandler<ContentPublishedNotification>
{
    private readonly ILogger<ProductPublishHandler> _logger;
    private readonly IMediaService _mediaService;
    private readonly IWebHostEnvironment _env;

    public ProductPublishHandler(ILogger<ProductPublishHandler> logger, IMediaService mediaService, IWebHostEnvironment env)
    {
        _logger = logger;
        _mediaService = mediaService;
        _env = env;
    }

    public void Handle(ContentPublishedNotification notification)
    {
        try
        {
            foreach (var content in notification.PublishedEntities)
            {
                // 🚧 Avoid running for anything other than "product"
                if (content.ContentType?.Alias != "product")
                    continue;

                int productId = content.Id;

                var mediaJson = content.GetValue<string>("productImages");

                if (string.IsNullOrWhiteSpace(mediaJson))
                    continue;

                var mediaKeys = JsonConvert.DeserializeObject<List<ProductMediaDto>>(mediaJson);
                if (mediaKeys == null || !mediaKeys.Any())
                    continue;
                Console.WriteLine("Product published: " + productId);
                Console.WriteLine("Media JSON: " + mediaJson);
                Console.WriteLine("Parsed media count: " + (mediaKeys?.Count ?? 0));

                using var client = new HttpClient();
                using var form = new MultipartFormDataContent();
                form.Add(new StringContent(productId.ToString()), "productId");

                int i = 1;
                foreach (var mediaDto in mediaKeys)
                {
                    var media = _mediaService.GetById(mediaDto.MediaKey);
                    if (media != null)
                    {
                        var fileJson = media.GetValue<string>("umbracoFile")?.TrimStart('/');
                        if (!string.IsNullOrWhiteSpace(fileJson))
                        {
                            var parsed = JsonConvert.DeserializeObject<UmbracoFileValue>(fileJson);
                            var relativePath = parsed?.Src?.TrimStart('/');
                            var fullPath = Path.Combine(_env.WebRootPath, relativePath);
                            if (File.Exists(fullPath))
                            {
                                var fileBytes = File.ReadAllBytes(fullPath);
                                var fileContent = new ByteArrayContent(fileBytes);
                                fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
                                form.Add(fileContent, "files", $"prod_{productId}_{i++}{Path.GetExtension(fullPath)}");
                            }
                        }
                    }
                }
                //var response = client.PostAsync("http://localhost:7163/Api/UploadFilesFromUmbraco", form).Result;
                var response = client.PostAsync("http://194.36.89.39:7163/Api/UploadFilesFromUmbraco", form).Result;
                var result = response.Content.ReadAsStringAsync().Result;
                _logger.LogInformation("Upload result: {result}", result);

            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in ProductPublishHandler");
        }
    }

    private class ProductMediaDto
    {
        [JsonProperty("mediaKey")]
        public Guid MediaKey { get; set; }
    }
    public class UmbracoFileValue
    {
        [JsonProperty("src")]
        public string Src { get; set; }
    }

}
