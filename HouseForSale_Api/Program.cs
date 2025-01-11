using HouseForSale_Api.Hubs;
using HouseForSale_Api.Models.DapperContext;
using HouseForSale_Api.Repositories.BottomGridRepository.Abstract;
using HouseForSale_Api.Repositories.BottomGridRepository.Concrete;
using HouseForSale_Api.Repositories.CategoryRepository.Abstract;
using HouseForSale_Api.Repositories.CategoryRepository.Concrete;
using HouseForSale_Api.Repositories.ContactRepository.Abstract;
using HouseForSale_Api.Repositories.ContactRepository.Concrete;
using HouseForSale_Api.Repositories.EmployeeRepositories.Abstract;
using HouseForSale_Api.Repositories.EmployeeRepositories.Concrete;
using HouseForSale_Api.Repositories.PopularLocationRepositories.Abstract;
using HouseForSale_Api.Repositories.PopularLocationRepositories.Concrete;
using HouseForSale_Api.Repositories.ServiceRepository.Abstract;
using HouseForSale_Api.Repositories.ServiceRepository.Concrete;
using HouseForSale_Api.Repositories.StatisticsRepositories.Abstract;
using HouseForSale_Api.Repositories.StatisticsRepositories.Concrete;
using HouseForSale_Api.Repositories.TestimonialRepositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<Context>();
builder.Services.AddTransient<ICategoryRepository,CategoryRepository>();
builder.Services.AddTransient<IProductRepository,ProductRepository>();
 builder.Services.AddTransient<IServiceRepository,ServiceRepository>();
builder.Services.AddTransient<IBottomGridRepository, BottomGridRepository>();
builder.Services.AddTransient<IPopularLocationRepository, PopularLocationRepository>();
builder.Services.AddTransient<ITestimonialRepository, TestimonialRepository>();
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddTransient<IStatisticsRepository, StatisticsRepository>();
builder.Services.AddTransient<IWhoWeAreDetailRepository, WhoWeAreDetailRepository>();
builder.Services.AddTransient<IContactRepository, ContactRepository>();


builder.Services.AddCors(option =>
{

    option.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyHeader()
        .AllowAnyMethod()
        .SetIsOriginAllowed((host) => true)
        .AllowCredentials();
    });

});
builder.Services.AddSignalR();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
 
builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapHub<SignalRHub>("/signalrhub");
app.Run();
