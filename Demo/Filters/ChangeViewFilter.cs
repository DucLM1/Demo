using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Demo.Filters
{
    public class ChangeViewFilter : Attribute, IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
            if (true)
            {
                context.Result = new ViewResult
                {
                    ViewName = "Index"
                };
            }
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
        }
    }
}