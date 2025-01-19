using HouseForSale_Api.Repositories.HouseForSaleRepositories.DashborardRepositories.StatisticRepositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HouseForSale_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseForSaleAgentStatisticsController : ControllerBase
    {
        private readonly IStatisticRepository _statisticRepository;
        public HouseForSaleAgentStatisticsController(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        [HttpGet("ProductCountByEmployeeId")]
        public IActionResult ProductCountByEmployeeId(int id)
        {
            return Ok(_statisticRepository.ProductCountByEmployeeId(id));
        }

        [HttpGet("ProductCountByStatusTrue")]
        public IActionResult ProductCountByStatusTrue(int id)
        {
            return Ok(_statisticRepository.ProductCountByStatusTrue(id));
        }

        [HttpGet("ProductCountByStatusFalse")]
        public IActionResult ActiveCategoryCount(int id)
        {
            return Ok(_statisticRepository.ProductCountByStatusFalse(id));
        }

        [HttpGet("AllProductCount")]
        public IActionResult AllProductCount()
        {
            return Ok(_statisticRepository.AllProductCount());
        }
    }
}