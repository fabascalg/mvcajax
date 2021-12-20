namespace mvcajax.Models;

public class Persona{
    public string Nombre { get; set; }
    public string Apellidos { get; set; }

    public Persona(string Nombre, string Apellidos){
        this.Nombre=Nombre;
        this.Apellidos=Apellidos;
    }
}