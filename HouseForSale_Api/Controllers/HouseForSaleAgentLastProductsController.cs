using HouseForSale_Api.Repositories.HouseForSaleRepositories.DashborardRepositories.LastProductsRepositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HouseForSale_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseForSaleAgentLastProductsController : ControllerBase
    {
        private readonly ILast5ProductsRepository _lastProductRepository;
        public HouseForSaleAgentLastProductsController(ILast5ProductsRepository lastProductRepository)
        {
            _lastProductRepository = lastProductRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetLast5ProductAsync(int id)
        {
            var values = await _lastProductRepository.GetLast5ProductAsync(id);
            return Ok(values);
        }
    }
}