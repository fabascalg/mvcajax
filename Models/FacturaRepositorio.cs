namespace mvcajax.Models;

public class FacturaRepositiorio
{
    public List<Factura> BuscarTodas()
    {
        Factura f1 = new Factura(1, "ordenador", 1500.25m);
        Factura f2 = new Factura(2, "televisor", 895.75m);
        Factura f3 = new Factura(3, "tablet", 250m);
        Factura f4 = new Factura(4, "pc gaming", 1500m);
        Factura f5 = new Factura(5, "grafica", 2000m);
        Factura f6 = new Factura(6, "barcos", 60000m);
        Factura f7 = new Factura(7, "putes", 6000m);

        List<Factura> lista = new List<Factura>();
        lista.Add(f1);
        lista.Add(f2);
        lista.Add(f3);
        lista.Add(f4);
        lista.Add(f5);
        lista.Add(f6);
        lista.Add(f7);
        return lista;
    }
    public List<Factura> BuscarTodasPorConcepto(string concepto)
    {
        Factura f1 = new Factura(1, "ordenador", 1500.25m);
        Factura f2 = new Factura(2, "televisor", 895.75m);
        Factura f3 = new Factura(3, "tablet", 250m);
        Factura f4 = new Factura(4, "pc gaming", 1500m);
        Factura f5 = new Factura(5, "grafica", 2000m);
        Factura f6 = new Factura(6, "barcos", 60000m);
        Factura f7 = new Factura(7, "putes", 6000m);

        List<Factura> lista = new List<Factura>();
        List<Factura> lista2 = new List<Factura>();
        lista.Add(f1);
        lista.Add(f2);
        lista.Add(f3);
        lista.Add(f4);
        lista.Add(f5);
        lista.Add(f6);
        lista.Add(f7);

        foreach (Factura f in lista)
        {
            if (f.Concepto.StartsWith(concepto))
            {
                lista2.Add(f);
            }
        }
        return lista2;

    }

}