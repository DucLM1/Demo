using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Demo.Middlewares
{
    public class Redirect301Middleware
    {
        private readonly RequestDelegate _next;

        public Redirect301Middleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            #region Logic Request

            Console.WriteLine("Redirect301Middleware Request");

            #endregion Logic Request

            await _next.Invoke(context);

            #region Logic Response

            Console.WriteLine("Redirect301Middleware Response");

            #endregion Logic Response
        }
    }

    public class ActionFilterBuilder
    {
        public void Configure(IApplicationBuilder applicationBuilder)
        {
            Console.WriteLine("Redirect301FilterPipeline");
            applicationBuilder.UseRedirect301Middleware();
        }
    } 
}