using HouseForSale_Api.DTOs.AppUserDtos;

namespace HouseForSale_Api.Repositories.AppUserRepositories.Abstract
{
    public interface IAppUserRepository
    {
        Task<GetAppUserByProductIdDto> GetAppUserByProductId(int id);
    }
}
