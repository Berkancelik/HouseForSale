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
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteCategory(int id)
        {
            string query = "Delete From Cateory Where CategoryID=@categoryID";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
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

        public async Task<GetByIdCategoryDto> GetCategoryDto(int id)
        {
            string query = "Select * From Category Where id = @id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIdCategoryDto>(query, parameters);
                return values;
            }
        }

        public async void UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            string query = "Update Category Set Name=@name, Status@status where id=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@name", updateCategoryDto.Name);
            parameters.Add("@status", updateCategoryDto.Status);
            parameters.Add("@id", updateCategoryDto.Id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
