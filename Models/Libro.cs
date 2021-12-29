namespace mvcajax.Models
{

    public class Libro
    {
        public string ISBN { get; set; }

        public string Title { get; set; }

        public Libro()
        {
            this.ISBN = "";
            this.Title = "";
        }

        public Libro(string ISBN)
        {
            this.ISBN = ISBN;
            this.Title = "";
        }

        public Libro(string ISBN, string Title)
        {
            this.ISBN = ISBN;
            this.Title = Title;
        }

        // override object.Equals
        public override bool Equals(object obj)
        {

            Libro otro = (Libro) obj;

            if (obj == null || GetType() != obj.GetType())
            //if (GetType() != obj.GetType())
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