using Dapper;
using HouseForSale_Api.DTOs.AppUserDtos;
using HouseForSale_Api.DTOs.ProductImageDtos;
using HouseForSale_Api.Models.DapperContext;
using HouseForSale_Api.Repositories.SignUpRepository.Abstract;
using System.Data;

namespace HouseForSale_Api.Repositories.SignUp.Concrete
{
    public class SignUpUserRepository : ISignUpUserRepository
    {
        private readonly Context _context;

        public SignUpUserRepository(Context context)
        {
            _context = context;
        }

        public async Task<int> CreateUserAsync(AppUserDto userDto)
        {
            var query = "INSERT INTO AppUser (UserName, Password, Name, Email, UserRole, VerificationCode) VALUES (@UserName, @Password, @Name, @Email, @UserRole, @VerificationCode)";

            var parameters = new DynamicParameters();
            parameters.Add("@UserName", userDto.UserName);
            parameters.Add("@Password", userDto.Password);
            parameters.Add("@Name", userDto.Name);
            parameters.Add("@Email", userDto.Email);
            parameters.Add("@UserRole", "1"); // Default role
            parameters.Add("@VerificationCode", userDto.VerificationCode);

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.ExecuteAsync(query, parameters);
                return result;
            }
        }

        public async Task<AppUserDto> GetUserByEmailAsync(string email)
        {
            var query = "SELECT * FROM AppUser WHERE Email = @Email";

            var parameters = new DynamicParameters();
            parameters.Add("@Email", email);

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QuerySingleOrDefaultAsync<AppUserDto>(query, parameters);
                return result;
            }
        }

        public async Task<bool> VerifyCodeAsync(string email, string code)
        {
            var query = "SELECT 1 FROM AppUser WHERE Email = @Email AND VerificationCode = @Code";

            var parameters = new DynamicParameters();
            parameters.Add("@Email", email);
            parameters.Add("@Code", code);

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.ExecuteScalarAsync<int>(query, parameters);
                return result == 1;
            }
        }

        public async Task<int> UpdateUserRoleAsync(string email)
        {
            var query = "UPDATE AppUser SET UserRole = '2' WHERE Email = @Email"; // Update role after verification

            var parameters = new DynamicParameters();
            parameters.Add("@Email", email);

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.ExecuteAsync(query, parameters);
                return result;
            }
        }
    }
}
