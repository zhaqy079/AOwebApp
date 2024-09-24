using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AOWebApp.Models;


namespace AOWebApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    // Task 3 modify Index() action result to throw a basic exception
    public IActionResult Index()
    {
        //throw new Exception("This is an error");

        return View();
    }
    //// Task 7 add aa new Action for Test_T7 page
    //public IActionResult Test_T7()
    //{
    //    var id = Request.RouteValues["id"]; // get the id from the Request url
    //    ViewData.Add("id",id);// old way using dict of obj values
    //    ViewBag.id = id;// new way using dynamic obj properties 
    //    return View();
    //}
    // Task 8 Passing parameters
    public IActionResult Test_T7(int? id,string text)
    {
        // defalut values setting
        var val = id;
        var val1 = text;

        ViewBag.id = id;
        ViewBag.searchText = text;
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    // Task 11 RazorTest
    public IActionResult RazorTest()
    {
        return View();
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

