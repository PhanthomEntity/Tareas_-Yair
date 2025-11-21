using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {

        // MENÚ PRINCIPAL PARA SELECCIONAR EL TIPO DE LISTA

        Console.WriteLine("=== ORDENAMIENTO POR INSERCIÓN ===\n");
        Console.WriteLine("Seleccione el tipo de lista:");
        Console.WriteLine("1. Lista completamente desordenada");
        Console.WriteLine("2. Lista ya ordenada");
        Console.WriteLine("3. Lista parcialmente ordenada\n");

        int opcion = PedirEnteroSeguro("Ingrese una opción (1-3): ", 1, 3);

        // La lista que vamos a ordenar
        List<int> lista = new List<int>();

        // Se llena según opción
        if (opcion == 1)
        {
            // Lista completamente desordenada
            lista = new List<int> { 9, 3, 7, 1, 6, 4, 8, 2, 5 };
        }
        else if (opcion == 2)
        {
            // Lista completamente ordenada
            lista = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        }
        else if (opcion == 3)
        {
            // Lista parcialmente ordenada
            lista = new List<int> { 1, 2, 3, 8, 5, 6, 9, 4, 7 };
        }

        Console.WriteLine("\nLista inicial:");
        MostrarLista(lista);

        // Llamamos al algoritmo de inserción
        Console.WriteLine("\n=== PROCESO DE ORDENAMIENTO POR INSERCIÓN ===\n");

        OrdenamientoPorInsercion(lista);

        Console.WriteLine("\n=== LISTA FINAL ORDENADA ===");
        MostrarLista(lista);

        Console.WriteLine("\nFin del programa. Presione ENTER para salir.");
        Console.ReadLine();
    }


    // Función para pedir un entero con validación y repetición

    static int PedirEnteroSeguro(string mensaje, int min, int max)
    {
        int valor = 0;
        bool valido = false;

        while (!valido)
        {
            try
            {
                Console.Write(mensaje);
                valor = int.Parse(Console.ReadLine());

                // Validar rango
                if (valor >= min && valor <= max)
                {
                    valido = true;  // Entrada correcta
                }
                else
                {
                    Console.WriteLine($"Error: debe estar entre {min} y {max}.\n");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: ingrese un número entero válido.\n");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error inesperado: " + e.Message + "\n");
            }
        }

        return valor;
    }


    // MUESTRA LA LISTA EN PANTALLA

    static void MostrarLista(List<int> lista)
    {
        Console.Write("[ ");
        foreach (int num in lista)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine("]");
    }


    // ORDENAMIENTO POR INSERCIÓN

    static void OrdenamientoPorInsercion(List<int> lista)
    {
        // Contadores generales
        int comparaciones = 0;
        int intercambios = 0;

        // El algoritmo empieza desde el segundo elemento (índice 1)
        for (int i = 1; i < lista.Count; i++)
        {
            // Valor que se va a insertar en su posición correcta
            int valorActual = lista[i];

            // Posición donde vamos comparando hacia atrás
            int j = i - 1;

            
            // Aquí comienza el bucle interno donde se compara el valorActual
            // con los elementos anteriores y se van moviendo si son mayores.

            while (j >= 0)
            {
                comparaciones++;  // Cada comparación se cuenta

                if (lista[j] > valorActual)
                {
                    // Si el elemento anterior es mayor, se mueve hacia adelante
                    lista[j + 1] = lista[j];
                    intercambios++;  // Contamos el movimiento como intercambio
                    j--;
                }
                else
                {
                    // Si ya no es mayor, rompemos el ciclo
                    break;
                }
            }

            // Insertamos el valor en su posición correcta
            lista[j + 1] = valorActual;

            // Mostrar el estado después de cada iteración
            Console.WriteLine($"Iteración {i}:");
            MostrarLista(lista);
            Console.WriteLine($"Comparaciones acumuladas: {comparaciones}");
            Console.WriteLine($"Intercambios acumulados: {intercambios}\n");
        }

        // Fin del algoritmo
        Console.WriteLine("=== Resumen ===");
        Console.WriteLine($"Comparaciones totales: {comparaciones}");
        Console.WriteLine($"Intercambios totales: {intercambios}");
    }
}
