using HouseForSale_Api.Repositories.HouseForSaleRepositories.DashborardRepositories.ChartRepositories.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HouseForSale_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseForSaleAgentChartController : ControllerBase
    {
    
    private readonly IChartRepository _chartRepository;
    public HouseForSaleAgentChartController(IChartRepository chartRepository)
    {
        _chartRepository = chartRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Get5CityForChart()
    {
        return Ok(await _chartRepository.Get5CityForChart());
    }
}
}