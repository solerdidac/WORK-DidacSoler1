using System;

namespace SistemaNavesEstelares
{
    class Program
    {
        static void Main(string[] args)
        {
            Nave naveBase = new Nave("Nave Basica", "Modelo Default");
            naveBase.ActivarSistemas();
            naveBase.EjecutarMision();
            naveBase.ApagarSistemas();
            Console.WriteLine();

            
            NaveCombate naveCombate = new NaveCombate("Nave de Combate", "Modelo Default", 7);
            naveCombate.ActivarSistemas();
            naveCombate.RealizarAtaque();
            naveCombate.ApagarSistemas();
            Console.WriteLine();

            
            NaveCargaEspecializada naveCarga = new NaveCargaEspecializada("Nave de Carga Especializada", "Modelo Default", 10, 2500);
            naveCarga.ActivarSistemas();
            naveCarga.RealizarAtaque();
            naveCarga.EjecutarMision();
            naveCarga.Cargar();
            naveCarga.MostrarKilometros();
            naveCarga.ApagarSistemas();
        }
    }
}
