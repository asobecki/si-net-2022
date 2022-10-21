using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using _2022_6.Models;

namespace _2022_6.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        ViewData["xyz"] = 123;
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [Route("long-action")]
    [HttpGet]
    public async Task<List<int>> LongAction() {

        var task = Task<List<int>>.Run(() => {
                int limit = 100000;

                List<int> resp = new List<int>();
                for(int v=2; resp.Count<limit; v++) {
                    bool notPrime = false;
                    for(int d=2; d<v-1; d++) {
                    if(v%d == 0) {
                        d = v;
                        notPrime = true;
                    }
                    if(!notPrime) resp.Add(v);

                    }
                }
                return resp;
                });

        return await Task.FromResult<List<int>>(task.Result);
    }
}
