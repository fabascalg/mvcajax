namespace mvcajax.Models;

public class FacturaRepositiorio
{

    public List<Factura> BuscarTodas()
    {
        Factura f1 = new Factura(1, "ordenador", 1500.25m);
        Factura f2 = new Factura(2, "televisor", 895.75m);
        Factura f3 = new Factura(3, "tablet", 250m);
        Factura f4 = new Factura(4, "tabletSuper", 450.0m);
        Factura f5 = new Factura(5, "televisorSuper", 2500m);
        Factura f6 = new Factura(6, "portatil", 700m);

        List<Factura> lista = new List<Factura>();

        lista.Add(f1);
        lista.Add(f2);
        lista.Add(f3);
        lista.Add(f4);
        lista.Add(f5);
        lista.Add(f6);

        return lista;
    }
    public List<Factura> BuscarTodasFiltroConcepto(string concepto)
    {
        Factura f1 = new Factura(1, "ordenador", 1500.25m);
        Factura f2 = new Factura(2, "televisor", 895.75m);
        Factura f3 = new Factura(3, "tablet", 250m);
        Factura f4 = new Factura(4, "tabletSuper", 450.0m);
        Factura f5 = new Factura(5, "televisorSuper", 2500m);
        Factura f6 = new Factura(6, "portatil", 700m);

        List<Factura> lista = new List<Factura>();
        List<Factura> lista2 = new List<Factura>();

        lista.Add(f1);
        lista.Add(f2);
        lista.Add(f3);
        lista.Add(f4);
        lista.Add(f5);
        lista.Add(f6);

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