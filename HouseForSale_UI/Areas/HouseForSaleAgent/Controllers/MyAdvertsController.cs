using Microsoft.AspNetCore.Mvc;

namespace HouseForSale_UI.Areas.HouseForSaleAgent.Controllers
{
    [Area("HouseForSaleAgent")]
    public class MyAdvertsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
