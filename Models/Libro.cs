namespace mvcajax.Models
{

    public class Libro
    {
        public int id { get; set; }
        public string ISBN { get; set; }

        public string Title { get; set; }

        public Libro()
        {
            this.id = 0;
            this.ISBN = "";
            this.Title = "";
        }

        public Libro(string ISBN)
        {
            this.id = 0;
            this.ISBN = ISBN;
            this.Title = "";
        }

        public Libro(int id, string ISBN, string Title)
        {
            this.id = id;
            this.ISBN = ISBN;
            this.Title = Title;
        }

        // override object.Equals
        public override bool Equals(object obj)
        {

            Libro otro = (Libro)obj;
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            if (otro.ISBN == ISBN)
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
            return ISBN.GetHashCode();
        }
    }

}