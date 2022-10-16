using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using _2022_5.Models;

namespace _2022_5.Controllers;

[Route("reksio")]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("jasio/{a:evenInt}/{b:int}")]
    public IActionResult Index([FromRoute] int a, [FromRoute] int b)
    {
        ViewData["super-liczba"] = a+b; 
        return View();
    }

    [HttpGet("jasio/{a:int}/{b:int}")]
    public IActionResult Stasio([FromRoute] int a, [FromRoute] int b)
    {
        ViewData["super-liczba"] = a+b; 
        return View("Index");
    }

    [HttpGet("[controller]/privacy")]
    public IActionResult Privacy()
    {
        return View();
    }

    [HttpGet("Error")]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
