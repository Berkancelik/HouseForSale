using HouseForSale_Api.DTOs.PropertyAmentiyDtos;

namespace HouseForSale_Api.Repositories.PropertyAmenityRepository.Abstract
{
    public interface IPropertyAmenityRepository
    {
        Task<List<ResultPropertyAmenityByStatusTrueDto>> ResultPropertyAmenityByStatusTrue(int id);
    }
}