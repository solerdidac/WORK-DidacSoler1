using System;
using System.Collections.Generic;

abstract class Droide
{
    public string Nombre { get; set; }
    public string TipoUnidad { get; set; }
    public int NivelBateria { get; set; }

    public Droide(string nombre, string tipoUnidad, int nivelBateria)
    {
        Nombre = nombre;
        TipoUnidad = tipoUnidad;
        NivelBateria = nivelBateria;
    }

    public virtual void MostrarInfo()
    {
        Console.WriteLine($"Nombre: {Nombre}, Tipo: {TipoUnidad}, Bateria: {NivelBateria}%");
    }

    public virtual int RepararNaves()
    {
        return 0;
    }

    public virtual int CombatesParticipados()
    {
        return 0;
    }
}

class DroideProtocolo : Droide
{
    public DroideProtocolo(string nombre, int nivelBateria)
        : base(nombre, "Protocolo", nivelBateria) {}

    public override void MostrarInfo()
    {
        base.MostrarInfo();
        Console.WriteLine("Función principal: Protocolo de interacción.");
    }
}

class DroideAstromecanico : Droide
{
    public DateTime UltimaReparacion { get; set; }

    public DroideAstromecanico(string nombre, int nivelBateria, DateTime ultimaReparacion)
        : base(nombre, "Astromecanico", nivelBateria)
    {
        UltimaReparacion = ultimaReparacion;
    }

    public override void MostrarInfo()
    {
        base.MostrarInfo();
        Console.WriteLine($"Ultima reparación: {UltimaReparacion.ToShortDateString()}");
    }

    public override int RepararNaves()
    {
        Random random = new Random();
        return random.Next(1, 25);
    }
}

class DroideCombate : Droide
{
    public int NivelPotenciaFuego { get; set; }

    public DroideCombate(string nombre, int nivelBateria, int nivelPotenciaFuego)
        : base(nombre, "Combate", nivelBateria)
    {
        NivelPotenciaFuego = nivelPotenciaFuego;
    }

    public override void MostrarInfo()
    {
        base.MostrarInfo();
        Console.WriteLine($"Potencia de Fuego: {NivelPotenciaFuego}");
    }

    public override int CombatesParticipados()
    {
        Random random = new Random();
        return random.Next(1, 50);
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Droide> droides = new List<Droide>();

        int opcion = 0;
        do
        {
            Console.WriteLine("\nGestión de droides");
            Console.WriteLine("1. Añadir droide");
            Console.WriteLine("2. Mostrar droides");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opción: ");
            
            opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.WriteLine("Tipos: 1. Protocolo, 2. Astromecanico, 3. Combate");
                    Console.Write("Tipo de droide: ");
                    int tipo = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Nombre del droide: ");
                    string nombre = Console.ReadLine();

                    Console.Write("Nivel de bateria : ");
                    int nivelBateria = Convert.ToInt32(Console.ReadLine());

                    switch (tipo)
                    {
                        case 1:
                            droides.Add(new DroideProtocolo(nombre, nivelBateria));
                            break;
                        case 2:
                            Console.Write("Fecha reparación (YYYY-MM-DD): ");
                            DateTime ultimaReparacion = Convert.ToDateTime(Console.ReadLine());
                            droides.Add(new DroideAstromecanico(nombre, nivelBateria, ultimaReparacion));
                            break;
                        case 3:
                            Console.Write("Potencia de fuego: ");
                            int nivelPotenciaFuego = Convert.ToInt32(Console.ReadLine());
                            droides.Add(new DroideCombate(nombre, nivelBateria, nivelPotenciaFuego));
                            break;
                        default:
                            Console.WriteLine("Tipo no valido.");
                            break;
                    }
                    break;
                case 2:
                    if (droides.Count == 0)
                    {
                        Console.WriteLine("Aun no hay droides.");
                    }
                    else
                    {
                        foreach (var droide in droides)
                        {
                            droide.MostrarInfo();
                            if (droide is DroideAstromecanico)
                            {
                                Console.WriteLine($"Reparaciones: {droide.RepararNaves()}");
                            }
                            if (droide is DroideCombate)
                            {
                                Console.WriteLine($"Combates hechos: {droide.CombatesParticipados()}");
                            }
                            Console.WriteLine("**-----------------------**");
                        }
                    }
                    break;
                case 3:
                    Console.WriteLine("Adeu");
                    break;
                default:
                    Console.WriteLine("No valido.");
                    break;
            }

        } while (opcion != 3);
    }
}
