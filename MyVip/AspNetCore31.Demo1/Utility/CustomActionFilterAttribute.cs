using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore31.Demo1.Utility
{
    public class CustomActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"this is {nameof(CustomActionFilterAttribute)} OnActionExecuted,Order={Order}");
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine($"this is {nameof(CustomActionFilterAttribute)} OnActionExecuting,Order={Order}");
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            Console.WriteLine($"this is {nameof(CustomActionFilterAttribute)} OnResultExecuted,Order={Order}");
        }
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            Console.WriteLine($"this is {nameof(CustomActionFilterAttribute)} OnResultExecuting,Order={Order}");
        }

    }

    public class CustomControllerFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"this is {nameof(CustomControllerFilterAttribute)} OnActionExecuted");
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine($"this is {nameof(CustomControllerFilterAttribute)} OnActionExecuting");
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            Console.WriteLine($"this is {nameof(CustomControllerFilterAttribute)} OnResultExecuted");
        }
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            Console.WriteLine($"this is {nameof(CustomControllerFilterAttribute)} OnResultExecuting");
        }

    }
    public class CustomGlobalFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"this is {nameof(CustomGlobalFilterAttribute)} OnActionExecuted,Order={Order}");
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine($"this is {nameof(CustomGlobalFilterAttribute)} OnActionExecuting,Order={Order}");
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            Console.WriteLine($"this is {nameof(CustomGlobalFilterAttribute)} OnResultExecuted,Order={Order}");
        }
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            Console.WriteLine($"this is {nameof(CustomGlobalFilterAttribute)} OnResultExecuting,Order={Order}");
        }

    }

}
