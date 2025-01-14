using HouseForSale_Api.Models.DapperContext;
using HouseForSale_Api.Repositories.AppUserRepositories.Abstract;
using HouseForSale_Api.Repositories.AppUserRepositories.Concrete;
using HouseForSale_Api.Repositories.BottomGridRepository.Abstract;
using HouseForSale_Api.Repositories.BottomGridRepository.Concrete;
using HouseForSale_Api.Repositories.CategoryRepository.Abstract;
using HouseForSale_Api.Repositories.CategoryRepository.Concrete;
using HouseForSale_Api.Repositories.ContactRepository.Abstract;
using HouseForSale_Api.Repositories.ContactRepository.Concrete;
using HouseForSale_Api.Repositories.EmployeeRepositories.Abstract;
using HouseForSale_Api.Repositories.EmployeeRepositories.Concrete;
using HouseForSale_Api.Repositories.HouseForSaleRepositories.DashborardRepositories.ChartRepositories.Abstract;
using HouseForSale_Api.Repositories.HouseForSaleRepositories.DashborardRepositories.ChartRepositories.Concrete;
using HouseForSale_Api.Repositories.HouseForSaleRepositories.DashborardRepositories.LastProductsRepositories.Abstract;
using HouseForSale_Api.Repositories.HouseForSaleRepositories.DashborardRepositories.LastProductsRepositories.Concrete;
using HouseForSale_Api.Repositories.HouseForSaleRepositories.DashborardRepositories.StatisticRepositories.Abstract;
using HouseForSale_Api.Repositories.HouseForSaleRepositories.DashborardRepositories.StatisticRepositories.Concrete;
using HouseForSale_Api.Repositories.MessageRepositories.Abstract;
using HouseForSale_Api.Repositories.MessageRepositories.Concrete;
using HouseForSale_Api.Repositories.MessageRepository.Abstract;
using HouseForSale_Api.Repositories.MessageRepository.Concrete;
using HouseForSale_Api.Repositories.ProductImageRepositories.Abstract;
using HouseForSale_Api.Repositories.ProductImageRepositories.Concrete;
using HouseForSale_Api.Repositories.PropertyAmenityRepository.Abstract;
using HouseForSale_Api.Repositories.PropertyAmenityRepository.Concrete;
using HouseForSale_Api.Repositories.ServiceRepository.Abstract;
using HouseForSale_Api.Repositories.ServiceRepository.Concrete;
using HouseForSale_Api.Repositories.StatisticsRepository.Abstract;
using HouseForSale_Api.Repositories.StatisticsRepository.Concrete;
using HouseForSale_Api.Repositories.SubFeatureRepository.Abstract;
using HouseForSale_Api.Repositories.SubFeatureRepository.Concrete;
using HouseForSale_Api.Repositories.TestimonialRepository.Abstract;
using HouseForSale_Api.Repositories.TestimonialRepository.Concrete;

namespace HouseForSale_Api.Containers
{
    public static class Extensions
    {
        public static void ContainerDependencies(this IServiceCollection services) {



            services.AddTransient<Context>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IServiceRepository, ServiceRepository>();
            services.AddTransient<IBottomGridRepository, BottomGridRepository>();
            services.AddTransient<IPopularLocationRepository, PopularLocationRepository>();
            services.AddTransient<ITestimonialRepository, TestimonialRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IStatisticsRepository, StatisticsRepository>();
            services.AddTransient<IWhoWeAreDetailRepository, WhoWeAreDetailRepository>();
            services.AddTransient<IContactRepository, ContactRepository>();
            services.AddTransient<IChartRepository, ChartRepository>();
            services.AddTransient<ILast5ProductsRepository, Last5ProductsRepository>();
            services.AddTransient<IStatisticRepository, StatisticRepository>();
            services.AddTransient<IMessageRepository, MessageRepository>();
            services.AddTransient<IPropertyAmenityRepository, PropertyAmenityRepository>();
            services.AddTransient<IProductImageRepository, ProductImageRepository>();
            services.AddTransient<IAppUserRepository, AppUserRepository>();
            services.AddTransient<ISubFeatureRepository, SubFeatureRepository>();

        }
    }
}
