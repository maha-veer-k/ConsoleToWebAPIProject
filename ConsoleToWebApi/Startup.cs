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
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("hello from middleware1 -> \n");
            //    await next();
            //    await context.Response.WriteAsync("hello from middleware1 <- \n");
            //});

            // //app.Map("/custom", MyCustomMiddleware);

            // app.Use(async (context, next) =>
            // {
            //     await context.Response.WriteAsync("hello from middleware2 -> \n");
            //     await next();
            //     await context.Response.WriteAsync("hello from middleware2 <- \n");
            // });

            // app.Run(async context =>
            // {
            //     await context.Response.WriteAsync("Run method execution \n");
            // });

            //app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
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

        private void MyCustomMiddleware(IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("This is a custom middleware -> \n");
                await next();
            });
        }
    }
}
