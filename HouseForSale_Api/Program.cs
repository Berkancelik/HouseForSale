using HouseForSale_Api.Models.DapperContext;
using HouseForSale_Api.Repositories.BottomGridRepositories;
using HouseForSale_Api.Repositories.CategoryRepository.Abstract;
using HouseForSale_Api.Repositories.CategoryRepository.Concrete;
using HouseForSale_Api.Repositories.PopularLocationRepositories;
using HouseForSale_Api.Repositories.ServiceRepository.Abstract;
using HouseForSale_Api.Repositories.ServiceRepository.Concrete;
using HouseForSale_Api.Repositories.TestimonialRepositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<Context>();
builder.Services.AddTransient<ICategoryRepository,CategoryRepository>();
builder.Services.AddTransient<IProductRepository,ProductRepository>();
builder.Services.AddTransient<IWhoWeAreDetailRepository, WhoWeAreDetailRepository>();
builder.Services.AddTransient<IServiceRepository,ServiceRepository>();
builder.Services.AddTransient<IBottomGridRepository, BottomGridRepository>();
builder.Services.AddTransient<IPopularLocationRepository, PopularLocationRepository>();
builder.Services.AddTransient<ITestimonialRepository, TestimonialRepository>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
