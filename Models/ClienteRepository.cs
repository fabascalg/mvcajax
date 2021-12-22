using MySql.Data.MySqlClient;
using System.Collections.Generic;
namespace mvcajax.Models;

public class ClienteRepository
{
    string connectionString = "datasource=localhost;port=3306;username=root;password=;database=almacen;";
    public void Insertar(Cliente c)
    {
        // Tu consulta en SQL
        string query = "insert into Clientes values ('" + c.DNI + "','" + c.Nombre + "','" + c.Apellidos + "')";


        MySqlConnection databaseConnection = new MySqlConnection(connectionString);
        MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
        databaseConnection.Open();
        commandDatabase.CommandText = query;
        commandDatabase.ExecuteNonQuery();
    }
    public List<Cliente> BuscarTodos()
    {
        // Tu consulta en SQL
        List<Cliente> Lista = new List<Cliente>();
        string query = "SELECT * from Clientes";

        MySqlConnection databaseConnection = new MySqlConnection(connectionString);
        MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
        databaseConnection.Open();
        MySqlDataReader reader;
        reader = commandDatabase.ExecuteReader();
        while (reader.Read())
        {

            Cliente cliente = new Cliente(reader.GetInt32("DNI"), reader.GetString("Nombre"), reader.GetString("Apellidos"));
            Lista.Add(cliente);
        }

        return Lista;
    }

    public List<Cliente> BuscarTodosPorNombre(string nombre)
    {
        List<Cliente> Lista2 = new List<Cliente>();
        string query = "SELECT * from Clientes where nombre=\"" + nombre + "\";";

        MySqlConnection databaseConnection = new MySqlConnection(connectionString);
        MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
        databaseConnection.Open();
        MySqlDataReader reader;
        reader = commandDatabase.ExecuteReader();
        while (reader.Read())
        {
            Cliente cliente = new Cliente(reader.GetInt32("DNI"), reader.GetString("Nombre"), reader.GetString("Apellidos"));
            Lista2.Add(cliente);
        }
        return Lista2;
    }
    public void BorrarCliente(Cliente dni)
    {
        // Tu consulta en SQL
        string query = "DELETE FROM Clientes WHERE DNI = " + dni.DNI + " ";


        MySqlConnection databaseConnection = new MySqlConnection(connectionString);
        MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
        databaseConnection.Open();
        commandDatabase.CommandText = query;
        commandDatabase.ExecuteNonQuery();
    }
}