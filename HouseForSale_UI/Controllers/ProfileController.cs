using Microsoft.AspNetCore.Mvc;

namespace HouseForSale_UI.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
