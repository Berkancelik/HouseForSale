using Microsoft.AspNetCore.Mvc;

namespace HouseForSale.ViewComponents.HomePage
{
    public class _DefaultBrandComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}