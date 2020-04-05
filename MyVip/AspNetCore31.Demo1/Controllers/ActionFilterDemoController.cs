using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore31.Demo1.Utility;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore31.Demo1.Controllers
{
    [CustomControllerFilter]
    [CustomActionFilter(Order = 1)]
    public class ActionFilterDemoController : Controller
    {
        /// <summary>
        /// 全局--控制器---Action  Order默认为0，从小到大执行，可以负数
        /// </summary>
        /// <returns></returns>
        [CustomActionFilter(Order =2)]
        [CustomActionFilter]
        public IActionResult Index()
        {
            Console.WriteLine($"this is {nameof(ActionFilterDemoController)} Controller");
            return View();
        }
    }
}