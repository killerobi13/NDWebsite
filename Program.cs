using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
 
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace NewDawnWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    #if RELEASE
                    webBuilder.UseHttpSys(options =>
                    {
                        options.AllowSynchronousIO = false;
                        options.Authentication.Schemes = AuthenticationSchemes.None;
                        options.Authentication.AllowAnonymous = true;
                        options.MaxConnections = null;
                        options.MaxRequestBodySize = 30000000;
                        options.UrlPrefixes.Add("http://*:80");
                    });
                    #endif

                    webBuilder.UseStartup<Startup>();
                });
    }
}
