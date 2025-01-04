using AC2.Models;

public class Empleado : Persona
{
    public string Categoria { get; set; }
    public double Salario { get; set; }

    public Empleado(string nombre, int edad, string categoria, double salario)
        : base(nombre, edad)
    {
        Categoria = categoria;
        Salario = salario;
    }

    public override string ToString()
    {
        return base.ToString() + $", Categoria: {Categoria}, Salario: {Salario}";
    }
}
