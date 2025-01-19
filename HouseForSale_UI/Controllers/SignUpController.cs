using HouseForSale_UI.DTOs.AppUserDtos;
using HouseForSale_UI.DTOs.VerifyCodeDtos;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

public class SignUpController : Controller
{
    private readonly HttpClient _httpClient;

    public SignUpController()
    {
        _httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:5163/api/") };
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpGet]
    public IActionResult VerifyCode()
    {
        if (HttpContext.Session.GetString("Email") == null)
        {
            return RedirectToAction("Register");
        }

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(AppUserDto userDto)
    {
        if (string.IsNullOrEmpty(userDto.VerificationCode))
        {
            userDto.VerificationCode = new Random().Next(100000, 999999).ToString();
        }

        var json = JsonSerializer.Serialize(userDto);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("SignUp/SignUp", content);

        if (response.IsSuccessStatusCode)
        {
            HttpContext.Session.SetString("Email", userDto.Email);
            HttpContext.Session.SetInt32("AttemptCount", 0);

            return RedirectToAction("VerifyCode");
        }

        ViewBag.ErrorMessage = await response.Content.ReadAsStringAsync();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> VerifyCode(VerifyCodeDto verifyCodeDto)
    {
        verifyCodeDto.Email = HttpContext.Session.GetString("Email");

        if (string.IsNullOrEmpty(verifyCodeDto.Email))
        {
            ViewBag.ErrorMessage = "E-posta adresi eksik.";
            return View();
        }

        int attemptCount = HttpContext.Session.GetInt32("AttemptCount") ?? 0;
        if (attemptCount >= 5)
        {
            HttpContext.Session.Remove("Email");
            HttpContext.Session.Remove("AttemptCount"); 
            TempData["ErrorMessage"] = "Çok fazla hatalı giriş yaptınız. Lütfen tekrar kayıt olun.";
            return RedirectToAction("Register");
        }

        var json = JsonSerializer.Serialize(verifyCodeDto);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("SignUp/Verify", content);

        if (response.IsSuccessStatusCode)
        {
            HttpContext.Session.Remove("Email");
            HttpContext.Session.Remove("AttemptCount");
            return RedirectToAction("Index", "Login");
        }

         HttpContext.Session.SetInt32("AttemptCount", attemptCount + 1);
        ViewBag.ErrorMessage = "Doğrulama kodu hatalı. Lütfen tekrar deneyin.";
        return View();
    }
}
