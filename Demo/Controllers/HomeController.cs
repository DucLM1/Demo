using Demo.Filters;
using Demo.Middlewares;
using Demo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Demo.Controllers
{
    //[HybridActtionFilter]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        //[HttpsOnlyFilter]
        public IActionResult Index()
        {
            return View();
        }


        //[TimeElapsedFilter]
        //[ChangeViewFilter]
        
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// MiddlewareFilter Case 1
        /// </summary>
        /// <returns></returns>
        [MiddlewareFilter(typeof(ActionFilterBuilder))]
        public IActionResult Testing()
        {
            return View();
        }

        // Built-in-filter
        //[RequireHttps]
        public IActionResult Testing2()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}