using Microsoft.AspNetCore.Mvc;

namespace HouseForSale_UI.Areas.HouseForSaleAgent.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
