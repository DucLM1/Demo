using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Demo.Middlewares
{
    public class ReturnMiddleware
    {
        private readonly RequestDelegate _next;

        public ReturnMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            #region Logic Request

            Console.WriteLine("ReturnMiddleware Request");

            #endregion Logic Request

            if (context.Request.Path.Value.ToLower().Equals("/test"))
            {
                context.Response.Redirect("/", true);
                return;
            }              

            await _next.Invoke(context);

            #region Logic Response

            Console.WriteLine("ReturnMiddleware Response");

            #endregion Logic Response
        }
    }
}