using System;

public class Program
{
    public static void Main(string[] args)
    {
        
        Console.WriteLine("Aventuras del Soler");

        Console.WriteLine("Escoge tu Atacante: 1 Guerrero 2 Mago 3 Arquero");
        int eleccion;
        while (!int.TryParse(Console.ReadLine(), out eleccion) || eleccion < 1 || eleccion > 3)
        {
            Console.WriteLine("Por favor, (1, 2 o 3).");
        }

        Personaje jugador = eleccion switch
        {
            1 => new Guerrero(),
            2 => new Mago(),
            3 => new Arquero(),
            _ => throw new Exception("Selección no válida.")
        };

        Mazmorras mazmorras = new Mazmorras();
        mazmorras.Iniciar(jugador);
    }
}

// Clase Personaje
public class Personaje
{
    public string Nombre { get; set; }
    public int Salud { get; set; }
    public int Ataque { get; set; }
    public int UsosHabilidad { get; private set; } = 2;
    public bool EstaVivo => Salud > 0;

    public void BuscarRecursos()
    {
        Random random = new Random();
        int resultado = random.Next(0, 100);
        if (resultado < 50)
        {
            Console.WriteLine("Recuperas 5 puntos de salud.");
            Salud += 5;
        }
        else
        {
            Console.WriteLine("La proxima será...");
        }
    }

    public Personaje(string nombre, int salud, int ataque)
    {
        Nombre = nombre;
        Salud = salud;
        Ataque = ataque;
    }

    public void RecibirDanio(int cantidad)
    {
        Salud -= cantidad;
        if (Salud < 0) Salud = 0;
        Console.WriteLine($"{Nombre} recibe {cantidad} puntos de daño. Salud actual: {Salud}");
    }

    public void Atacar(Enemigo enemigo)
    {
        Console.WriteLine($"{Nombre} ataca a {enemigo.Nombre} causando {Ataque} de daño.");
        enemigo.RecibirDanio(Ataque);
    }

    public void UsarHabilidad()
    {
        if (UsosHabilidad > 0)
        {
            Console.WriteLine($"{Nombre} usa su habilidad especial.");
            UsosHabilidad--;
            ActivarHabilidad();
        }
        else
        {
            Console.WriteLine("No tienes mas habilidades especiales.");
        }
    }

    protected virtual void ActivarHabilidad()
    {
        Console.WriteLine($"{Nombre} no tiene una habilidad especial.");
    }
}

public class Guerrero : Personaje
{
    public Guerrero() : base("Guerrero", 12, 3) { }

    protected override void ActivarHabilidad()
    {
        Console.WriteLine("El Guerrero mejora su ataque basico.");
        AtaqueCuerpoACuerpo();
        Ataque += 1;
    }

    private void AtaqueCuerpoACuerpo()
    {
        
        Console.WriteLine("Provocara 4 puntos de daño.");
    }
}


public class Mago : Personaje
{
    public Mago() : base("Mago", 8, 4) { }

    protected override void ActivarHabilidad()
    {
        Console.WriteLine("Recupera 2 puntos de salud.");
        Salud += 2;
    }
}


public class Arquero : Personaje
{
    public Arquero() : base("Arquero", 10, 3) { }

    protected override void ActivarHabilidad()
    {
        Console.WriteLine("Realiza un doble ataque.");
        Ataque *= 2;
    }
}


public class Enemigo
{
    public string Nombre { get; set; }
    public int Salud { get; set; }
    public int Ataque { get; set; }
    public bool EstaVivo => Salud > 0;

    public Enemigo(string nombre, int salud, int ataque)
    {
        Nombre = nombre;
        Salud = salud;
        Ataque = ataque;
    }

    public void RecibirDanio(int cantidad)
    {
        Salud -= cantidad;
        if (Salud < 0) Salud = 0;
        Console.WriteLine($"{Nombre} recibe {cantidad} puntos de daño. Salud actual: {Salud}");
    }

    public void Atacar(Personaje personaje)
    {
        Console.WriteLine($"{Nombre} ataca a {personaje.Nombre} causando {Ataque} de daño.");
        personaje.RecibirDanio(Ataque);
    }
}

public class EnemigoBasico : Enemigo
{
    public EnemigoBasico() : base("Enemigo Básico", 10, 2) { }
}

public class Boss : Enemigo
{
    public Boss() : base("Boss", 20, 5) { }

    public void AtacarDoble(Personaje personaje)
    {
        Console.WriteLine("¡El Boss realiza un ataque doble!");
        base.Atacar(personaje);
        base.Atacar(personaje);
    }
}

public class Mazmorras
{
    public void Iniciar(Personaje jugador)
    {
        Console.WriteLine($"Bienvenido {jugador.Nombre} a las aventuras.");
        Random random = new Random();

        Enemigo enemigo = random.Next(0, 10) > 7 ? new Boss() : new EnemigoBasico();
        Console.WriteLine($"Te enfrentas a un {enemigo.Nombre}.");

        while (jugador.EstaVivo && enemigo.EstaVivo)
        {
            Console.WriteLine("\n¿Qué quieres hacer?");
            Console.WriteLine("1. Atacar");
            Console.WriteLine("2. Usar habilidad especial");
            Console.WriteLine("3. Buscar Recurso");
            string? opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    jugador.Atacar(enemigo);
                    break;
                case "2":
                    jugador.UsarHabilidad();
                    break;
                case "3":
                    Console.WriteLine($"{jugador.Nombre} busca recursos.");
                    jugador.BuscarRecursos();
                    break;
                default:
                    Console.WriteLine("No valido.");
                    continue;
            }

            if (!enemigo.EstaVivo)
            {
                Console.WriteLine($"{enemigo.Nombre} ha sido derrotado!");
                break;
            }

            Console.WriteLine("\nTurno del enemigo.");
            enemigo.Atacar(jugador);

            if (!jugador.EstaVivo)
            {
                Console.WriteLine($"{jugador.Nombre} ha sido derrotado!");
                break;
            }
        }

        Console.WriteLine("La aventura ha terminado.");
    }
}
