using Microsoft.ApplicationInsights.Extensibility.Implementation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Jason.JwtWebApiDemo.Utility
{
    public class JwtCustomerAuthorizeMiddleware
    {
        private readonly RequestDelegate next;
        public JwtCustomerAuthorizeMiddleware(RequestDelegate next, string secret)
        {
            if (!string.IsNullOrEmpty(secret))
            {
                //TokenContext.securityKey = secret;
            }

            this.next = next;
            //  UserContent
        }

        public async Task Invoke(HttpContext context)
        {
            var result = context.Request.Headers.TryGetValue("Authorization", out StringValues authStr);
            IEnumerable<Claim> list  =context.User.Claims;
            if (!result || string.IsNullOrEmpty(authStr.ToString()))
            {
               // throw new UnauthorizedAccessException("未授权");
            }

            await next(context);
        }
    }
}
