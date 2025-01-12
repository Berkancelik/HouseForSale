using HouseForSale_UI.DTOs.HouseForSaleAgentDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HouseForSale_UI.ViewComponents.HouseForSaleAgent
{
    public class _HouseForSaleAgentDashboardChartComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _HouseForSaleAgentDashboardChartComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5163/api/EstateAgentChart");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultHouseForSaleAgentDashboardChartDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}