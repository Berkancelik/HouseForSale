using HouseForSale_Api.DTOs.AppUserDtos;
using HouseForSale_Api.DTOs.VerifyCodeDtos;
using HouseForSale_Api.Repositories.SignUpRepository.Abstract;
using HouseForSale_Api.Services.MailService;
using Microsoft.AspNetCore.Mvc;

namespace HouseForSale_UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignUpController : ControllerBase
    {
        private readonly ISignUpUserRepository _userRepository;
        private readonly MailService _mailService;

        public SignUpController(ISignUpUserRepository userRepository, MailService mailService)
        {
            _userRepository = userRepository;
            _mailService = mailService;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> Signup([FromBody] AppUserDto userDto)
        {
            var existingUser = await _userRepository.GetUserByEmailAsync(userDto.Email);
            if (existingUser != null)
            {
                return BadRequest("Kullanıcı zaten mevcut.");
            }

            var verificationCode = new Random().Next(100000, 999999).ToString();
            userDto.VerificationCode = verificationCode;

            var result = await _userRepository.CreateUserAsync(userDto);

            if (result > 0)
            {
                try
                {
                    _mailService.SendVerificationEmail(userDto.Email, verificationCode);
                    return Ok("Kullanıcı oluşturuldu. Doğrulama kodu için lütfen e-postanızı kontrol edin.");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "E-posta gönderimi sırasında bir hata oluştu: " + ex.Message);
                }
            }

            return StatusCode(500, "Kullanıcı oluşturulurken bir hata oluştu.");
        }

        [HttpPost("Verify")]
        public async Task<IActionResult> Verify([FromBody] VerifyCodeDto verifyCodeDto)
        {
            var isVerified = await _userRepository.VerifyCodeAsync(verifyCodeDto.Email, verifyCodeDto.Code);

            if (isVerified)
            {
                await _userRepository.UpdateUserRoleAsync(verifyCodeDto.Email);
                return Ok("Doğrulama başarılı.");
            }

            return BadRequest("Geçersiz doğrulama kodu.");
        }
    }
}