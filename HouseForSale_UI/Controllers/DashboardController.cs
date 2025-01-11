using Microsoft.AspNetCore.Mvc;

namespace HouseForSale_UI.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
