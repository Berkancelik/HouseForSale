using Microsoft.AspNetCore.Mvc;

namespace HouseForSalewh.ViewComponents.HomePage
{
    public class _DefaultBrandComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}