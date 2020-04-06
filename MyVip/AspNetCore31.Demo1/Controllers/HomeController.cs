using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AspNetCore31.Demo1.Models;
using Microsoft.Extensions.Configuration;
using AspNetCore31.Demo1.Utility;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Authorization;

namespace AspNetCore31.Demo1.Controllers
{
    //[TypeFilter(typeof(CheckLoginActionFilterAttribute))]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IConfiguration configuration;



        public HomeController(ILogger<HomeController> logger, IConfiguration _configuration)
        {
            _logger = logger;
            configuration = _configuration;            
        }


        /// <summary>
        /// 特性是编译时确定的，特性的构造函数只能是常量，参数是运行时生成的。
        /// </summary>
        /// <returns></returns>
        /// Filter特性的四种注入方式
        /// 
        /// 全局注册
        /// ServiceFilter
        /// TypeFilter
        /// IFilterFactory
        /// 
        /// 
        ///[CustomExceptionFilter]
        ///[ServiceFilter(typeof(CustomExceptionFilterAttribute))]       需要把CustomExceptionFilterAttribute 注入到容器里
        ///[TypeFilter(typeof(CustomExceptionFilterAttribute))]
        ///IFilterFactory 需要把CustomExceptionFilterAttribute 注入到容器里//就是Filter的工厂，任何环节都可以用工厂代替Filter里面有ServiceProvider，所
        ///
        /// 
        /// Middleware
        /// 
        /// Authorization filter
        /// 
        /// Resource filter
        /// 
        /// Exception filter
        /// 
        /// Model binding
        /// 
        /// Action filter(before)
        /// 
        /// Action execution
        /// 
        /// Action filter(after)
        /// 
        /// Result filter
        /// 
        /// Result execution 
        /// 
        ///
        ///





      //  [CustomerIOCFilterFactory(typeof(CustomExceptionFilterAttribute))]
        public IActionResult Index()
        {
            var logging_LogLevel_Default = configuration["Logging:LogLevel:Default"];

           // logging_LogLevel_Default = configuration["Logging:LogLevel:Default1"].ToString();

            this.ViewBag.LogLevelDefault = logging_LogLevel_Default;

            return View();
        }

        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
