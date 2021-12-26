namespace mvcajax.Models;

public class FacturaRepositorio
{
    public static List<Factura> lista = new List<Factura>();

    public static int instancias = 0;

    public FacturaRepositorio()
    {
        if (FacturaRepositorio.instancias++ == 0)
        {
            Factura f1 = new Factura(1, "ordenador", 1500.25m);
            Factura f2 = new Factura(2, "televisor", 895.75m);
            Factura f3 = new Factura(3, "tablet", 250m);
            Factura f4 = new Factura(4, "tabletSuper", 450.0m);
            Factura f5 = new Factura(5, "televisorMini", 2500m);
            Factura f6 = new Factura(6, "portatil", 700m);
            Factura f8 = new Factura(8, "ordenador", 1500.25m);
            Factura f10 = new Factura(10, "televisor", 895.75m);
            Factura f11 = new Factura(11, "tablet", 250m);
            Factura f12 = new Factura(12, "tabletSuper", 450.0m);
            Factura f9 = new Factura(9, "televisorSuper", 2500m);
            Factura f7 = new Factura(7, "portatil", 700m);
            lista.Add(f1);
            lista.Add(f2);
            lista.Add(f3);
            lista.Add(f4);
            lista.Add(f5);
            lista.Add(f6);
            lista.Add(f8);
            lista.Add(f9);
            lista.Add(f10);
            lista.Add(f11);
            lista.Add(f12);
            lista.Add(f7);
        }

    }

    public Factura BuscarUna(Factura f)
    {
        Factura f0 = new Factura(0, "", 0.0m);
        for (int n = 0; n < lista.Count(); n++)
        {
            if (lista[n].Numero == f.Numero)
            {
                f0 = lista[n];
                break;
            }
        }
        return f0;
    }

    public List<Factura> BuscarTodas()
    {
        return lista;
    }
    public List<Factura> BuscarTodasFiltroConcepto(string concepto)
    {
        List<Factura> lista2 = new List<Factura>();
        foreach (Factura f in lista)
        {
            if (f.Concepto.StartsWith(concepto))
            {
                lista2.Add(f);
            }
        }
        return lista2;
    }

    public Factura BuscarTodasFiltroNumero(int x)
    {
        Console.WriteLine("recibido el "+x.ToString());
        for (int n = 0; n < lista.Count; n++){
            int valor = lista[n].Numero;
            if (valor == x){
                //Console.WriteLine(lista[n].Numero.ToString()+"\t"+lista[n].Concepto+"\t"+lista[n].Importe.ToString());
                return lista[n];
            }
        }
        Console.WriteLine("no se ha encontrado el número de factura");
        return new Factura();
    }

    public void InsertarFactra(Factura f)
    {
        FacturaRepositorio.lista.Add(f);
        return;
    }

    public void borrarFactura(Factura f)
    {
        // lista.Remove(f);
        for (int n = 0; n < lista.Count; n++)
        {
            if (lista[n].Numero == f.Numero)
            {
                FacturaRepositorio.lista.Remove(lista[n]);
                break;
            }
        }
        return;
    }
}