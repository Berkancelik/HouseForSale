namespace HouseForSale_UI.DTOs.AppUserDtos
{
    public class AppUserDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public int UserRole { get; set; } = 2;

         public string VerificationCode { get; set; } = new Random().NextInt64(1000000000, 9999999999).ToString();
    }
}
