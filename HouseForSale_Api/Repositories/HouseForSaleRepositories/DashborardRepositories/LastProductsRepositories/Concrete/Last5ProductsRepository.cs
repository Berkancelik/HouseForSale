using Dapper;
using HouseForSale_Api.DTOs.ProductDTOs;
using HouseForSale_Api.Models.DapperContext;
using HouseForSale_Api.Repositories.HouseForSaleRepositories.DashborardRepositories.LastProductsRepositories.Abstract;

namespace HouseForSale_Api.Repositories.HouseForSaleRepositories.DashborardRepositories.LastProductsRepositories.Concrete
{
    public class Last5ProductsRepository : ILast5ProductsRepository
    {
        private readonly Context _context;
        public Last5ProductsRepository(Context context)
        {
            _context = context;
        }
        public async Task<List<ResultLast5ProductWithCategoryDto>> GetLast5ProductAsync(int id)
        {
            string query = "Select Top(5) ProductId,Title,Price,City,District,ProductCategory,Name,AdvertisementDate From Product Inner Join Category On Product.ProductCategory=Category.CategoryId Where EmployeeId=@employeeId Order By ProductID Desc";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultLast5ProductWithCategoryDto>(query, parameters);
                return values.ToList();
            }
        }
    }
}