using System.Diagnostics;
using System.Transactions;
using Microsoft.AspNetCore.Mvc;
using SessionWorkshop.Models;

namespace SessionWorkshop.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }


    //home page
    [HttpGet("")]
    public IActionResult Index()
    {
        return View();
    }


    //route to get submission info
    [HttpPost("users/create")]
    public IActionResult CreateUser(User newUser)
    {
        if (ModelState.IsValid)
        {
            HttpContext.Session.SetString("Name", newUser.Name); //first parameter is the key and then the value
        HttpContext.Session.SetInt32("Num", newUser.Num);
        return RedirectToAction("Dashboard");
        }
        return View("Index"); 
    }


    //route to post submission info and redirect to dashboard
    [HttpGet("/dashboard")]
    public IActionResult Dashboard()
    {
        string? Name = HttpContext.Session.GetString("Name");
        if (Name == null) 
        {
            return RedirectToAction("Index");
        }
        // string Name = HttpContext.Session.GetString("Name"); //move this above if statement + make null & instan it
        // Console.WriteLine($"{Name}");
        int? Num = HttpContext.Session.GetInt32("Num");
        return View("Dashboard");
    }


    //log out route/function
    [HttpPost("reset")]
    public IActionResult Reset()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }


    //route + function for adding 1
    [HttpPost("dashboard/plusone")]
    public IActionResult PlusOne()
    {
        int? num = HttpContext.Session.GetInt32("Num");
            num += 1;
            HttpContext.Session.SetInt32("Num", num.Value);
        return RedirectToAction("Dashboard");
    }


    //route + function for subtracting 1
    [HttpPost("dashboard/minusone")]
    public IActionResult MinusOne()
    {
        int? num = HttpContext.Session.GetInt32("Num");
            num -= 1;
            HttpContext.Session.SetInt32("Num", num.Value);
            return RedirectToAction("Dashboard");
    }


    //route + function for multiplying 2
    [HttpPost("dashboard/multiplytwo")]
    public IActionResult MultiplyTwo()
    {
        int? num = HttpContext.Session.GetInt32("Num");
            num *= 2;
            HttpContext.Session.SetInt32("Num", num.Value);
        return RedirectToAction("Dashboard");
    }


    //route + function for plus random
    [HttpPost("dashboard/random")]
    public IActionResult PlusRandom()
    {
        int? num = HttpContext.Session.GetInt32("Num");
            Random random = new Random();
            int randomNumber = random.Next(1, 11);
            num += randomNumber;
            HttpContext.Session.SetInt32("Num", num.Value);
        return RedirectToAction("Dashboard");
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
