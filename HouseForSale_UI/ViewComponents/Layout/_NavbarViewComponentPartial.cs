﻿using Microsoft.AspNetCore.Mvc;

namespace HouseForSale_UI.ViewComponents.Layout
{
    public class _NavbarViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
