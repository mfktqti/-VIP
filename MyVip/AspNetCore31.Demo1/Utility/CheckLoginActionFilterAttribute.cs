using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore31.Demo1.Utility
{
    public class CheckLoginActionFilterAttribute:ActionFilterAttribute
    {
        private readonly ILogger<CheckLoginActionFilterAttribute> logger = null;

        public CheckLoginActionFilterAttribute(ILogger<CheckLoginActionFilterAttribute> _logger)
        {
            logger = _logger;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {  
           var currentUser =   context.HttpContext.GetCurrentUserBySession();
            if(null == currentUser)
            {
                context.Result = new RedirectResult("/Login/Login");
            }
            else
            {
                Console.WriteLine($"{currentUser.Name}访问了系统");
                logger.LogDebug($"{currentUser.Name}访问了系统");
            }
        }
    }
}
