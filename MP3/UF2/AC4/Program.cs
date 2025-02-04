using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        // Correo electrónico
        string emailPattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
        Console.WriteLine(Regex.IsMatch("usuario@dominio.com", emailPattern));

        // Número de teléfono con formato 10 dígitos
        string phonePattern = @"^\d{3}-\d{3}-\d{4}$";
        Console.WriteLine(Regex.IsMatch("123-456-7890", phonePattern));

        // Fecha en formato día/mes/año
        string datePattern = @"^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/\d{4}$";
        Console.WriteLine(Regex.IsMatch("29/02/2024", datePattern));

        // Dirección IP en formato IPv4
        string ipPattern = @"^(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";
        Console.WriteLine(Regex.IsMatch("192.168.1.1", ipPattern));

        // Código postal de 5 dígitos
        string postalCodePattern = @"^\d{5}$";
        Console.WriteLine(Regex.IsMatch("12345", postalCodePattern));

        // Palabra que contenga solo letras
        string wordPattern = @"^[A-Za-z]+$";
        Console.WriteLine(Regex.IsMatch("Hola", wordPattern));

        // Número entero positivo
        string positiveIntPattern = @"^[1-9][0-9]*$";
        Console.WriteLine(Regex.IsMatch("123", positiveIntPattern));

        // URL
        string urlPattern = @"^(https?://)?([a-zA-Z0-9.-]+)\.([a-zA-Z]{2,})(/[\w/-]*)?$";
        Console.WriteLine(Regex.IsMatch("http://www.ejemplo.com/", urlPattern));

        // Código de color hexadecimal
        string hexColorPattern = @"^#([0-9A-Fa-f]{6}|[0-9A-Fa-f]{3})$";
        Console.WriteLine(Regex.IsMatch("#A3C1D7", hexColorPattern));

        // Número decimal con punto
        string decimalPattern = @"^\d+\.\d+$";
        Console.WriteLine(Regex.IsMatch("12.23", decimalPattern));
    }
}
