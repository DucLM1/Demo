using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Diagnostics;

namespace Demo.Filters
{
    public class TimeElapsedFilter : Attribute, IActionFilter
    {
        private Stopwatch timer;

        public void OnActionExecuting(ActionExecutingContext context)
        {
            timer = Stopwatch.StartNew();
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            timer.Stop();
            string result = " Elapsed time: " + $"{timer.Elapsed.TotalMilliseconds} ms";
            Console.WriteLine(result);
        }

    }
}