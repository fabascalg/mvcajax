namespace mvcajax.Models
{

    public class Cliente
    {
        public int Id { get; set;}
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        
        public Cliente(){

        }

        public Cliente(int id, string dni, string nombre, string apellidos){
            this.Id = id;
            this.DNI = dni;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
        }

        public Cliente(string dni, string nombre, string apellidos)
        {

            this.DNI = dni;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
        }
    }

}