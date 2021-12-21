namespace mvcajax.Models
{

    public class Cliente
    {
        public string DNI { get; set; }
        public string Nombre { get; set; }

        public string Apellidos { get; set; }

        /*public Cliente()
        {

        }*/

        public Cliente(string DNI, string Nombre, String Apellidos)
        {
            this.DNI = DNI;
            this.Nombre = Nombre;
            this.Apellidos = Apellidos;
        }
    }

}