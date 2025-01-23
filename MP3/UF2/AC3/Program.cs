using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string texto = @"
        Los correos electrónicos son una forma común de comunicación en la era digital.
        Un correo electrónico consta de varias partes, como el remitente, el destinatario, el asunto y el cuerpo del mensaje.
        Algunos ejemplos de direcciones de correo electrónico son: usuario@gmail.com, contacto@empresa.es y teléfono 987654321 o 9876543210.
        En el ámbito de la programación, las expresiones regulares son útiles para validar y buscar patrones en direcciones de correo electrónico.
        Las expresiones regulares se pueden utilizar en muchos lenguajes de programación, incluyendo Python, JavaScript y Java.
        ";

        // Palabras que contienen la letra "e"
        Console.WriteLine("Palabras que contienen la letra 'e':");
        foreach (Match match in Regex.Matches(texto, @"\b\w*e\w*\b", RegexOptions.IgnoreCase))
        {
            Console.WriteLine(match.Value);
        }

        // Palabras que finalizan con "dad"
        Console.WriteLine("\nPalabras que finalizan con 'dad':");
        foreach (Match match in Regex.Matches(texto, @"\b\w*dad\b", RegexOptions.IgnoreCase))
        {
            Console.WriteLine(match.Value);
        }

        // Apariciones de la palabra "lenguajes"
        Console.WriteLine("\nApariciones de la palabra 'lenguajes':");
        foreach (Match match in Regex.Matches(texto, @"\blenguajes\b", RegexOptions.IgnoreCase))
        {
            Console.WriteLine(match.Value);
        }

        // Palabras que inician con "s" y finalizan con "n"
        Console.WriteLine("\nPalabras que inician con 's' y finalizan con 'n':");
        foreach (Match match in Regex.Matches(texto, @"\bs\w*n\b", RegexOptions.IgnoreCase))
        {
            Console.WriteLine(match.Value);
        }

        // Números de teléfono "9876543210"
        Console.WriteLine("\nNúmeros de teléfono '9876543210':");
        foreach (Match match in Regex.Matches(texto, @"\b9876543210\b"))
        {
            Console.WriteLine(match.Value);
        }

        // Correos con dominio ".es"
        Console.WriteLine("\nCorreos con dominio '.es':");
        foreach (Match match in Regex.Matches(texto, @"\b[A-Za-z0-9._%+-]+@(?:[A-Za-z0-9.-]+\.)es\b", RegexOptions.IgnoreCase))
        {
            Console.WriteLine(match.Value);
        }

        // Palabras que inician con "a" y tienen mínimo 5 caracteres
        Console.WriteLine("\nPalabras que inician con 'a' y tienen mínimo 5 caracteres:");
        foreach (Match match in Regex.Matches(texto, @"\ba\w{4,}\b", RegexOptions.IgnoreCase))
        {
            Console.WriteLine(match.Value);
        }

        // Palabras compuestas solo por minúsculas
        Console.WriteLine("\nPalabras compuestas solo por minúsculas:");
        foreach (Match match in Regex.Matches(texto, @"\b[a-z]+\b"))
        {
            Console.WriteLine(match.Value);
        }

        // Sustituir "Python" por "C#"
        Console.WriteLine("\nTexto con 'Python' sustituido por 'C#':");
        string textoModificado = Regex.Replace(texto, @"\bPython\b", "C#", RegexOptions.IgnoreCase);
        Console.WriteLine(textoModificado);
    }
}
