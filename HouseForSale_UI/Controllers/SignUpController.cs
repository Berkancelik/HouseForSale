using HouseForSale_Api.DTOs.AppUserDtos;
using HouseForSale_Api.DTOs.VerifyCodeDtos;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace HouseForSale_UI.Controllers
{
    public class SignUpController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SignUpController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Signup(AppUserDto userDto)
        {
            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(JsonSerializer.Serialize(userDto), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://localhost:5163/api/SignUp/SignUp", content);

            if (response.IsSuccessStatusCode)
            {
                ViewBag.Message = "Kullanıcı başarıyla oluşturuldu. Doğrulama kodu için lütfen e-postanızı kontrol edin.";
            }
            else
            {
                ViewBag.ErrorMessage = "Kayıt işlemi sırasında bir hata oluştu.";
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Verify(VerifyCodeDto verifyCodeDto)
        {
            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(JsonSerializer.Serialize(verifyCodeDto), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://localhost:5163/api/SignUp/verify", content);

            if (response.IsSuccessStatusCode)
            {
                var verifyResponse = await response.Content.ReadAsStringAsync();
                var isVerified = JsonSerializer.Deserialize<bool>(verifyResponse);

                if (isVerified)
                {
                    ViewBag.Message = "Doğrulama başarılı! Ana sayfaya yönlendiriliyorsunuz.";
                    return RedirectToAction("Index", "Home"); // Yönlendirme
                }
                else
                {
                    ViewBag.ErrorMessage = "Geçersiz doğrulama kodu. Lütfen tekrar deneyin.";
                }
            }
            else
            {
                ViewBag.ErrorMessage = "Doğrulama işlemi sırasında bir hata oluştu.";
            }

            return View();
        }
    }
}
