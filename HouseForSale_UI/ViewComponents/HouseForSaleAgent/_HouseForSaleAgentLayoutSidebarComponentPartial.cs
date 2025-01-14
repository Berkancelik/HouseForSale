using Microsoft.AspNetCore.Mvc;

namespace HouseForSale_UI.ViewComponents.HouseForSaleAgent
{
    public class _HouseForSaleAgentLayoutSidebarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}