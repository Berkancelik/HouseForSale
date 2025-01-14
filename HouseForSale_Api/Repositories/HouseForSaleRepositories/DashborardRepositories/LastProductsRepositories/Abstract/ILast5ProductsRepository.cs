using HouseForSale_Api.DTOs.ProductDTOs;

namespace HouseForSale_Api.Repositories.HouseForSaleRepositories.DashborardRepositories.LastProductsRepositories.Abstract
{
    public interface ILast5ProductsRepository
    {
        Task<List<ResultLast5ProductWithCategoryDto>> GetLast5ProductAsync(int id);
    }
}