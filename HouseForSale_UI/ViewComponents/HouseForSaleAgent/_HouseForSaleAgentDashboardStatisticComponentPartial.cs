using HouseForSale_UI.DTOs.ProductDtos;
using HouseForSale_UI.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HouseForSale_UI.ViewComponents.HouseForSaleAgent
{
    public class _HouseForSaleAgentDashboardStatisticComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;
        public _HouseForSaleAgentDashboardStatisticComponentPartial(IHttpClientFactory httpClientFactory, ILoginService loginService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var id = _loginService.GetUserId;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5163/api/HouseForSaleAgentLastProducts?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLast5ProductWithCategoryDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}