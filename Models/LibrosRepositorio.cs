using MySql.Data.MySqlClient;
namespace mvcajax.Models;

public class LibrosRepositorio
{
    public static List<Libro> lista = new List<Libro>();

    static int nInstancias = 0;

    string connectionString = "datasource=localhost;port=3306;username=root;password=;database=biblio;";

    public LibrosRepositorio()
    {
        if (nInstancias++ == 0)
        {
            string query = "SELECT id,ISBN,title FROM titles ORDER BY ISBN LIMIT 2000,10;";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            databaseConnection.Open();
            MySqlDataReader reader;
            reader = commandDatabase.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Libro libro = new Libro(reader.GetInt32("id"),reader.GetString("ISBN"), reader.GetString("title"));
                    lista.Add(libro);
                }
            }
            reader.Close();
            databaseConnection.Close();
        }
    }

    public Libro BuscarISBN(string isbn)
    {
        foreach (Libro li in lista)
        {
            if (li.ISBN == isbn)
            {
                return li;
            }
        }
        return new Libro();
    }

    public List<Libro> TandaLibros()
    {
        // aquí se pueden implementar los valores LIMIT de la consulta para paginar resultados
        return lista;
    }

    public List<Libro> BuscarTitulos(string title)
    {
        List<Libro> lista2 = new List<Libro>();
        foreach (Libro l in lista)
        {
            if (l.Title.StartsWith(title))
            {
                lista2.Add(l);
            }
        }
        return lista2;
    }
    public bool Crear(Libro l)
    {
        for (int n = 0; n < lista.Count; n++){
            if (lista[n].Equals(l)){
                return false;
            }
        }
        lista.Add(l);
        return true;
    }

    public void Borrar(Libro l)
    {
        lista.Remove(l);
    }

    public void Actualizar(Libro libro)
    {
        for (int n = 0 ; n < lista.Count ; n++)
        {
            if (lista[n].ISBN == libro.ISBN)
            {
                lista[n]  = libro;
                break;
            }
        }
    }
}