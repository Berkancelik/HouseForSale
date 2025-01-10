namespace HouseForSale_Api.Repositories.WhoWeAreRepository.Abstract
{
    using HouseForSale_Api.DTOs.WhoWeAreDetailDTOs;

    namespace RealEstate_Dapper_Api.Repositories.WhoWeAreRepository
    {
        public interface IWhoWeAreDetailRepository
        {
            Task<List<ResultWhoWeAreDetailDto>> GetAllWhoWeAreDetail();
            Task CreateWhoWeAreDetail(CreateWhoWeAreDetailDto createWhoWeAreDetailDto);
            Task DeleteWhoWeAreDetail(int id);
            Task UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDto updateWhoWeAreDetailDto);
            Task<GetByIDWhoWeAreDetailDto> GetWhoWeAreDetail(int id);
        }
    }
}