namespace AC2.Services
{
    using AC2.Models;
    using System;
    using System.Linq;

    public class SistemaAlquiler
    {
        public LinkedList<Persona> Usuarios { get; set; }
        public LinkedList<Empleado> Empleados { get; set; }
        public LinkedList<VideoJuego> Videojuegos { get; set; }

        public SistemaAlquiler()
        {
            Usuarios = new LinkedList<Persona>();
            Empleados = new LinkedList<Empleado>();
            Videojuegos = new LinkedList<VideoJuego>();
        }

        // Alta y baja de usuarios
        public void AltaUsuario(Persona usuario) => Usuarios.AddLast(usuario);
        public void BajaUsuario(Persona usuario) => Usuarios.Remove(usuario);

        // Alta y baja de empleados
        public void AltaEmpleado(Empleado empleado) => Empleados.AddLast(empleado);
        public void BajaEmpleado(Empleado empleado) => Empleados.Remove(empleado);

        // Alta y baja de videojuegos
        public void AltaVideojuego(VideoJuego videojuego) => Videojuegos.AddLast(videojuego);
        public void BajaVideojuego(VideoJuego videojuego) => Videojuegos.Remove(videojuego);

        // Listar videojuegos disponibles
        public void ListarVideojuegosDisponibles()
        {
            foreach (var juego in Videojuegos)
            {
                if (!juego.Alquilado)
                {
                    Console.WriteLine(juego);
                }
            }
        }

        // Listar videojuegos alquilados
        public void ListarVideojuegosAlquilados()
        {
            foreach (var juego in Videojuegos)
            {
                if (juego.Alquilado)
                {
                    Console.WriteLine(juego);
                }
            }
        }

        // Listar videojuegos por usuario
        public void ListarVideojuegosPorUsuario(Persona usuario)
        {
            Console.WriteLine($"Videojuegos alquilados por {usuario.Nombre}:");
            foreach (var juego in usuario.Alquilados)
            {
                Console.WriteLine(juego);
            }
        }

        // Listar usuarios con juegos prestados
        public void ListarUsuariosConJuegosPrestados()
        {
            foreach (var usuario in Usuarios)
            {
                if (usuario.Alquilados.Count > 0)
                {
                    Console.WriteLine($"{usuario.Nombre} tiene {usuario.Alquilados.Count} juegos alquilados.");
                }
            }
        }

        // Alquilar videojuego a un usuario
        public void AlquilarVideojuego(int usuarioIndex, int juegoIndex)
        {
            var usuario = Usuarios.ElementAt(usuarioIndex);
            var videojuego = Videojuegos.ElementAt(juegoIndex);

            if (!videojuego.Alquilado)
            {
                videojuego.Alquilado = true;
                usuario.Alquilados.AddLast(videojuego);
                Console.WriteLine($"{usuario.Nombre} ha alquilado {videojuego.Titulo}");
            }
            else
            {
                Console.WriteLine($"El videojuego {videojuego.Titulo} ya está alquilado.");
            }
        }

        // Devolver videojuego
        public void DevolverVideojuego(int usuarioIndex, int juegoIndex)
        {
            var usuario = Usuarios.ElementAt(usuarioIndex);
            var videojuego = usuario.Alquilados.ElementAt(juegoIndex);

            videojuego.Alquilado = false;
            usuario.Alquilados.Remove(videojuego);
            Console.WriteLine($"{usuario.Nombre} ha devuelto el videojuego {videojuego.Titulo}");
        }
    }
}
