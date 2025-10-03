using System;
using System.Collections.Generic;

class ProgramaListasModular
{
    static void Main()
    {
        List<double> numeros = IngresarNumeros();

        if (numeros.Count == 0)
        {
            Console.WriteLine("No se ingresaron números. El programa finaliza.");
            return;
        }

        MostrarNumeros(numeros);

        CalcularEstadisticas(numeros);

        BuscarNumero(numeros);

        Console.WriteLine("\n=== Fin del programa ===");
    }

    // Módulo para ingresar números
    static List<double> IngresarNumeros()
    {
        List<double> numeros = new List<double>();
        string entrada;
        double numero;
        bool continuar = true;

        Console.WriteLine("=== Creación de listas de números ===");

        while (continuar)
        {
            Console.Write("Ingrese un número (o escriba 'fin' para terminar): ");
            entrada = Console.ReadLine();

            if (entrada.ToLower() == "fin")
            {
                continuar = false;
            }
            else
            {
                try
                {
                    numero = Convert.ToDouble(entrada);
                    numeros.Add(numero);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Entrada no válida. Por favor ingrese un número.");
                }
            }
        }

        return numeros;
    }

    // Módulo para mostrar números
    static void MostrarNumeros(List<double> numeros)
    {
        Console.WriteLine("\n=== Números ingresados ===");
        for (int i = 0; i < numeros.Count; i++)
        {
            Console.WriteLine($"Número {i + 1}: {numeros[i]}");
        }
    }

    // Módulo para calcular mínimo, máximo y promedio
    static void CalcularEstadisticas(List<double> numeros)
    {
        double min = numeros[0];
        double max = numeros[0];
        double suma = 0;

        for (int i = 0; i < numeros.Count; i++)
        {
            if (numeros[i] < min) min = numeros[i];
            if (numeros[i] > max) max = numeros[i];
            suma += numeros[i];
        }

        double promedio = suma / numeros.Count;

        Console.WriteLine($"\nMínimo: {min}");
        Console.WriteLine($"Máximo: {max}");
        Console.WriteLine($"Promedio: {promedio}");
    }

    // Módulo para buscar un número
    static void BuscarNumero(List<double> numeros)
    {
        Console.Write("\nIngrese un número a buscar: ");
        string entrada = Console.ReadLine();

        try
        {
            double busqueda = Convert.ToDouble(entrada);
            bool encontrado = false;

            for (int i = 0; i < numeros.Count; i++)
            {
                if (numeros[i] == busqueda)
                {
                    Console.WriteLine($"Número {busqueda} encontrado en la posición {i + 1}.");
                    encontrado = true;
                    break;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine($"Número {busqueda} no se encontró en la lista.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: Entrada no válida para búsqueda.");
        }
    }
}
