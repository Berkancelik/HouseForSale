using Dapper;
using HouseForSale_Api.DTOs.AppUserDtos;
using HouseForSale_Api.Models.DapperContext;
using HouseForSale_Api.Repositories.AppUserRepositories.Abstract;

namespace HouseForSale_Api.Repositories.AppUserRepositories.Concrete
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly Context _context;
        public AppUserRepository(Context context)
        {
            _context = context;
        }
        public async Task<GetAppUserByProductIdDto> GetAppUserByProductId(int id)
        {
            string query = "Select * From AppUser Where UserId=@UserId";
            var parameters = new DynamicParameters();
            parameters.Add("@UserId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetAppUserByProductIdDto>(query, parameters);
                return values;
            }
        }
    }
}