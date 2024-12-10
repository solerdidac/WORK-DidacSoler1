using System;

namespace SistemaNavesEstelares
{
    public class Nave
    {
        public string Nombre { get; set; }
        public string Modelo { get; set; }

        public Nave(string nombre, string modelo)
        {
            Nombre = nombre;
            Modelo = modelo;
        }

        public virtual void ActivarSistemas()
        {
            Console.WriteLine($"La {Nombre} ha activado sus sistemas.");
        }

        public virtual void EjecutarMision()
        {
            Console.WriteLine($"La {Nombre} está realizando una mision de exploracion.");
        }

        public virtual void ApagarSistemas()
        {
            Console.WriteLine($"La {Nombre} ha apagado sus sistemas.");
        }
    }
}
