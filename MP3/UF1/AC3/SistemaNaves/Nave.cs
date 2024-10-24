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
            Console.WriteLine($"La nave estelar {Nombre} ha activado sus sistemas.");
        }

        public virtual void EjecutarMision()
        {
            Console.WriteLine($"La nave estelar {Nombre} está realizando una misión de exploración.");
        }

        public virtual void ApagarSistemas()
        {
            Console.WriteLine($"La nave estelar {Nombre} ha apagado sus sistemas.");
        }
    }
}
