using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace myown.Controllers;

public class HelloWorldController : Controller
{
    //
    // GET: /HelloWorld/
    // Por exemplo, digite: http://localhost:{porta}/HelloWorld
    public IActionResult Index() => View();

    //
    // GET: /HelloWorld/Welcome/
    // Por exemplo, digite: http://localhost:{porta}/HelloWorld/Welcome?name=Rick&numtimes=4
    public IActionResult Welcome(string name, int numTimes = 1)
    {
        ViewData["Message"] = "Hello, " + name;
        ViewData["NumTimes"] = numTimes;
        return View();
    }
}