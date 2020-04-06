using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
 
using Microsoft.AspNetCore.Http;
using AspNetCore31.Demo1.Models;
using AspNetCore31.Demo1.Utility;
using System.Security.Claims;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Logging;

namespace AspNetCore31.Demo1.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger = null;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
         
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string name,string password,string verify)
        {
            string verifyCode = base.HttpContext.Session.GetString("CheckCode");

            if(verifyCode != null && verifyCode.Equals(verify, StringComparison.CurrentCultureIgnoreCase))
            {
                if("Jason".Equals(name) && "123456".Equals(password))
                {
                    CurrentUser currentUser = new CurrentUser() {
                        Id = 123,
                        Name = "Jason",
                        Account = "Administrator",
                        Email = "57265177",
                        Password = "123456",
                        LoginTime = DateTime.Now
                    };

                    HttpContext.SetCookies("CurrentUser", Newtonsoft.Json.JsonConvert.SerializeObject(currentUser));

                    HttpContext.Session.SetString("CurrentUser", Newtonsoft.Json.JsonConvert.SerializeObject(currentUser));

                    var claims = new List<Claim>() {
                        new Claim(ClaimTypes.Name,name),
                        new Claim("password",password)
                    };

                    var userPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims, "Customer"));
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal, new AuthenticationProperties {

                       ExpiresUtc = DateTime.UtcNow.AddMinutes(30)

                    }).Wait();

                    //cookie 策略--用户信息--过期时间

                    return Redirect("/Home/index");


                }
                else
                {
                    ViewBag.Msg = "帐号密码错误";
                }
            }
            else
            {
                ViewBag.Msg = "验证码错误";
            }
        
            return View();
        }
     
        
        public ActionResult VerifyCode()
        {
            string code = "";
            Bitmap bitmap = VerifyCodeHelper.CreateVerifyCode(out code);
            base.HttpContext.Session.SetString("CheckCode", code);
            MemoryStream stream = new MemoryStream();
            bitmap.Save(stream, ImageFormat.Gif);
            return File(stream.ToArray(), "image/gif");
        }

        [HttpPost]
        //[CustomAllowAnonymous]
        public ActionResult Logout()
        {
            #region Cookie
            base.HttpContext.Response.Cookies.Delete("CurrentUser");
            #endregion Cookie

            #region Session
            CurrentUser sessionUser = base.HttpContext.GetCurrentUserBySession();
            if (sessionUser != null)
            {
                this._logger.LogDebug(string.Format("用户id={0} Name={1}退出系统", sessionUser.Id, sessionUser.Name));
            }
            base.HttpContext.Session.Remove("CurrentUser");
            base.HttpContext.Session.Clear();
            #endregion Session

            #region MyRegion
            //HttpContext.User.Claims//其他信息
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme).Wait();
            #endregion
            return RedirectToAction("Index", "Home"); ;
        }
    }
}