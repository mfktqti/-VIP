using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore31.Demo1.Utility;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore31.Demo1.Controllers
{

    public class ResourceController : Controller
    {
        [CustomActionFilter]
        [CustomResourceFilter]
        public IActionResult Index()
        {
            ViewBag.ActionNow = DateTime.Now;
            return View();
        }
    }
}