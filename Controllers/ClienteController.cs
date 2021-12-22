using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mvcajax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
namespace mvcajax.Controllers;

public class ClienteController : Controller
{
    static List<string> textos = new List<string>();
    static ClienteController()
    {
        textos.Add("cli");
        textos.Add("en");
        textos.Add("tes");
    }
    private readonly ILogger<HomeController> _logger;

    public ClienteController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    public IActionResult Index()
    {
        ViewBag.textos = textos;
        return View();
    }
    
    public ActionResult Datos()
    {
        return Content("tu del servidor");
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
}
