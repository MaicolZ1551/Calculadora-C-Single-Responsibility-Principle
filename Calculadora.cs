using System;

// Clase para leer el tipo de operación
public class OperacionInput
{
    public string LeerOperacion()
    {
        Console.WriteLine("¿Qué operación quieres realizar? (+, -, /, *):");
        return Console.ReadLine();
    }
}

// Clase para leer los operandos
public class OperandosInput
{
    public bool LeerOperandos(out int numero1, out int numero2)
    {
        Console.Write("Ingresa el primer número: ");
        string entrada1 = Console.ReadLine();

        Console.Write("Ingresa el segundo número: ");
        string entrada2 = Console.ReadLine();

        bool esNumero1 = int.TryParse(entrada1, out numero1);
        bool esNumero2 = int.TryParse(entrada2, out numero2);

        // Si alguno no es numero da error
        if (!esNumero1 || !esNumero2)
        {
            Console.WriteLine("Uno o ambos valores ingresados no son números válidos.");
            return false;
        }

        return true;
    }
}

// Clase que ejecuta la operación correspondiente
public class OperacionEjecutor
{
    public void EjecutarOperacion(string tipoOperacion, int numero1, int numero2)
    {
        if (tipoOperacion == "+")
        {
            Console.WriteLine("=== SUMADOR DE NÚMEROS ===\n");
            int suma = numero1 + numero2;
            Console.WriteLine($"El resultado de la suma es: {suma}");
        }
        else if (tipoOperacion == "-")
        {
            Console.WriteLine("=== RESTADOR DE NÚMEROS ===\n");
            int resta = numero1 - numero2;
            Console.WriteLine($"El resultado de la resta es: {resta}");
        }
        else if (tipoOperacion == "*")
        {
            Console.WriteLine("=== MULTIPLICADOR DE NÚMEROS ===\n");
            int multiplica = numero1 * numero2;
            Console.WriteLine($"El resultado de la multiplicación es: {multiplica}");
        }
        else if (tipoOperacion == "/")
        {
            Console.WriteLine("=== DIVISOR DE NÚMEROS ===\n");
            if (numero2 != 0)
            {
                int divide = numero1 / numero2;
                Console.WriteLine($"El resultado de la división es: {divide}");
            }
            else
            {
                Console.WriteLine("ERROR: División por cero no permitida.");
            }
        }
        else
        {
            Console.WriteLine("ERROR: Operación no válida.");
        }
    }
}

// Clase principal que coordina todo
class Program
{
    static void Main()
    {
        var operacionInput = new OperacionInput();
        var operandosInput = new OperandosInput();
        var ejecutor = new OperacionEjecutor();

        string tipoOperacion = operacionInput.LeerOperacion();

        if (operandosInput.LeerOperandos(out int numero1, out int numero2))
        {
            ejecutor.EjecutarOperacion(tipoOperacion, numero1, numero2);
        }
    }
}

