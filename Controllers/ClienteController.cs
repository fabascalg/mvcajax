using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mvcajax.Models;

namespace mvcajax.Controllers;

public class ClienteController : Controller
{

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult ListaClientes(){
        ClienteRepositorio repo = new ClienteRepositorio();
        ViewBag.lista = repo.Consulta();
        return View();
    }

}
