using HouseForSale_Api.Repositories.ProductRepository.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HouseForSale_UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductDetailsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("GetProductDetailByProductId")]
        public async Task<IActionResult> GetProductDetailByProductId(int id)
        {
            var values = await _productRepository.GetProductDetailByProductId(id);
            return Ok(values);
        }
    }
}