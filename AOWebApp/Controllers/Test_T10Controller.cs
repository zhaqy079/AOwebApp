using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AOWebApp.Models;

namespace AOWebApp.Controllers
{
    public class Test_T10Controller : Controller
    {
        // copy from HomeController
        private readonly ILogger<Test_T10Controller> _logger;

        public Test_T10Controller(ILogger<Test_T10Controller> logger)
        {
            _logger = logger;
        }
        // Task 10 add a new testController
        public IActionResult Index()
        {
            return View();
        }
        // Prac 02 Task1 update another Razor Test
        public IActionResult RazorTest(int? id, string queryParam, string formParam)
        {
            ViewBag.RouteParam = id;
            ViewBag.QueryParam = queryParam;
            ViewBag.FormParam = formParam;
            return View();
        }


        // copy from HomeController
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

