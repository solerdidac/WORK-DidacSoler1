using AC2.Models;
using AC2.Services;

class Program
{
    static void Main(string[] args)
    {
        var sistema = new SistemaAlquiler();

        // Datos predeterminados
        sistema.AltaUsuario(new Persona("Didac", 19));
        sistema.AltaUsuario(new Persona("Sergi", 25));
        sistema.AltaUsuario(new Persona("Joan", 28));

        sistema.AltaEmpleado(new Empleado("Laura", 30, "Gerente", 2500));
        sistema.AltaEmpleado(new Empleado("Carlos", 35, "Técnico", 1800));

        sistema.AltaVideojuego(new VideoJuego("Fortnite", 2015, "RPG"));
        sistema.AltaVideojuego(new VideoJuego("FIFA 23", 2023, "Deportes"));
        sistema.AltaVideojuego(new VideoJuego("Minecraft", 2011, "Sandbox"));

        int opcion;
        do
        {
            Console.WriteLine("\n--- Menu Principal ---");
            Console.WriteLine("1. Alta Usuario");
            Console.WriteLine("2. Baja Usuario");
            Console.WriteLine("3. Alta Empleado");
            Console.WriteLine("4. Baja Empleado");
            Console.WriteLine("5. Alta Videojuego");
            Console.WriteLine("6. Baja Videojuego");
            Console.WriteLine("7. Listar Videojuegos Disponibles");
            Console.WriteLine("8. Listar Videojuegos Alquilados");
            Console.WriteLine("9. Alquilar Videojuego");
            Console.WriteLine("10. Devolver Videojuego");
            Console.WriteLine("11. Listar Usuarios con Juegos Prestados");
            Console.WriteLine("12. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = int.Parse(Console.ReadLine()!);

            switch (opcion)
            {
                case 1:
                    CrearUsuario(sistema);
                    break;
                case 2:
                    BajaUsuario(sistema);
                    break;
                case 3:
                    CrearEmpleado(sistema);
                    break;
                case 4:
                    BajaEmpleado(sistema);
                    break;
                case 5:
                    AltaVideojuego(sistema);
                    break;
                case 6:
                    BajaVideojuego(sistema);
                    break;
                case 7:
                    sistema.ListarVideojuegosDisponibles();
                    break;
                case 8:
                    sistema.ListarVideojuegosAlquilados();
                    break;
                case 9:
                    AlquilarVideojuego(sistema);
                    break;
                case 10:
                    DevolverVideojuego(sistema);
                    break;
                case 11:
                    sistema.ListarUsuariosConJuegosPrestados();
                    break;
                case 12:
                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    Console.WriteLine("Opcion no valida.");
                    break;
            }
        } while (opcion != 12);
    }

    static void CrearUsuario(SistemaAlquiler sistema)
    {
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine()!;
        Console.Write("Edad: ");
        int edad = int.Parse(Console.ReadLine()!);

        sistema.AltaUsuario(new Persona(nombre, edad));
        Console.WriteLine("Usuario creado con exito.");
    }

    static void BajaUsuario(SistemaAlquiler sistema)
    {
        int index = 1;
        foreach (var usuario in sistema.Usuarios)
        {
            Console.WriteLine($"[{index++}] {usuario.Nombre}");
        }

        Console.Write("Seleccione el numero del usuario: ");
        int usuarioIndex = int.Parse(Console.ReadLine()!) - 1;

        if (usuarioIndex >= 0 && usuarioIndex < sistema.Usuarios.Count)
        {
            sistema.BajaUsuario(sistema.Usuarios.ElementAt(usuarioIndex));
            Console.WriteLine("Usuario dado de baja.");
        }
        else
        {
            Console.WriteLine("Usuario no valido.");
        }
    }

    static void CrearEmpleado(SistemaAlquiler sistema)
    {
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine()!;
        Console.Write("Edad: ");
        int edad = int.Parse(Console.ReadLine()!);
        Console.Write("Categoría: ");
        string categoria = Console.ReadLine()!;
        Console.Write("Salario: ");
        double salario = double.Parse(Console.ReadLine()!);

        sistema.AltaEmpleado(new Empleado(nombre, edad, categoria, salario));
        Console.WriteLine("Empleado creado con exito.");
    }

    static void BajaEmpleado(SistemaAlquiler sistema)
    {
        int index = 1;
        foreach (var empleado in sistema.Empleados)
        {
            Console.WriteLine($"[{index++}] {empleado.Nombre}");
        }

        Console.Write("Seleccione el numero del empleado: ");
        int empleadoIndex = int.Parse(Console.ReadLine()!) - 1;

        if (empleadoIndex >= 0 && empleadoIndex < sistema.Empleados.Count)
        {
            sistema.BajaEmpleado(sistema.Empleados.ElementAt(empleadoIndex));
            Console.WriteLine("Empleado dado de baja.");
        }
        else
        {
            Console.WriteLine("Empleado no valido.");
        }
    }

    static void AltaVideojuego(SistemaAlquiler sistema)
    {
        Console.Write("Título: ");
        string titulo = Console.ReadLine()!;
        Console.Write("Año: ");
        int anio = int.Parse(Console.ReadLine()!);
        Console.Write("Tematica: ");
        string tematica = Console.ReadLine()!;

        sistema.AltaVideojuego(new VideoJuego(titulo, anio, tematica));
        Console.WriteLine("Videojuego añadido.");
    }

    static void BajaVideojuego(SistemaAlquiler sistema)
    {
        int index = 1;
        foreach (var videojuego in sistema.Videojuegos)
        {
            Console.WriteLine($"[{index++}] {videojuego.Titulo}");
        }

        Console.Write("Seleccione el numero del videojuego: ");
        int juegoIndex = int.Parse(Console.ReadLine()!) - 1;

        if (juegoIndex >= 0 && juegoIndex < sistema.Videojuegos.Count)
        {
            sistema.BajaVideojuego(sistema.Videojuegos.ElementAt(juegoIndex));
            Console.WriteLine("Videojuego eliminado.");
        }
        else
        {
            Console.WriteLine("Videojuego no valido.");
        }
    }

    static void AlquilarVideojuego(SistemaAlquiler sistema)
    {
        int usuarioIndex = 1;
        foreach (var usuario in sistema.Usuarios)
        {
            Console.WriteLine($"[{usuarioIndex++}] {usuario.Nombre}");
        }

        Console.Write("Seleccione el numero del usuario: ");
        int usuarioSeleccionado = int.Parse(Console.ReadLine()!) - 1;

        if (usuarioSeleccionado >= 0 && usuarioSeleccionado < sistema.Usuarios.Count)
        {
            int juegoIndex = 1;
            foreach (var juego in sistema.Videojuegos)
            {
                if (!juego.Alquilado)
                {
                    Console.WriteLine($"[{juegoIndex++}] {juego.Titulo}");
                }
            }

            Console.Write("Seleccione el numero del videojuego: ");
            int videojuegoSeleccionado = int.Parse(Console.ReadLine()!) - 1;

            if (videojuegoSeleccionado >= 0 && videojuegoSeleccionado < sistema.Videojuegos.Count && !sistema.Videojuegos.ElementAt(videojuegoSeleccionado).Alquilado)
            {
                sistema.AlquilarVideojuego(usuarioSeleccionado, videojuegoSeleccionado);
            }
            else
            {
                Console.WriteLine("Videojuego no valido o ya alquilado.");
            }
        }
        else
        {
            Console.WriteLine("Usuario no valido.");
        }
    }

    static void DevolverVideojuego(SistemaAlquiler sistema)
    {
        int usuarioIndex = 1;
        foreach (var usuario in sistema.Usuarios)
        {
            Console.WriteLine($"[{usuarioIndex++}] {usuario.Nombre}");
        }

        Console.Write("Seleccione el numero del usuario: ");
        int usuarioSeleccionado = int.Parse(Console.ReadLine()!) - 1;

        if (usuarioSeleccionado >= 0 && usuarioSeleccionado < sistema.Usuarios.Count)
        {
            var usuario = sistema.Usuarios.ElementAt(usuarioSeleccionado);

            int juegoIndex = 1;
            foreach (var juego in usuario.Alquilados)
            {
                Console.WriteLine($"[{juegoIndex++}] {juego.Titulo}");
            }

            Console.Write("Seleccione el numero del videojuego: ");
            int videojuegoSeleccionado = int.Parse(Console.ReadLine()!) - 1;

            if (videojuegoSeleccionado >= 0 && videojuegoSeleccionado < usuario.Alquilados.Count)
            {
                sistema.DevolverVideojuego(usuarioSeleccionado, videojuegoSeleccionado);
            }
            else
            {
                Console.WriteLine("Videojuego no valido.");
            }
        }
        else
        {
            Console.WriteLine("Usuario no valido.");
        }
    }
}
