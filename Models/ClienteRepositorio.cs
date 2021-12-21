using MySql.Data.MySqlClient;
namespace mvcajax.Models;

public class ClienteRepositorio
{
    string connectionString = "datasource=localhost;port=3306;username=root;password=;database=almacen;";
    public List<Cliente> Consulta()
    {
        List<Cliente> lista = new List<Cliente>();
        string query = "SELECT * FROM dbo.clientes";

        MySqlConnection databaseConnection = new MySqlConnection(connectionString);
        MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
        databaseConnection.Open();
        MySqlDataReader reader;
        reader = commandDatabase.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                Cliente cliente = new Cliente(reader.GetString("DNI"), reader.GetString("nombre"), reader.GetString("apellidos"));
                lista.Add(cliente);
            }
        }
        reader.Close();
        databaseConnection.Close();
        return lista;
    }

}