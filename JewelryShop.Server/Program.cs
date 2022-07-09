using JewelryShop.Data;
using JewelryShop.Data.Repository;
using JewelryShop.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<JewelryShopContextDB>(options =>
    options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("JewelryShopDataConnection")));

builder.Services.AddScoped<ICategoryItemRepository, CategoryItemRepository>();
builder.Services.AddScoped<ICategoryProductRepository, CategoryProductRepository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<IPhotoURIRepository, PhotoURIRepository>();
builder.Services.AddScoped<IMaterialRepository, MaterialRepository>();
builder.Services.AddScoped<IPhotoURIRepository, PhotoURIRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ISizeItemRepository, SizeItemRepository>();
builder.Services.AddScoped<ISizeProductRepository, SizeProductRepository>();
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
