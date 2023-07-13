using HomeFindManagement.Contracts.RepositoryContracts;
using HomeFindManagement.Contracts.ServiceContracts;
using HomeFindManagement.Implementations;
using HomeFindManagement.InfrastructureData;
using Microsoft.Extensions.Caching.Memory;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IHomeFinderService, HomeFinderService>();
builder.Services.AddScoped<IRepositoryHoods, RepositoryHoods>();
builder.Services.AddScoped<IRepositoryHomes, RepositoryHomes>();
builder.Services.AddScoped<IRepositoryCache, RepositoryCache>();
builder.Services.AddScoped<IRepositoryAddons, RepositoryAddons>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMemoryCache(memoryCacheOptions =>
{
    memoryCacheOptions.ExpirationScanFrequency = TimeSpan.FromMinutes(3);
    MemoryCacheEntryOptions cacheOptions = new MemoryCacheEntryOptions
    {
        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(6),
        SlidingExpiration = TimeSpan.FromMinutes(1.5)
    };
});

builder.Logging.ClearProviders();

var logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).CreateLogger();

builder.Logging.AddSerilog(logger);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
