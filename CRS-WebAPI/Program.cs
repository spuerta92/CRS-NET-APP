using CRS_DAO;
using CRS_DAO.EntityFramework;
using CRS_WebAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//==================================================================================================================================
//==================================================================================================================================
//==================================================================================================================================

// SQL repository registration
builder.Services.AddDbContextPool<CrsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerCRSConnectionString")));
builder.Services.AddScoped<ICrsRepository, EFCrsRepository>();

// Mongo repository registration
//builder.Services.AddSingleton<IMongoClient>(serviceProvider =>
//{
//    var settings = builder.Configuration
//                          .GetSection(nameof(MongoDbSettings))
//                          .Get<MongoDbSettings>();
//    return new MongoClient(settings.ConnectionString);
//});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CRS", Version = "v1" });
});

builder.Services.ConfigureCors();

//==================================================================================================================================
//==================================================================================================================================
//==================================================================================================================================
var app = builder.Build();
var env = app.Environment;

// Configure the HTTP request pipeline.
if (env.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CRS v1"));
}

app.UseExceptionHandler("/error");

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseCors();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapControllerRoute(
        "default", "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
