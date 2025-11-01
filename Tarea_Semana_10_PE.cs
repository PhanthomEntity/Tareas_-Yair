using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<string> lista = PedirLista();
        string elementoBuscado = PedirElemento();

        int comparaciones;
        int posicion = BusquedaLineal(lista, elementoBuscado, out comparaciones);

        Console.WriteLine("\nResultados:");
        if (posicion != -1)
            Console.WriteLine($"Elemento '{elementoBuscado}' encontrado en la posición {posicion}.");
        else
            Console.WriteLine($"Elemento '{elementoBuscado}' no encontrado en la lista.");

        Console.WriteLine($"Número de comparaciones realizadas: {comparaciones}");
    }

    // Función para pedir la lista al usuario con control de excepciones
    static List<string> PedirLista()
    {
        List<string> lista = new List<string>();
        Console.WriteLine("Ingrese los elementos de la lista (enteros o texto). Escriba 'fin' para terminar:");

        while (true)
        {
            Console.Write("Elemento: ");
            string entrada = Console.ReadLine();

            if (entrada.ToLower() == "fin")
            {
                if (lista.Count == 0)
                {
                    Console.WriteLine("La lista no puede estar vacía. Ingrese al menos un elemento.");
                    continue;
                }
                break;
            }

            if (string.IsNullOrWhiteSpace(entrada))
            {
                Console.WriteLine("Entrada vacía. Intente de nuevo.");
                continue;
            }

            lista.Add(entrada);
        }

        return lista;
    }

    // Función para pedir el elemento a buscar
    static string PedirElemento()
    {
        while (true)
        {
            Console.Write("\nIngrese el elemento a buscar: ");
            string elemento = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(elemento))
                return elemento;

            Console.WriteLine("Entrada inválida. Intente de nuevo.");
        }
    }

    // Algoritmo de búsqueda lineal
    static int BusquedaLineal(List<string> lista, string elemento, out int comparaciones)
    {
        comparaciones = 0;

        for (int i = 0; i < lista.Count; i++)
        {
            comparaciones++;
            if (lista[i] == elemento)
                return i; // Devuelve la posición
        }

        return -1; // No encontrado
    }
}
