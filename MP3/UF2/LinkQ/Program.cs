using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsultasLINQ
{
        public class Persona
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }

        public Persona(string nombre, int edad)
        {
            Nombre = nombre;
            Edad = edad;
        }

        public override string ToString()
        {
            return $"{Nombre}, {Edad}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CONSULTAS SIN EXPRESIONES");

            List<Persona> personas = new List<Persona>
            {
                new Persona("Juan", 30),
                new Persona("Pedro", 31),
                new Persona("Miguel", 25),
                new Persona("Luís", 36),
                new Persona("José", 25)
            };

            // Encuentra el nombre de la persona más joven.
            var nombreMasJoven = (from p in personas
                                  orderby p.Edad ascending
                                  select p.Nombre).First();
            Console.WriteLine("La persona más joven es: " + nombreMasJoven);

            // Calcula la edad promedio de todas las personas.
            var edadPromedio = (from p in personas
                                select p.Edad).Average();
            Console.WriteLine("La edad promedio es: " + edadPromedio);

            // Encuentra todas las personas mayores de 25 años y ordénalas alfabéticamente por nombre.
            var mayores25 = from p in personas
                            where p.Edad > 25
                            orderby p.Nombre ascending
                            select p;
            Console.WriteLine("Personas mayores de 25 años ordenadas alfabéticamente:");
            foreach (var p in mayores25)
            {
                Console.WriteLine(p);
            }

            // Encuentra todas las personas cuyo nombre comienza con "M" y ordénalas por edad descendente.
            var nombresM = from p in personas
                           where p.Nombre.StartsWith("M")
                           orderby p.Edad descending
                           select p;
            Console.WriteLine("Personas cuyo nombre comienza con 'M' ordenadas por edad descendente:");
            foreach (var p in nombresM)
            {
                Console.WriteLine(p);
            }

            // Verifica si todas las personas son mayores de 18 años.
            bool todosMayores18 = (from p in personas
                                   where p.Edad <= 18
                                   select p).Count() == 0;
            Console.WriteLine("¿Todas las personas son mayores de 18? " + (todosMayores18 ? "Sí" : "No"));

            // Encuentra la persona más joven que tenga un nombre que contenga la letra "a".
            var jovenConA = (from p in personas
                             where p.Nombre.ToLower().Contains("a")
                             orderby p.Edad ascending
                             select p).First();
            Console.WriteLine("La persona más joven cuyo nombre contiene 'a' es: " + jovenConA);

            // Agrupa las personas por la primera letra de su nombre y muestra la cantidad en cada grupo.
            var grupoPorInicial = from p in personas
                                  group p by p.Nombre[0] into grupo
                                  select new { Letra = grupo.Key, Cantidad = grupo.Count() };
            Console.WriteLine("Agrupación de personas por la primera letra:");
            foreach (var grupo in grupoPorInicial)
            {
                Console.WriteLine($"Letra {grupo.Letra}: {grupo.Cantidad}");
            }


            Console.WriteLine("\nCONSULTAS  LAMBDA");
            List<Persona> personasLambda = new List<Persona>
            {
                new Persona("Juan", 30),
                new Persona("Pedro", 31),
                new Persona("Miguel", 25),
                new Persona("Luís", 36),
                new Persona("José", 25)
            };

            // Encuentra el nombre de la persona más joven que tenga una edad impar.
            var nombreJovenImpar = personasLambda
                .Where(p => p.Edad % 2 != 0)
                .OrderBy(p => p.Edad)
                .Select(p => p.Nombre)
                .First();
            Console.WriteLine("La persona más joven con edad impar es: " + nombreJovenImpar);

            // Elimina a todas las personas cuyas edades sean múltiplos de 5 y muestra la lista resultante.
            personasLambda.RemoveAll(p => p.Edad % 5 == 0);
            Console.WriteLine("Lista tras eliminar personas con edades múltiplos de 5:");
            foreach (var p in personasLambda)
            {
                Console.WriteLine(p);
            }

            // Calcula la diferencia de edad entre la persona más joven y la persona más vieja en la lista resultante.
            var edadMin = personasLambda.Min(p => p.Edad);
            var edadMax = personasLambda.Max(p => p.Edad);
            var diferencia = edadMax - edadMin;
            Console.WriteLine("La diferencia de edad entre la persona más joven y la más vieja es: " + diferencia);
        }
    }
}
