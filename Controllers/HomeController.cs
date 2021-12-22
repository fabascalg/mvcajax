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
        FacturaRepositiorio repo = new FacturaRepositiorio();
        ViewBag.listafacturas = repo.BuscarTodas();
        return View();
    }
    public IActionResult ListaClientes()
    {
        ClienteRepository repo = new ClienteRepository();
        ViewBag.listaClientes = repo.BuscarTodos();
        return View();
    }

    public IActionResult ListaPersonas()
    {
        PersonaRepositiorio repo = new PersonaRepositiorio();
        ViewBag.listapersonas = repo.BuscarTodas();
        return View();
    }
    public ActionResult ListaFacturasJSON(string concepto)
    {
        FacturaRepositiorio repo = new FacturaRepositiorio();
        List<Factura> lista;
        if (concepto != null)
        {
            lista = repo.BuscarTodasPorConcepto(concepto);
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
    public IActionResult Insertar(Cliente cliente)
    {
        ClienteRepository repositorio = new ClienteRepository();
        repositorio.Insertar(cliente);
        List<Cliente> listaClientes = repositorio.BuscarTodos();
        ViewBag.ListaClientes = listaClientes;

        return View("ListaClientes");
    }
    public ActionResult ListaClientesJSON(string nombre)
    {
        ClienteRepository repo = new ClienteRepository();
        List<Cliente> lista;
        if (nombre != null)
        {
            lista = repo.BuscarTodosPorNombre(nombre);
        }
        else
        {
            lista = repo.BuscarTodos();
        }
        return Json(lista);
    }
    public IActionResult ClienteFormulario()
    {
        return View();
    }
    public IActionResult ClienteEditar()
    {
        return View();
    }
    public IActionResult BorrarCliente(Cliente cliente)
    {
        ClienteRepository repo = new ClienteRepository();
        repo.BorrarCliente(cliente);
        // ViewBag.ListaClientes = repo.BuscarTodos();
        return RedirectToAction("ListaClientes", "Home");
    }
    public IActionResult Editar(Cliente cliente)
    {
        ClienteRepository repo = new ClienteRepository();
        repo.Editar(cliente);
        // ViewBag.ListaClientes = repo.BuscarTodos();
        return RedirectToAction("ListaClientes", "Home");
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
