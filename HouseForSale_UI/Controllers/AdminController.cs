using Microsoft.AspNetCore.Mvc;

namespace HouseForSale_UI.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
