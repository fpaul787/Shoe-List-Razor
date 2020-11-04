using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ShoeListRazor.Controllers
{
    public class ShoeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
