using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewDawnWeb.Helpers;
using NewDawnWeb.Services;

namespace NewDawnWeb.Controllers
{
    [Route("ls_auth")]
    public class LoginServerAuthenticationController : Controller
    {
        private UserService userService;
        public LoginServerAuthenticationController(UserService userService)
        {
            this.userService = userService;
        }


        [HttpGet]
        public ContentResult AuthenticateUser()
        {
            string userpassword= Request.Query["userpassword"];
            string userid = Request.Query["userid"];
            string useripaddress = Request.Query["useripaddress"];
            try
            {
             
                if(userService.LoginUserGame(userid, userpassword))
                return base.Content("<result>Success<resultcode>0<br>END SCRIPT<br>", "text/html");
                else
                {
                    return base.Content("<result>Failure<resultcode>127<br>END SCRIPT<br>", "text/html");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return base.Content("<result>Failure<resultcode>127<br>END SCRIPT<br>", "text/html");
            }     
        }
        
    }
}