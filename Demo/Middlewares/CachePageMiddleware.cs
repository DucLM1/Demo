using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Demo.Middlewares
{
    public class CachePageMiddleware
    {
        private readonly RequestDelegate _next;

        public CachePageMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            #region Logic Request

            Console.WriteLine("CachePageMiddleware Request");

            #endregion Logic Request

            await _next.Invoke(context);

            #region Logic Response

            Console.WriteLine("CachePageMiddleware Response");
            Console.WriteLine();
            #endregion Logic Response
        }
    }
}