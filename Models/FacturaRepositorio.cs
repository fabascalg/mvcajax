namespace mvcajax.Models;

public class FacturaRepositiorio
{
    public List<Factura> BuscarTodas(){
        Factura f1 = new Factura(1,"ordenador",1500.25m);
        Factura f2 = new Factura(2,"televisor",895.75m);
        Factura f3 = new Factura(3,"tablet",250m);

        List<Factura> lista = new List<Factura>();
        lista.Add(f1);
        lista.Add(f2);
        lista.Add(f3);
        return lista;
    }
}