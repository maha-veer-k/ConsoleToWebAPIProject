using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ConsoleToWebApi
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<MyCustomMiddleware>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello from 1st middlewar. -> \n");
                await next();
                await context.Response.WriteAsync("Hello from 1st middlewar. <- \n");
            });

            app.UseMiddleware<MyCustomMiddleware>();

            /*app.Map("/maptest", MyCustomMiddleware)*/;

            //app.Map("/auth", a =>
            //{
            //    a.Use(async (context, next) =>
            //    {
            //        await context.Response.WriteAsync("New branch for auth");
            //        await next();
            //    });
            //});

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello from Run() Middleware \n");
            });

            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("hello from middleware2 -> \n");
            //    await next();
            //    await context.Response.WriteAsync("hello from middleware2 <- \n");
            //}); 

            //private static void ConfigureMapping(IApplicationBuilder app) => 

            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("Run method execution \n");
            //});

            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}



            //app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello from default");
            //    });
            //});

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/mahaveer", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello Mahaveer");
            //    });
            //});
        }



        private  void MyCustomMiddleware(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("This is a Map middleware -> \n");
            });
        }
    }
}
