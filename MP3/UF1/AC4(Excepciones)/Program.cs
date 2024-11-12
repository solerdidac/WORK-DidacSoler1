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

/* Escribe un programa en C# que implemente un método que reciba un número entero como cadena y lance una excepción 
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

/* Escribe un programa en que implemente un método que reciba un arreglo de enteros como cadena y calcule el valor promedio. 
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
    

    static int CalcularPromedio(int[] numerosInt)
    {
        if (numerosInt.Length == 0)
            return 0;

        int suma = 0;
        foreach (int numero in numerosInt)
        {
            suma += numero;
        }
        
        return (int)suma / numerosInt.Length;
    } */


/* Escribe un programa que lea una cadena del usuario y la convierta en un entero. 
Maneja la excepción si la cadena no se puede  analizar como un entero. */

    /* Console.WriteLine("Numero:");
    string numero = Console.ReadLine();

    try{
        int numeroEntero = Convert.ToInt32(numero);
        Console.WriteLine("El numero es el siguiente:" + numeroEntero);
    }
    catch(FormatException){
        Console.WriteLine("El numero no es entero");
    }
    catch(Exception error){
        Console.WriteLine("Error de tipo"+ error.Message);
    } */

/* Escribe un programa que lea una lista de números enteros del usuario. 
Maneja la excepción que ocurre si el usuario ingresa un valor fuera del rango de Int32. */

    /* Console.WriteLine("Introduce una lista de números enteros separados por espacios:");

    string lista = Console.ReadLine();
    string[] numeros = lista.Split(' ');

    List<int> numerosInt = new List<int>();

    foreach (string numeroStr in numeros)
    {
        try
        {
            int numero = Convert.ToInt32(numeroStr);
            numerosInt.Add(numero);
        }
        catch(FormatException)
        {
            Console.WriteLine("No es un número entero válido.");
        }
        catch(OverflowException){
            Console.WriteLine("Numero Int32 no valido");
        }
        catch(Exception error){
            Console.WriteLine("Error de tipo:" + error.Message);
        }
    }

    Console.WriteLine("Lista de números válidos ingresados:");
    foreach (int numero in numerosInt)
    {
        Console.WriteLine(numero);
    } */

/* Escribe un programa que implemente un método que divida dos números. 
Controla la excepción DivideByZeroException que se produce si el denominador es 0. */

    /* Console.Write("Introduce el numerador: ");
    int numerador = Convert.ToInt32(Console.ReadLine());

    Console.Write("Introduce el denominador: ");
    int denominador = Convert.ToInt32(Console.ReadLine());

    try
    {
        double resultado = Dividir(numerador, denominador);
        Console.WriteLine("El resultado de la división es: " + resultado);
    }
    catch(DivideByZeroException)
    {
        Console.WriteLine("No se puede dividir entre cero.");
    }
    catch(Exception error){
        Console.WriteLine("Error:" + error.Message);
    }
    static double Dividir(int numerador, int denominador)
    {
        if (denominador == 0)
            {
                throw new DivideByZeroException();
            } 
        return (double)numerador / denominador;
    } */

/* Escribe un programa que lea un número del usuario y calcule su raíz cuadrada. 
Maneja la excepción si el número es negativo. */

    /* Console.Write("Introduce un número: ");
    double numero;

    try
    {
        numero = Convert.ToDouble(Console.ReadLine());

        if (numero < 0)
        {
            throw new ArgumentOutOfRangeException("El numero no puede ser negativo.");
        }

        double raizCuadrada = Math.Sqrt(numero);
        Console.WriteLine("La raíz cuadrada de " + numero + " es: " + raizCuadrada);
    }
     catch (FormatException)
    {
        Console.WriteLine("Error: La cadena no es un número válido.");
    }
    catch (ArgumentOutOfRangeException error)
    {
        Console.WriteLine("Error: " + error.Message);
    }
    catch(Exception error){
        Console.WriteLine("Error de:" + error.Message);
    } */

// Escribe un programa que cree un método que tome una cadena como cadena y la convierta a mayúsculas

    /* Console.Write("Introduce una cadena: ");
    string cadena = Console.ReadLine();

    string mayusculas = ConvertirAMayusculas(cadena);
    Console.WriteLine("Cadena en mayúsculas: " + mayusculas);


    static string ConvertiraMayusculas(string cadena)
    {
        return cadena.ToUpper();
    } */
