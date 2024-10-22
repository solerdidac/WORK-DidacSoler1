// Program.cs
using System;

namespace SistemaNavesEstelares
{
    class Program
    {
        static void Main(string[] args)
        {
            Nave naveBasica = new Nave("Nave Basica", "Modelo A1");
            naveBasica.ActivarSistemas();
            naveBasica.EjecutarMision();
            naveBasica.ApagarSistemas();
            Console.WriteLine();

            // Nave de Combate
            NaveCombate naveCombate = new NaveCombate("Nave de Combate", "Modelo B2", 7);
            naveCombate.ActivarSistemas();
            naveCombate.RealizarAtaque();
            naveCombate.ApagarSistemas();
            Console.WriteLine();

            // Nave de Combate Especializada con Capacidad de Carga
            NaveCargaEspecializada naveCarga = new NaveCargaEspecializada("Nave de Carga Especializada", "Modelo C3", 10, 2500);
            naveCarga.ActivarSistemas();
            naveCarga.RealizarAtaque();
            naveCarga.EjecutarMision();
            naveCarga.Cargar();
            naveCarga.MostrarKilometros();
            naveCarga.ApagarSistemas();
        }
    }
}
