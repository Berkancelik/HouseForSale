
using Dapper;
using HouseForSale_Api.DTOs.ServiceDTOs;
using HouseForSale_Api.Models.DapperContext;
using HouseForSale_Api.Repositories.ServiceRepository.Abstract;

namespace HouseForSale_Api.Repositories.ServiceRepository.Concrete
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly Context _context;
        public ServiceRepository(Context context)
        {
            _context = context;
        }
        public void CreateService(CreateServiceDto createServiceDto)
        {
            throw new NotImplementedException();
        }

        public void DeleteService(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultServiceDto>> GetAllServiceAsync()
        {
            string query = "Select * From Service";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultServiceDto>(query);
                return values.ToList();
            }
        }

        public Task<GetByIDServiceDto> GetService(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateService(UpdateServiceDto updateServiceDto)
        {
            throw new NotImplementedException();
        }
    }
}