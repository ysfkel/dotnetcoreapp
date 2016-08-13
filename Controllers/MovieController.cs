using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace yoasp.Controllers
{
    public class MovieController:Controller
    {
   
        public IActionResult Index()
        {
            return View();
        }
        // public string Welcome(string name, int numTimes=1)
        // {
        //     return HtmlEncoder.Default.Encode($"Hello {name},number of times{numTimes}");
        // }
    }
}
