namespace ConsoleToWebApi
{
    public class MyCustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("incomming request from Custom middleware \n");
            await next(context);
            await context.Response.WriteAsync("incomming request from Custom middleware \n");

        }
    }
}
