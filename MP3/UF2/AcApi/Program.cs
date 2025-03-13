using System;
using System.Collections.Generic;
using System.Linq;

namespace CrudApiSimple
{
    public class Api<T>
    {
        private List<T> elementos;

        public Api()
        {
            elementos = new List<T>();
        }

        public void AgregarElemento(T elemento) => elementos.Add(elemento);

        public void ActualizarElemento(int indice, T elemento)
        {
            if (indice >= 0 && indice < elementos.Count)
                elementos[indice] = elemento;
            else
                Console.WriteLine("Indice fuera de rango");
        }

        public List<T> BuscarElementos(Func<T, bool> criterio) => elementos.Where(criterio).ToList();

        public void ListarElementos()
        {
            if (elementos.Count == 0)
                Console.WriteLine("No hay elementos para mostrar.");
            else
            {
                for (int i = 0; i < elementos.Count; i++)
                    Console.WriteLine($"[{i}] {elementos[i]}");
            }
        }
        public List<T> ObtenerElementos() => elementos;
    }

    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public Producto(int id, string nombre, double precio) { Id = id; Nombre = nombre; Precio = precio; }
        public override string ToString() => $"ID: {Id}, Nombre: {Nombre}, Precio: {Precio}";
    }

    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public Cliente(int id, string nombre, string email) { Id = id; Nombre = nombre; Email = email; }
        public override string ToString() => $"ID: {Id}, Nombre: {Nombre}, Email: {Email}";
    }

    public class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Cargo { get; set; }
        public Empleado(int id, string nombre, string cargo) { Id = id; Nombre = nombre; Cargo = cargo; }
        public override string ToString() => $"ID: {Id}, Nombre: {Nombre}, Cargo: {Cargo}";
    }

    class Program
    {
        static void Main(string[] args)
        {
            var apiProductos = new Api<Producto>();
            var apiClientes  = new Api<Cliente>();
            var apiEmpleados = new Api<Empleado>();

            apiProductos.AgregarElemento(new Producto(1, "Laptop", 750));
            apiProductos.AgregarElemento(new Producto(2, "Smartphone", 500));

            apiClientes.AgregarElemento(new Cliente(1, "Ana", "ana@mail.com"));
            apiClientes.AgregarElemento(new Cliente(2, "Luis", "luis@mail.com"));

            apiEmpleados.AgregarElemento(new Empleado(1, "Pedro", "Gerente"));
            apiEmpleados.AgregarElemento(new Empleado(2, "Sofía", "Desarrolladora"));

            bool salir = false;
            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("----- Tablas Api -----");
                Console.WriteLine("\nProductos:");
                apiProductos.ListarElementos();
                Console.WriteLine("\nClientes:");
                apiClientes.ListarElementos();
                Console.WriteLine("\nEmpleados:");
                apiEmpleados.ListarElementos();

                Console.WriteLine("\nSelecciona la tabla:");
                Console.WriteLine("1. Productos");
                Console.WriteLine("2. Clientes");
                Console.WriteLine("3. Empleados");
                Console.WriteLine("4. Salir");
                Console.Write("Opción: ");
                string op = Console.ReadLine();

                switch (op)
                {
                    case "1":
                        GestionarEntidad(apiProductos, "Producto");
                        break;
                    case "2":
                        GestionarEntidad(apiClientes, "Cliente");
                        break;
                    case "3":
                        GestionarEntidad(apiEmpleados, "Empleado");
                        break;
                    case "4":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción no valida. Presione cualquier tecla...");
                        break;
                }
            }
        }

        static void GestionarEntidad<T>(Api<T> api, string tipo)
        {
            bool volver = false;
            while (!volver)
            {
                Console.Clear();
                Console.WriteLine($"----- Gestión de {tipo} -----");
                Console.WriteLine("1. Listar");
                Console.WriteLine("2. Agregar");
                Console.WriteLine("3. Actualizar");
                Console.WriteLine("4. Buscar");
                Console.WriteLine("0. Volver");
                Console.Write("Opción: ");
                string op = Console.ReadLine();

                switch (op)
                {
                    case "1":
                        Console.WriteLine($"\nListado de {tipo}s:");
                        api.ListarElementos();
                        Console.WriteLine("\nPresione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case "2":
                        if (typeof(T) == typeof(Producto))
                        {
                            var list = api.ObtenerElementos() as List<Producto>;
                            int nextId = (list.Count > 0) ? list.Max(x => x.Id) + 1 : 1;
                            Console.Write("Ingrese Nombre: ");
                            string nombre = Console.ReadLine();
                            Console.Write("Ingrese Precio: ");
                            double precio = double.Parse(Console.ReadLine());
                            api.AgregarElemento((T)(object)new Producto(nextId, nombre, precio));
                        }
                        else if (typeof(T) == typeof(Cliente))
                        {
                            var list = api.ObtenerElementos() as List<Cliente>;
                            int nextId = (list.Count > 0) ? list.Max(x => x.Id) + 1 : 1;
                            Console.Write("Ingrese Nombre: ");
                            string nombre = Console.ReadLine();
                            Console.Write("Ingrese Email: ");
                            string email = Console.ReadLine();
                            api.AgregarElemento((T)(object)new Cliente(nextId, nombre, email));
                        }
                        else if (typeof(T) == typeof(Empleado))
                        {
                            var list = api.ObtenerElementos() as List<Empleado>;
                            int nextId = (list.Count > 0) ? list.Max(x => x.Id) + 1 : 1;
                            Console.Write("Ingrese Nombre: ");
                            string nombre = Console.ReadLine();
                            Console.Write("Ingrese Cargo: ");
                            string cargo = Console.ReadLine();
                            api.AgregarElemento((T)(object)new Empleado(nextId, nombre, cargo));
                        }
                        Console.WriteLine($"{tipo} agregado. Presione cualquier tecla.");
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.WriteLine($"\nTabla actual de {tipo}s:");
                        api.ListarElementos();
                        Console.Write("Ingrese el índice a actualizar: ");
                        int indice = int.Parse(Console.ReadLine());
                        if (typeof(T) == typeof(Producto))
                        {
                            Console.Write("Ingrese nuevo Nombre: ");
                            string nombre = Console.ReadLine();
                            Console.Write("Ingrese nuevo Precio: ");
                            double precio = double.Parse(Console.ReadLine());
                            var list = api.ObtenerElementos() as List<Producto>;
                            int id = list[indice].Id;
                            api.ActualizarElemento(indice, (T)(object)new Producto(id, nombre, precio));
                        }
                        else if (typeof(T) == typeof(Cliente))
                        {
                            Console.Write("Ingrese nuevo Nombre: ");
                            string nombre = Console.ReadLine();
                            Console.Write("Ingrese nuevo Email: ");
                            string email = Console.ReadLine();
                            var list = api.ObtenerElementos() as List<Cliente>;
                            int id = list[indice].Id;
                            api.ActualizarElemento(indice, (T)(object)new Cliente(id, nombre, email));
                        }
                        else if (typeof(T) == typeof(Empleado))
                        {
                            Console.Write("Ingrese nuevo Nombre: ");
                            string nombre = Console.ReadLine();
                            Console.Write("Ingrese nuevo Cargo: ");
                            string cargo = Console.ReadLine();
                            var list = api.ObtenerElementos() as List<Empleado>;
                            int id = list[indice].Id;
                            api.ActualizarElemento(indice, (T)(object)new Empleado(id, nombre, cargo));
                        }
                        Console.WriteLine($"{tipo} actualizado. Presione cualquier tecla.");
                        Console.ReadKey();
                        break;
                    case "4":
                        Console.WriteLine($"\nTabla actual de {tipo}s:");
                        api.ListarElementos();
                        Console.Write("Ingrese el término de búsqueda: ");
                        string busqueda = Console.ReadLine()!;
                        var encontrados = api.BuscarElementos(e => e.ToString().IndexOf(busqueda, StringComparison.OrdinalIgnoreCase) >= 0);
                        Console.WriteLine("\nResultados encontrados:");
                        if (encontrados.Count == 0)
                            Console.WriteLine("No se encontraron coincidencias.");
                        else
                            encontrados.ForEach(e => Console.WriteLine(e));
                        Console.WriteLine("\nPresione cualquier tecla para continuar.");
                        Console.ReadKey();
                        break;
                    case "0":
                        volver = true;
                        break;
                    default:
                        Console.WriteLine("Opción no valida. Presione cualquier tecla.");
                        break;
                }
            }
        }
    }
}
