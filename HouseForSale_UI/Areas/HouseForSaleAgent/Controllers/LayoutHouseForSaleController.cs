using Microsoft.AspNetCore.Mvc;

namespace HouseForSale_UI.Areas.HouseForSaleAgent.Controllers
{
    [Area("HouseForSaleAgent")]
    public class LayoutHouseForSaleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
