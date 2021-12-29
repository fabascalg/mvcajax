using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mvcajax.Models;


namespace mvcajax.Controllers;

[ApiController]
[Route("api/[controller]")]
//[Area("Maps")]
public class FacturasController : ControllerBase
{

    private readonly ILogger<FacturasController> _logger;

    public FacturasController(ILogger<FacturasController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public List<Factura> Get()
    {
        FacturaRepositorio repo = new FacturaRepositorio();
        return repo.BuscarTodas();
    }

    [HttpGet("{nu:int}")]
    public Factura Get(int nu)
    {
        FacturaRepositorio repo = new FacturaRepositorio();
        return repo.BuscarTodasFiltroNumero(nu);
    }

    //[RequireRequestValue("someString")]
    //[HttpGet("/{cadena}")][FromQuery]
    [HttpGet("{cadena:alpha}")]
    public List<Factura> GetString(string cadena)
    {
        FacturaRepositorio repo = new FacturaRepositorio();
        return repo.BuscarTodasFiltroConcepto(cadena);
    }

    [HttpPost]
    public void Insertar(Factura factura)
    {
        FacturaRepositorio repo = new FacturaRepositorio();
        repo.InsertarFactra(factura);
    }

    [HttpPut("{n}")]
    public void Actualizar(int n, Factura f)
    {
        FacturaRepositorio repo = new FacturaRepositorio();
        repo.Actualizar(n, f);
    }

    [HttpDelete("{n}")]

    public void Borrar(int n)
    {
        FacturaRepositorio repo = new FacturaRepositorio();
        repo.Borrar(new Factura(n));
    }

}
