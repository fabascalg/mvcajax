namespace mvcajax.Models
{
    public class Cliente
    {
        public int DNI { get; set; }

        public string Nombre { get; set; }

        public string Apellidos { get; set; }

        public Cliente(int DNI, string Nombre, string Apellidos)
        {
            this.DNI = DNI;
            this.Nombre = Nombre;
            this.Apellidos = Apellidos;
        }
        public Cliente()
        {

        }
    }
}