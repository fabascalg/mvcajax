namespace mvcajax.Models;

public class PersonaRepositiorio
{
    List<Persona> lista = new List<Persona>();

    public List<Persona> BuscarTodas(){
        Persona p1 = new Persona("Pedro","Pérez González");
        Persona p2 = new Persona("Ana Belén","Ruíz Ortíz");
        lista.Add(p1);
        lista.Add(p2);
        return lista;
    }
}