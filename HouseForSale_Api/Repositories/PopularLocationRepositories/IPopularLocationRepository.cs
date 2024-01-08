using HouseForSale_Api.DTOs.PopularLocationDTOs;

namespace HouseForSale_Api.Repositories.PopularLocationRepositories
{
    public interface IPopularLocationRepository
    {
        Task<List<ResultPopularLocationDto>> GetAllPopularLocationAsync();
        void CreatePopularLocation(CreatePopularLocationDto createPopularLocationDto);
        void DeletePopularLocation(int id);
        void UpdatePopularLocation(UpdatePopularLocationDto updatePopularLocationDto);
        Task<GetByIDPopularLocationDto> GetPopularLocation(int id);
    }
}