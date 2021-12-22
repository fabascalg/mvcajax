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

    public IActionResult ListaClientes()
    {
        ClienteRepositorio repo = new ClienteRepositorio();
        ViewBag.lista = repo.Consulta();
        return View();
    }

    public IActionResult formCliente()
    {
        return View();
    }

    public IActionResult agregarCliente(Cliente c)
    {

        ClienteRepositorio cr = new ClienteRepositorio();
        int n = cr.Insertar(c);
        ViewBag.n = n;

        //List<Cliente> lista = new List<Cliente>();
        //lista = cr.Consulta();
        //ViewBag.lista = lista;

        return RedirectToAction("ListaClientes", "Cliente");

    }

    public IActionResult remover(Cliente c)
    {
        ClienteRepositorio cr = new ClienteRepositorio();
        int n = cr.Borrar(c.Id);
        return RedirectToAction("ListaClientes", "Cliente");
    }

    public IActionResult formClienteE(int n)
    {
        ClienteRepositorio cr = new ClienteRepositorio();
        Cliente cli = cr.Editar(n);
        ViewBag.c = cli;
        return View();
    }
}
