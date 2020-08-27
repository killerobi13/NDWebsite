using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NewDawnWeb.Controllers
{
    [Route("check.asp")]
    public class HashCheckController : Controller
    {
        [HttpGet]
        public string Index(string name,string hash)
        {
            Console.WriteLine("Name = {0} , Hash = {1}",name, hash);
            return "ND1_RESULT : 1";
        }
    }


    [Route("/game/check.asp")]
    public class HashCheckGCController : Controller
    {
        [HttpGet]
        public string Index(string name, string hash)
        {
            Console.WriteLine("Name = {0} , Hash = {1}", name, hash);
            return "ND1_RESULT : 1";
        }
    }
}