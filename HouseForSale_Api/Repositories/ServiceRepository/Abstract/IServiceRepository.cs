using HouseForSale_Api.DTOs.ServiceDTOs;

namespace HouseForSale_Api.Repositories.ServiceRepository.Abstract
{
 
        public interface IServiceRepository
        {
            Task<List<ResultServiceDto>> GetAllService();
            Task CreateService(CreateServiceDto createServiceDto);
            Task DeleteService(int id);
            Task UpdateService(UpdateServiceDto updateServiceDto);
            Task<GetByIDServiceDto> GetService(int id);
        }
    }