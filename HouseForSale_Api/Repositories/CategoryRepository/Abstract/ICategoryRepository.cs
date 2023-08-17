using HouseForSale_Api.DTOs.CategoryDTOs;

namespace HouseForSale_Api.Repositories.CategoryRepository.Abstract
{
    public interface ICategoryRepository
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        void CreateCategory(CreateCategoryDto createCategoryDto);
        void UpdateCategory(UpdateCategoryDto updateCategoryDto);
        
        void DeleteCategory(int id);
    }
}
