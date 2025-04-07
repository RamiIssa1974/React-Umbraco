using Umbraco.Cms.Core.Notifications;
using Umbraco.Cms.Web.Common.ApplicationBuilder;
using UmbracoApi.Interfaces.Umbraco;
using UmbracoApi.Services.Umbraco;

var builder = WebApplication.CreateBuilder(args);

// Add Umbraco services
builder.Services.AddUmbraco(builder.Environment, builder.Configuration)
    .AddBackOffice()
    .AddWebsite()
    .AddNotificationHandler<ContentPublishedNotification, ProductPublishHandler>()
    .AddComposers()
    .Build();
builder.Services.AddScoped<IUmbracoProductService, UmbracoProductService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

await app.BootUmbracoAsync();

// Add Umbraco middleware
app.UseUmbraco()
   .WithMiddleware(u =>
   {
       u.UseBackOffice();
       u.UseWebsite();
   })
   .WithEndpoints(u =>
   {
       u.UseInstallerEndpoints();
       u.UseBackOfficeEndpoints();
       u.UseWebsiteEndpoints();
   });

app.Run();
