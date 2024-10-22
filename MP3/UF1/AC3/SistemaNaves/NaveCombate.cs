// NaveCombate.cs
using System;

namespace SistemaNavesEstelares
{
    public class NaveCombate : Nave
    {
        public int PotenciaAtaque { get; set; }

        public NaveCombate(string nombre, string modelo, int potenciaAtaque)
            : base(nombre, modelo)
        {
            PotenciaAtaque = potenciaAtaque;
        }

        public override void ActivarSistemas()
        {
            Console.WriteLine($"La nave de combate {Nombre} ha activado sus sistemas de combate.");
        }

        public override void EjecutarMision()
        {
            Console.WriteLine($"La nave de combate {Nombre} está atacando con potencia de fuego nivel {PotenciaAtaque}.");
        }

        public void RealizarAtaque()
        {
            Console.WriteLine($"La nave de combate {Nombre} está realizando un ataque con potencia de {PotenciaAtaque}.");
        }
    }
}
