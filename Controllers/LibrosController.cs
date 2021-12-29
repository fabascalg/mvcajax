using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mvcajax.Models;

namespace mvcajax.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LibrosController : ControllerBase
{

    [HttpGet]
    public List<Libro> Get()
    {
        LibrosRepositorio repo = new LibrosRepositorio();
        return repo.TandaLibros();
    }

    [HttpGet("{isbn}")]
    public Libro GetISBN(string isbn)
    {
        Console.WriteLine("controlador recibe: " + isbn);
        LibrosRepositorio repo = new LibrosRepositorio();
        return repo.BuscarISBN(isbn);
    }

    /*[HttpGet("{isbn,title}")]
    public Libro GetTitle(Libro libro)
    {
        Console.WriteLine("controlador recibe: " + libro.Title);
        LibrosRepositorio repo = new LibrosRepositorio();
        return repo.BuscarISBN(libro.Title);
    }
    */

    [HttpPost]
    public bool Crear(Libro libro)
    {
        LibrosRepositorio repo = new LibrosRepositorio();
        return repo.Crear(libro);
    }

    [HttpPut]
    public void Actualizar(Libro l)
    {
        LibrosRepositorio repo = new LibrosRepositorio();
        repo.Actualizar(l);
    }

    [HttpDelete("{isbn}")]

    public void Borrar(string isbn)
    {
        LibrosRepositorio repo = new LibrosRepositorio();
        repo.Borrar(new Libro(isbn));
    }

}
