using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewDawnWeb.Exceptions;
using NewDawnWeb.Models;
using NewDawnWeb.Services;

namespace BlazorCookieAuth.Server.Pages
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        UserService userService;
        public LoginController(UserService userService)
        {
            this.userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            // Clear the existing external cookie
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return LocalRedirect("/");
        }

        [HttpPost]
        public  IActionResult Login(string paramUsername, string paramPassword)
        {

            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme).GetAwaiter().GetResult();


            int loginResult = userService.LoginUser(paramUsername, paramPassword);
            string role="User";
            if (loginResult == 2)
            {
                role = "GM";
            }
            else if (loginResult == 1) 
            {
                role = "User"; 
            }
            else
            {
                return LocalRedirect("/?error=Login Failed");
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, paramUsername),
                new Claim(ClaimTypes.Role, role),
            };
            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true,
                RedirectUri = this.Request.Host.Value
            };
                  
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,new ClaimsPrincipal(claimsIdentity),authProperties).GetAwaiter().GetResult();
            

            return LocalRedirect("/");
        }
    }
}