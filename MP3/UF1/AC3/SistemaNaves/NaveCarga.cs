// NaveCargaEspecializada.cs
using System;

namespace SistemaNavesEstelares
{
    public class NaveCargaEspecializada : NaveCombate
    {
        public int CapacidadCarga { get; set; }
        private int Kilometros;

        public NaveCargaEspecializada(string nombre, string modelo, int potenciaAtaque, int capacidadCarga)
            : base(nombre, modelo, potenciaAtaque)
        {
            CapacidadCarga = capacidadCarga;
            Random random = new Random();
            Kilometros = random.Next(500, 1001);
        }

        public override void EjecutarMision()
        {
            Console.WriteLine($"La nave de carga especializada {Nombre} está defendiendo el espacio alrededor del planeta X.");
        }

        public void MostrarKilometros()
        {
            Console.WriteLine($"La nave ha recorrido {Kilometros} kilómetros.");
        }

        public void Cargar()
        {
            Console.WriteLine($"La nave de carga {Nombre} lleva una cantidad de carga de {CapacidadCarga} Kg.");
        }

        public override void ActivarSistemas()
        {
            Console.WriteLine($"La nave de carga especializada {Nombre} ha activado sus sistemas.");
        }
    }
}
