using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NewDawnWeb.Controllers
{
    [Route("ND1")]
    public class ND1DownloadController : Controller
    {
        // GET api/<controller>/5
        [HttpGet("{name}")]     
        public FileResult Download(string name)
        {
            if (name.Contains(".."))
            {
                return File(new byte[0], "application/x-msdownload", name);
            }
            try
            {
                var filepath = $"wwwroot/ND1/{name}";

                byte[] fileBytes = System.IO.File.ReadAllBytes(filepath);
                return File(fileBytes, "application/x-msdownload", name);
            }
            catch
            {
                return File(new byte[0], "application/x-msdownload", name);
            }
        }

        [HttpGet]
        public int GetVersion()
        {
            return 1; 
        }
    }


    [Route("onnetnprotect")]
    public class GGDownloadController : Controller
    {
        // GET api/<controller>/5
        [HttpGet("{name}")]
        public FileResult Download(string name)
        {
            if(name.Contains(".."))
            {
                return File(new byte[0], "application/x-msdownload", name);
            }
            try
            {
                var filepath = $"wwwroot/onnetnprotect/{name}";
                byte[] fileBytes = System.IO.File.ReadAllBytes(filepath);
                return File(fileBytes, "application/x-msdownload", name);
            }
            catch
            {
                return File(new byte[0], "application/x-msdownload", name);
            }
        }
    }


}
