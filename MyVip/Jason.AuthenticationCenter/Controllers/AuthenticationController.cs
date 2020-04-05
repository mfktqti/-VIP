using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jason.AuthenticationCenter.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Jason.AuthenticationCenter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private ILogger<AuthenticationController> _logger = null;
        private IJWTService iJWTService = null;
        private readonly IConfiguration configuration;

        public AuthenticationController(ILogger<AuthenticationController> logger,
            IConfiguration _configuration,IJWTService _jWTService)
        {
            _logger = logger;
            configuration = _configuration;
            iJWTService = _jWTService;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(string name,string password)
        {
            if("jason".Equals(name) && "123456".Equals(password))
            {
                string token = iJWTService.GetToken(name);
                return new JsonResult(new { result = true, token });
            }
            else
            {
                return new JsonResult(new { result = false});
            }
        } 
    }
}