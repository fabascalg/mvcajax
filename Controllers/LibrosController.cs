using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mvcajax.Models;

namespace mvcajax.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class LibrosController : ControllerBase
{

    [HttpGet]
    public List<Libro> Get()
    {
        LibrosRepositorio repositorio = new LibrosRepositorio();
        return repositorio.TandaLibros();
    }

    [HttpGet("{isbn}")]
    public Libro Get(string isbn)
    {
        Console.WriteLine("controlador recibe: " + isbn);
        LibrosRepositorio repositorio = new LibrosRepositorio();
        return repositorio.BuscarISBN(isbn);
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
        LibrosRepositorio repositorio = new LibrosRepositorio();
        return repositorio.Crear(libro);
    }

    [HttpPut]
    public void Actualizar(Libro libro)
    {
        LibrosRepositorio repositorio = new LibrosRepositorio();
        repositorio.Actualizar(libro);
    }

    [HttpDelete("{isbn}")]
    public void Borrar(string isbn)
    {
        LibrosRepositorio repositorio = new LibrosRepositorio();
        repositorio.Borrar(new Libro(isbn));
    }

}
