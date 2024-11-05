using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RestApi.Data;
using RestApi.MessageHandler;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<RestApiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RestApiContext") ?? throw new InvalidOperationException("Connection string 'RestApiContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Api Versioning Using URL
builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.ApiVersionReader = new UrlSegmentApiVersionReader();
});
#endregion

#region Api Versioning Using Header

builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(2, 0);
    options.ApiVersionReader = new MediaTypeApiVersionReader();
});

#endregion

/*builder.Services.AddTransient<ApiKeyMessageHandler>();

builder.Services.AddHttpClient("alex123654@$backtobackwinner")
    .AddHttpMessageHandler<ApiKeyMessageHandler>();
*/

builder.Services.AddControllers(options =>
{
    options.CacheProfiles.Add("Cache",
        new CacheProfile()
        {
            Duration = 600,
            Location = ResponseCacheLocation.Client
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
