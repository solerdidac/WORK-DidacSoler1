// EXCEPCIONES

// Haz los siguientes ejemplos:

/* Escribe un programa en C# que solicite al usuario ingresar dos números y realice la división entre ellos. 
Maneja una excepción cuando el usuario introduce valores no numéricos. */

/* 
try{
Console.WriteLine("Numero 1:");
int numero1 = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Numero 2:");
int numero2 = Convert.ToInt32(Console.ReadLine());


    int division = numero1/numero2;
}
catch(Exception error){
    Console.WriteLine("El error es:" + error.Message);
} */

/* Escribe un programa en C# que implemente un método que reciba un número entero como entrada y lance una excepción 
si el número es negativo. Maneja la excepción en el código que llama al método. */

/* try
{
    Console.WriteLine("Numero Positivo:");
    int numero1 = Convert.ToInt32(Console.ReadLine());
    if(numero1 < 0)
    {
        throw new Exception("Numero Positivo, porfavor");
    }
}
catch(Exception error){
    Console.WriteLine("Es el error;" + error.Message);
};
 */


/* Escribe un programa en C# que lea una ruta de archivo proporcionada por el usuario e intente abrir el archivo. 
Maneja excepciones si el archivo no existe. */

/* try
{
    Console.WriteLine("Escribe la ruta");
    string rutaArchivo = Console.ReadLine()!;

    string texto = File.ReadAllText(rutaArchivo);
    Console.WriteLine("Contenido");
    Console.WriteLine(texto);
}
catch(FileNotFoundException){
    Console.WriteLine("La ruta no existe");

}
catch(Exception error){
    Console.WriteLine("Error:" + error.Message);
} */

/* Escribe un programa en C# que solicite al usuario ingresar un número entero.
Lanza una excepción si el número es menor que 0 o mayor que 1000. */

/* try{
Console.WriteLine("Numero 0-1000");
int numero1 = Convert.ToInt32(Console.ReadLine());
    if(numero1 < 0 || numero1 > 1000){
        throw new IndexOutOfRangeException("Fuera de Rango");
    }
}
catch(IndexOutOfRangeException error){
    Console.WriteLine("Error:" + error.Message);
}
catch(Exception error){
    Console.WriteLine("El error es:" + error.Message);
} */

/* Escribe un programa en C# que implemente un método que reciba un arreglo de enteros como entrada y calcule el valor promedio. 
Maneja la excepción si el índice está fuera de rango. */


/* int[] numbers = new int[] { 1, 2, 3 };
        
Console.WriteLine("El promedio de los números es: " + CalcularPromedio(numbers));

    try
        {
            Console.WriteLine("Numero de indice:");
            int indice = Convert.ToInt32(Console.ReadLine());
                
            Console.WriteLine("Indice " + indice + ": " + numbers[indice]);
        }
    catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Error: El indice fuera de rango.");
        }
    catch (Exception error)
        {
            Console.WriteLine("Error general: " + error.Message);
        }
    

    static int CalcularPromedio(int[] numeros)
    {
        if (numeros.Length == 0)
            return 0;

        int suma = 0;
        foreach (int numero in numeros)
        {
            suma += numero;
        }
        
        return (int)suma / numeros.Length;
    } */


