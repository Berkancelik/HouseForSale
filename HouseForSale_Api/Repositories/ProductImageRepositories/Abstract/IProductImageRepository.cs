using HouseForSale_Api.DTOs.ProductImageDtos;

namespace HouseForSale_Api.Repositories.ProductImageRepositories.Abstract
{
    public interface IProductImageRepository
    {
        Task<List<GetProductImageByProductIdDto>> GetProductImageByProductId(int id);

    }
}
