using HouseForSale_Api.DTOs.ServiceDTOs;

namespace HouseForSale_Api.Repositories.ServiceRepository.Abstract
{
    public interface IServiceRepository
    {
        Task<List<ResultServiceDto>> GetAllServiceAsync();
        void CreateService(CreateServiceDto createServiceDto);
        void DeleteService(int id);
        void UpdateService(UpdateServiceDto updateServiceDto);
        Task<GetByIDServiceDto> GetService(int id);
    }
}
