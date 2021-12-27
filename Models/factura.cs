namespace mvcajax.Models;
public class Factura
{
    public int Numero { get; set; }

    public string Concepto { get; set; }

    public decimal Importe { get; set; }

    public Factura()
    {
        this.Numero = 0;
        this.Concepto = "";
        this.Importe = 0.0m;
    }

    public Factura(int Numero)
    {
        this.Numero = Numero;
        this.Concepto = "";
        this.Importe = 0.0m;
    }

    public Factura(int Numero, string Concepto, decimal Importe)
    {
        this.Numero = Numero;
        this.Concepto = Concepto;
        this.Importe = Importe;
    }

    // override object.Equals
    public override bool Equals(object obj)
    {

        Factura otra = (Factura)obj;

        //if (obj == null || GetType() != obj.GetType())
        if ( GetType() != obj.GetType() )
        {
            return false;
        }

        if (otra.Numero == Numero)
        {

            return true;
        }
        else
        {
            return false;
        }
    }

    // override object.GetHashCode
    public override int GetHashCode()
    {

        return Numero.GetHashCode();
    }


}