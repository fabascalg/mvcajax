using System.Diagnostics;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using mvcajax.Models;


namespace mvcajax.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[EnableCors]
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
        FacturaRepositorio repositorio = new FacturaRepositorio();
        return repositorio.BuscarTodas();
    }

    [HttpGet("{numeroFactura:int}")]
    public Factura Get(int numeroFactura)
    {
        FacturaRepositorio repositorio = new FacturaRepositorio();
        return repositorio.BuscarPrimeraConFiltroNumero(numeroFactura);
    }
    [HttpGet("{parteDeConcepto:alpha}")]
    public List<Factura> GetString(string parteDeConcepto)
    {
        FacturaRepositorio repositorio = new FacturaRepositorio();
        return repositorio.BuscarTodasFiltroConcepto(parteDeConcepto);
    }

    [HttpPost]
    public void Insertar(Factura factura)
    {
        FacturaRepositorio repositorio = new FacturaRepositorio();
        int resultado = repositorio.InsertarFactra(factura);
    }

    [HttpPut("{numero:int}")]
    public void Actualizar(int numero, Factura f)
    {
        FacturaRepositorio repositorio = new FacturaRepositorio();
        repositorio.Actualizar(numero, f);
    }

    [HttpDelete("{numero:int}")]

    public void Borrar(int numero)
    {
        FacturaRepositorio repositorio = new FacturaRepositorio();
        repositorio.Borrar(new Factura(numero));
    }

}
