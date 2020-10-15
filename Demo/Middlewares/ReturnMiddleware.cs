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

            await _next.Invoke(context);

            #region Logic Response

            Console.WriteLine("ReturnMiddleware Response");
            Console.WriteLine();

            #endregion Logic Response
        }
    }
}