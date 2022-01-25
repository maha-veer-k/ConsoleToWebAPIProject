using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using System;

namespace ConsoleToWebApi
{
    public class Program
    {
        public static void Main(String[] args)
        {
            CreateHostBuilder(args).Build().Run();  
        }

        public static IHostBuilder CreateHostBuilder(String[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    }
}