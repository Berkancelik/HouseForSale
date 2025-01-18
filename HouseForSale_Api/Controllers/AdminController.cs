using Microsoft.AspNetCore.Mvc;

namespace HouseForSale_Api.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
