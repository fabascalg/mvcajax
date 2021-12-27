using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mvcajax.Models;

namespace mvcajax.Controllers;

[ApiController]
[Route("api/[controller]")]
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

    [HttpGet("{numero}")]
    public Factura Get(int numero)
    {
        FacturaRepositorio repo = new FacturaRepositorio();
        return repo.BuscarTodasFiltroNumero(numero);
    }

    [HttpPost]
    public void Insertar(Factura factura)
    {
        FacturaRepositorio repo = new FacturaRepositorio();
        repo.InsertarFactra(factura);
    }

    [HttpPut]
    public void Actualizar(Factura f)
    {
        FacturaRepositorio repo = new FacturaRepositorio();
        repo.Actualizar(f);
    }

    [HttpDelete ("{Numero:int}")]

    public void Borrar(int numero){
        FacturaRepositorio repo = new FacturaRepositorio();
        repo.Borrar(new Factura(numero));
    }

}
