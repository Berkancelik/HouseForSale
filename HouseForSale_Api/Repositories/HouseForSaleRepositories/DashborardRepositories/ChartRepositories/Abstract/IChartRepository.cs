using HouseForSale_Api.DTOs.ChartDtos;

namespace HouseForSale_Api.Repositories.HouseForSaleRepositories.DashborardRepositories.ChartRepositories.Abstract
{
    public interface IChartRepository
    {
        Task<List<ResultChartDto>> Get5CityForChart();
    }
}