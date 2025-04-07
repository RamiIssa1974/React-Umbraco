 
using NextStoreApi.Interfaces;
using NextStoreApi.Services.Umbraco;

var builder = WebApplication.CreateBuilder(args);
 
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", builder =>
    {
        builder
            .WithOrigins("http://localhost:3000", 
                         "http://react.creativehandsco.com")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});
 
builder.Services.AddHttpClient<IProductDataProvider, UmbracoProductDataProvider>();

var app = builder.Build();
 
 
    app.UseSwagger();
    app.UseSwaggerUI();
 

app.UseCors("AllowFrontend");

app.UseAuthorization();
app.MapControllers();

app.Run();
