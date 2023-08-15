using Dapper;
using HouseForSale_Api.DTOs.CategoryDTOs;
using HouseForSale_Api.Models.DapperContext;
using HouseForSale_Api.Repositories.CategoryRepository.Abstract;

namespace HouseForSale_Api.Repositories.CategoryRepository.Concrete
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Context _context;

        public CategoryRepository(Context context)
        {
            _context = context;
        }

        public async void CreateCategory(CreateCategoryDto createCategoryDto)
        {
            string query = "Insert Into Category (Name, Status) values (@name, @status)";
            var parameters = new DynamicParameters();
            parameters.Add("@name", createCategoryDto.Name);
            parameters.Add("@status", true);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query,parameters);    
            }
         }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            string query = "Select * From Category";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCategoryDto>(query);
                return values.ToList();

            }
        }
    }
}
