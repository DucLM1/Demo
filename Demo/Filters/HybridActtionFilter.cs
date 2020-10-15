using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Demo.Filters
{
    public class HybridActtionFilter : ActionFilterAttribute
    {
        private Stopwatch timer;

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Console.WriteLine("Filter onaction");
            timer = Stopwatch.StartNew();
            await next();
        }

        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            Console.WriteLine("Filter onresult");
            timer.Stop();
            context.Result = new ViewResult
            {
                ViewName = "_ShowTime",
                ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
                {
                    Model = "Elapsed time: " + $"{timer.Elapsed.TotalMilliseconds} ms"
                }
            };
            await next();
        }
    }
}