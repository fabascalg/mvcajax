using MySql.Data.MySqlClient;
namespace mvcajax.Models;

public class ClienteRepositorio
{
    string connectionString = "datasource=localhost;port=3306;username=root;password=;database=almacen;";
    public List<Cliente> Consulta()
    {
        List<Cliente> lista = new List<Cliente>();
        string query = "SELECT id, dni,nombre,apellidos FROM clientes ORDER BY nombre,apellidos;";

        MySqlConnection databaseConnection = new MySqlConnection(connectionString);
        MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
        databaseConnection.Open();
        MySqlDataReader reader;
        reader = commandDatabase.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                Cliente cliente = new Cliente(reader.GetInt32("Id"), reader.GetString("DNI"), reader.GetString("nombre"), reader.GetString("apellidos"));
                lista.Add(cliente);
            }
        }
        reader.Close();
        databaseConnection.Close();
        return lista;
    }

    public int Insertar(Cliente c)
    {
        string query = "INSERT INTO `clientes` (dni,nombre,apellidos) VALUES ('"+c.DNI+"','"+c.Nombre+"','"+c.Apellidos+"')";

        MySqlConnection databaseConnection = new MySqlConnection(connectionString);
        MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
        databaseConnection.Open();
        commandDatabase.CommandText=query;
        int n = commandDatabase.ExecuteNonQuery();
        databaseConnection.Close();
        return n;
    }    

    public int Borrar(int id)
    {
        string query = "DELETE FROM `clientes` WHERE id="+id.ToString();

        MySqlConnection databaseConnection = new MySqlConnection(connectionString);
        MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
        databaseConnection.Open();
        commandDatabase.CommandText=query;
        int n = commandDatabase.ExecuteNonQuery();
        databaseConnection.Close();
        return n;
    } 

}