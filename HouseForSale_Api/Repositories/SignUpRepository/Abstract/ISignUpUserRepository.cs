using HouseForSale_Api.DTOs.AppUserDtos;

namespace HouseForSale_Api.Repositories.SignUpRepository.Abstract
{
    public interface ISignUpUserRepository
    {
        Task<int> CreateUserAsync(AppUserDto userDto);
        Task<AppUserDto> GetUserByEmailAsync(string email);
        Task<bool> VerifyCodeAsync(string email, string code);
        Task<int> UpdateUserRoleAsync(string email);
    }
}