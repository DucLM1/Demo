using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Demo.Middlewares
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            #region Logic Request

            Console.WriteLine("CustomMiddleware Request");

            #endregion Logic Request

            await _next.Invoke(context);

            #region Logic Response

            Console.WriteLine("CustomMiddleware Response");     

            #endregion Logic Response
        }
    }
}