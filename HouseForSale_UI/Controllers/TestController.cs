﻿using Microsoft.AspNetCore.Mvc;

namespace HouseForSale_UI.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
