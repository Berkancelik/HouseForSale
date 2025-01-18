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
        return View();
    }

    


    [HttpPost]
    public async Task<IActionResult> Register(AppUserDto userDto)
    {
        if (string.IsNullOrEmpty(userDto.VerificationCode))
        {
            userDto.VerificationCode = new Random().NextInt64(1000000000, 9999999999).ToString();
        }

        var json = JsonSerializer.Serialize(userDto);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("SignUp/SignUp", content);

        if (response.IsSuccessStatusCode)
        {
            TempData["Email"] = userDto.Email;
            return RedirectToAction("VerifyCode");
        }

        ViewBag.ErrorMessage = await response.Content.ReadAsStringAsync();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> VerifyCode(VerifyCodeDto verifyCodeDto)
{
        verifyCodeDto.Email = TempData["Email"]?.ToString();

        if (string.IsNullOrEmpty(verifyCodeDto.Email))
        {
            ViewBag.ErrorMessage = "E-posta adresi eksik.";
            return View();
        }

        var json = JsonSerializer.Serialize(verifyCodeDto);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("SignUp/Verify", content);

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "Login");
        }

        ViewBag.ErrorMessage = await response.Content.ReadAsStringAsync();
        return View();
    }



}
