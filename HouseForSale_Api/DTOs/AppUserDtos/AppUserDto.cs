namespace HouseForSale_Api.DTOs.AppUserDtos
{
    public class AppUserDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int UserRole { get; set; }
        public string VerificationCode { get; set; }
    }
}
