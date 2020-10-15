using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Demo.Middlewares
{
    public class RobotsTxtMiddleware
    {
        private const string Default =
            @"User-Agent: *
        Allow: /";

        private readonly string _environmentName;
        private readonly RequestDelegate _next;
        private readonly string _rootPath;

        public RobotsTxtMiddleware(RequestDelegate next, string environmentName, string rootPath)
        {
            _next = next;
            _environmentName = environmentName;
            _rootPath = rootPath;
        }
       

        public async Task Invoke(HttpContext context)
        {
            Console.WriteLine("RobotsTxtMiddleware request");
            if (context.Request.Path.StartsWithSegments("/robots.txt"))
            {
                var generalRobotsTxt = Path.Combine(_rootPath, "robots.txt");
                var environmentRobotsTxt = Path.Combine(_rootPath, $"robots.{_environmentName}.txt");
                string output;

                if (File.Exists(environmentRobotsTxt))
                    output = await File.ReadAllTextAsync(environmentRobotsTxt);
                else if (File.Exists(generalRobotsTxt))
                    output = await File.ReadAllTextAsync(generalRobotsTxt);
                else
                    output = Default;

                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync(output);

            }
            else
            {
                await _next(context);
            }
        }
    }
}