using HouseForSale_Api.DTOs.ProductDTOs;

namespace HouseForSale_Api.Repositories.CategoryRepository.Abstract
{
    public interface IProductRepository
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task<List<ResultProductWithCategoryDto>> GetAllProductWtihCategoryAsync();

    }
}
