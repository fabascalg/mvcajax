using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mvcajax.Models;

namespace mvcajax.Controllers;

public class HomeController : Controller
{
    static List<string> textos = new List<string>();
    static HomeController()
    {
        textos.Add("hola");
        textos.Add("que");
        textos.Add("tal");
        textos.Add("estas");
    }

    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        // para el área de textos array
        ViewBag.textos = textos;
        // para el área de personas array por repositorio
        PersonaRepositiorio repo = new PersonaRepositiorio();
        ViewBag.listapersonas = repo.BuscarTodas();
        return View();
    }

    public IActionResult ListaFacturas()
    {
        return View();
    }

    public IActionResult ListaLibros()
    {
        return View();
    }    

    public ActionResult ListaPersonasJSON()
    {
        PersonaRepositiorio repo = new PersonaRepositiorio();
        List<Persona> lista = repo.BuscarTodas();
        return Json(lista);
    }
    public ActionResult Datos()
    {
        return Content("tu del servidor");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
