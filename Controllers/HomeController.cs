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
        ViewBag.textos = textos;
        return View();
    }

    public IActionResult ListaFacturas()
    {
        //FacturaRepositorio repo = new FacturaRepositorio();
        //ViewBag.listafacturas = repo.BuscarTodas();
        return View();
    }

    public IActionResult ListaLibros()
    {
        return View();
    }    

    public IActionResult ListaPersonas()
    {
        PersonaRepositiorio repo = new PersonaRepositiorio();
        ViewBag.listapersonas = repo.BuscarTodas();
        return View();
    }

    [HttpPost]
    public IActionResult InsertarJSON([FromBody] Factura factura)
    {
        FacturaRepositorio repo = new FacturaRepositorio();
        repo.InsertarFactra(factura);
        return Json("Success");
    }

    [HttpPost]
    public IActionResult borrarJSON([FromBody] Factura factura)
    {
        FacturaRepositorio repo = new FacturaRepositorio();
        repo.borrarFactura(factura);
        return Json("Success");
    }

    [HttpPost]
    public ActionResult cargarRegistroJSON([FromBody] Factura x)
    {
        
        FacturaRepositorio repo = new FacturaRepositorio();
        Factura lista = repo.BuscarTodasFiltroNumero(x.Numero);
        return Json(lista);        
    }
    public ActionResult ListaFacturasJSON(string concepto)
    {
        FacturaRepositorio repo = new FacturaRepositorio();
        List<Factura> lista;
        if (concepto != null)
        {
            lista = repo.BuscarTodasFiltroConcepto(concepto);
        }
        else
        {
            lista = repo.BuscarTodas();
        }
        return Json(lista);
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
