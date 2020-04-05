using AspNetCore31.Demo1.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore31.Demo1.Utility
{
    public class CustomExceptionFilterAttribute:ExceptionFilterAttribute
    {
        private readonly ILogger<HomeController> logger = null;
        private readonly IModelMetadataProvider modelMetadataProvider = null;
        public CustomExceptionFilterAttribute(ILogger<HomeController> _logger ,
            IModelMetadataProvider _modelMetadataProvider            )
        {
            logger = _logger;
            modelMetadataProvider = _modelMetadataProvider;
        }

        /// <summary>
        /// 异常发生，但是没有处理时
        /// </summary>
        /// <param name="context"></param>

        public override void OnException(ExceptionContext context)
        {
            //base.OnException(context);

            if (!context.ExceptionHandled)
            {
                if(this.IsAjaxRequest(context.HttpContext.Request))
                {
                    context.Result = new JsonResult(new
                    {
                        Result = false,
                        Msg = context.Exception.Message
                    });//中断式--请求到这里结束了，不再继续Action                    
                }
                else
                {

                    //  context.Result = new RedirectResult("/Error/Index?error=" + context.Exception.Message);

                    var result = new ViewResult { ViewName = "~/Views/Shared/Error.cshtml" };

                    result.ViewData = new Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary(
                        modelMetadataProvider, context.ModelState);
                    result.ViewData.Add("Exception", context.Exception);
                    context.Result = result;                   

                }
                logger.LogDebug(context.Exception.Message);
                context.ExceptionHandled = true;
            }
        } 

        /// <summary>
        /// 判断是否是Ajax请求
        /// </summary>
        /// <param name="httpRequest"></param>
        /// <returns></returns>
        private bool IsAjaxRequest(HttpRequest httpRequest)
        {
            string header = httpRequest.Headers["X-Requested-With"];
            return "XMLHttpRequest".Equals(header);
        }




    }
}
