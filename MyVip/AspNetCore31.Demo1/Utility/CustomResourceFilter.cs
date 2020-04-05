using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore31.Demo1.Utility
{

    public class CustomResourceFilterAttribute : Attribute, IResourceFilter
    {
        private static Dictionary<string, IActionResult> customCache = new Dictionary<string, IActionResult>();

        /// <summary>
        /// 发生在其他动作之前
        /// </summary>
        /// <param name="context"></param>
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            Console.WriteLine($"this is {nameof(CustomResourceFilterAttribute)} OnResourceExecuted");
            string key = context.HttpContext.Request.Path;
            if (!customCache.ContainsKey(key))
            {
                customCache.Add(key, context.Result);
            }
            
        }

        /// <summary>
        /// 发生在其他动作之后
        /// </summary>
        /// <param name="context"></param>
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            Console.WriteLine($"this is {nameof(CustomResourceFilterAttribute)} OnResourceExecuting");
            string key = context.HttpContext.Request.Path;
            if (customCache.ContainsKey(key))
            {
                context.Result = customCache[key];
            }
        }
    }
}
