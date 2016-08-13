using System;
using Microsoft.AspNetCore.Mvc;

namespace yoasp.Controllers
{
    public class LandingController:Controller 
    {
        public IActionResult Index(string name,int numTimes=1)
        {
            ViewData["Message"]=$"Hello {name}";
            ViewData["NumTimes"]=numTimes;
            return View();
        }
    }
}