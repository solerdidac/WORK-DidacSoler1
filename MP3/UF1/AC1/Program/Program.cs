using System;
using System.Collections.Generic;

public class Empleado
{
    public string NombreEmpleado { get; set; }
    public string Cargo { get; set; }
    public double Salario { get; set; }

    public Empleado(string nombreEmpleado, string cargo, double salario)
    {
        NombreEmpleado = nombreEmpleado;
        Cargo = cargo;
        Salario = salario;
    }
}

public class Cliente
{
    public double Cobro { get; set; }
    public double Adelante { get; set; }

    public Cliente(double cobro, double adelante)
    {
        Cobro = cobro;
        Adelante = adelante;
    }
}


public class Proveedor
{
    public string Nombre { get; set; }
    public string DNI { get; set; }

    public Proveedor(string nombre, string dni)
    {
        Nombre = nombre;
        DNI = dni;
    }
}

public class Tarea
{
    public string Estado { get; set; }
    public string Descripcion { get; set; }
    public string Nombre { get; set; }
    public string EstadoFinalizado { get; set; }

    public Tarea(string estado, string descripcion, string nombre, string estadoFinalizado)
    {
        Estado = estado;
        Descripcion = descripcion;
        Nombre = nombre;
        EstadoFinalizado = estadoFinalizado;
    }
}

public class Proyecto
{
    public string NombreProyecto { get; set; }
    public string DescripcionProyecto { get; set; }
    public int DiasRestantes { get; set; }
    public List<Empleado> ListaEmpleados { get; set; }
    public double CostoEstimado { get; set; }
    public List<Tarea> Tareas { get; set; }

    public Proyecto(string nombreProyecto, string descripcionProyecto, int diasRestantes, double costoEstimado)
    {
        NombreProyecto = nombreProyecto;
        DescripcionProyecto = descripcionProyecto;
        DiasRestantes = diasRestantes;
        CostoEstimado = costoEstimado;
        ListaEmpleados = new List<Empleado>();
        Tareas = new List<Tarea>();
    }

    public int CalcularTiempoRestante()
    {
        return DiasRestantes;
    }

    public double CalcularCostoActual()
    {
        double costoActual = 0;
        foreach (var empleado in ListaEmpleados)
        {
            costoActual += empleado.Salario;
        }
        return costoActual;
    }
}
public class Program
{
    public static void Main()
    {
        // Afeguim els empleats
        Empleado empleado1 = new Empleado("Didac Soler", "Estudiante", 3000);
        Empleado empleado2 = new Empleado("Jaime LLorente", "Analista", 3500);

        // Inventem els clients
        Cliente cliente = new Cliente(50000, 10000);

        // Inventem els proveedor
        Proveedor proveedor = new Proveedor("Proveedor de Latas", "54683213E");

        // Afeguim les tasques
        Tarea tarea1 = new Tarea("Progreso", "Desarrollar X", "Tarea 1", "No");
        Tarea tarea2 = new Tarea("Pendiente", "Revisar documentación", "Tarea 2", "No");

        // Afeguim projectes
        Proyecto proyecto = new Proyecto("Proyecto A", "Descripción del Proyecto", 30, 60000);
        proyecto.ListaEmpleados.Add(empleado1);
        proyecto.ListaEmpleados.Add(empleado2);
        proyecto.Tareas.Add(tarea1);
        proyecto.Tareas.Add(tarea2);

        // Calculem el temp restant
        Console.WriteLine($"Tiempo restante es de : {proyecto.CalcularTiempoRestante()} dias");
        Console.WriteLine($"Costo actual es de: {proyecto.CalcularCostoActual()}");

        // Ensenyem per consola els pagaments
        Console.WriteLine($"Cliente ha pagado: {cliente.Cobro} y el adelanto: {cliente.Adelante}");
    }
}

