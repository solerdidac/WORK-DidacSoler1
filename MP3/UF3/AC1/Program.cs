using System;
using System.Data.SQLite;
using System.IO;

class Producto
{
    public string Nombre { get; set; }
    public double Precio { get; set; }
    public int Cantidad { get; set; }
}

class Program
{
    static string dbFile = "productos.db";
    static string connectionString = $"Data Source={dbFile};Version=3;";

    static void Main()
    {
        CrearBaseDeDatosSiNoExiste();

        while (true)
        {
            Console.WriteLine("\n--- MENÚ PRODUCTOS ---");
            Console.WriteLine("1. Crear Producto");
            Console.WriteLine("2. Listar Productos");
            Console.WriteLine("3. Buscar Producto por Nombre");
            Console.WriteLine("4. Actualizar Producto");
            Console.WriteLine("5. Eliminar Producto");
            Console.WriteLine("0. Salir");
            Console.Write("Selecciona una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1": CrearProducto(); break;
                case "2": ListarProductos(); break;
                case "3": BuscarProducto(); break;
                case "4": ActualizarProducto(); break;
                case "5": EliminarProducto(); break;
                case "0": return;
                default: Console.WriteLine("Opción no válida."); break;
            }
        }
    }

    static void CrearBaseDeDatosSiNoExiste()
    {
        if (!File.Exists(dbFile))
        {
            SQLiteConnection.CreateFile(dbFile);
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "CREATE TABLE productos (Nombre TEXT PRIMARY KEY, Precio REAL, Cantidad INTEGER)";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }

    static void CrearProducto()
    {
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();
        Console.Write("Precio: ");
        double precio = Convert.ToDouble(Console.ReadLine());
        Console.Write("Cantidad: ");
        int cantidad = Convert.ToInt32(Console.ReadLine());

        using (var conn = new SQLiteConnection(connectionString))
        {
            conn.Open();
            string query = "INSERT INTO productos (Nombre, Precio, Cantidad) VALUES (@nombre, @precio, @cantidad)";
            using (var cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@precio", precio);
                cmd.Parameters.AddWithValue("@cantidad", cantidad);
                cmd.ExecuteNonQuery();
            }
        }

        Console.WriteLine("Producto creado correctamente.");
    }

    static void ListarProductos()
    {
        using (var conn = new SQLiteConnection(connectionString))
        {
            conn.Open();
            string query = "SELECT * FROM productos";
            using (var cmd = new SQLiteCommand(query, conn))
            using (var reader = cmd.ExecuteReader())
            {
                Console.WriteLine("\n--- LISTA DE PRODUCTOS ---");
                while (reader.Read())
                {
                    Console.WriteLine($"Nombre: {reader["Nombre"]}, Precio: {reader["Precio"]}, Cantidad: {reader["Cantidad"]}");
                }
            }
        }
    }

    static void BuscarProducto()
    {
        Console.Write("Introduce el nombre del producto: ");
        string nombre = Console.ReadLine();

        using (var conn = new SQLiteConnection(connectionString))
        {
            conn.Open();
            string query = "SELECT * FROM productos WHERE Nombre = @nombre";
            using (var cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@nombre", nombre);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Console.WriteLine($"Nombre: {reader["Nombre"]}, Precio: {reader["Precio"]}, Cantidad: {reader["Cantidad"]}");
                    }
                    else
                    {
                        Console.WriteLine("Producto no encontrado.");
                    }
                }
            }
        }
    }

    static void ActualizarProducto()
    {
        Console.Write("Introduce el nombre del producto a actualizar: ");
        string nombre = Console.ReadLine();

        Console.Write("Nuevo precio: ");
        double precio = Convert.ToDouble(Console.ReadLine());
        Console.Write("Nueva cantidad: ");
        int cantidad = Convert.ToInt32(Console.ReadLine());

        using (var conn = new SQLiteConnection(connectionString))
        {
            conn.Open();
            string query = "UPDATE productos SET Precio = @precio, Cantidad = @cantidad WHERE Nombre = @nombre";
            using (var cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@precio", precio);
                cmd.Parameters.AddWithValue("@cantidad", cantidad);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                int filas = cmd.ExecuteNonQuery();
                if (filas > 0)
                    Console.WriteLine("Producto actualizado.");
                else
                    Console.WriteLine("Producto no encontrado.");
            }
        }
    }

    static void EliminarProducto()
    {
        Console.Write("Introduce el nombre del producto a eliminar: ");
        string nombre = Console.ReadLine();

        using (var conn = new SQLiteConnection(connectionString))
        {
            conn.Open();
            string query = "DELETE FROM productos WHERE Nombre = @nombre";
            using (var cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@nombre", nombre);
                int filas = cmd.ExecuteNonQuery();
                if (filas > 0)
                    Console.WriteLine("Producto eliminado.");
                else
                    Console.WriteLine("Producto no encontrado.");
            }
        }
    }
}
