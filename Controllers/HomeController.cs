using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mvcajax.Models;

namespace mvcajax.Controllers;

public class HomeController : Controller
{
    static List<string> textos = new List<string>();
    static HomeController(){
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
        ViewBag.textos = textos;
        return View();
    }

    public IActionResult ListaFacturas(){
        FacturaRepositiorio repo = new FacturaRepositiorio();
        ViewBag.listafacturas = repo.BuscarTodas();
        return View();
    }

    public IActionResult ListaPersonas(){
        PersonaRepositiorio repo = new PersonaRepositiorio();
        ViewBag.listapersonas = repo.BuscarTodas();
        return View();
    }


    public ActionResult ListaFacturasJSON(string concepto){
        FacturaRepositiorio repo = new FacturaRepositiorio();
        List<Factura> lista;
        if (concepto!=null){
            lista = repo.BuscarTodasFiltroConcepto(concepto);
        } else
        {
            lista = repo.BuscarTodas();
        }
        return Json(lista);
    }

    public ActionResult ListaPersonasJSON(){
        PersonaRepositiorio repo = new PersonaRepositiorio();
        List<Persona> lista = repo.BuscarTodas();
        return Json(lista);
    }    
    public ActionResult Datos(){
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
