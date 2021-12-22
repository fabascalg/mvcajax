using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mvcajax.Models;
using MySql.Data.MySqlClient;

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

    public IActionResult modificarCliente(Cliente c)
    {
        ClienteRepositorio cr = new ClienteRepositorio();
        int n = cr.Grabar(c);
        ViewBag.n = n;
        return RedirectToAction("ListaClientes", "Cliente");
    }

    public IActionResult remover(Cliente c)
    {
        ClienteRepositorio cr = new ClienteRepositorio();
        int n = cr.Borrar(c.Id);
        return RedirectToAction("ListaClientes", "Cliente");
    }

    public IActionResult formClienteE(Cliente c)
    {
        Cliente cli = new Cliente();
        ClienteRepositorio cr = new ClienteRepositorio();
        cli = cr.Editar(c);
        ViewBag.cli = cli;
        return View();
    }


}
