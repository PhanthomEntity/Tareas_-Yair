using System;

class Program
{
    
    // Métodos de Ordenamiento
    

    // Burbuja
    static (int comparaciones, int intercambios) Burbuja(int[] arreglo)
    {
        int comparaciones = 0;
        int intercambios = 0;

        for (int i = 0; i < arreglo.Length - 1; i++)
        {
            for (int j = 0; j < arreglo.Length - 1 - i; j++)
            {
                comparaciones++;

                if (arreglo[j] > arreglo[j + 1])
                {
                    // Intercambio
                    int temp = arreglo[j];
                    arreglo[j] = arreglo[j + 1];
                    arreglo[j + 1] = temp;
                    intercambios++;
                }
            }

            // Mostrar el estado después de cada pasada
            Console.WriteLine("Iteración Burbuja " + (i + 1) + ": " + string.Join(", ", arreglo));
        }

        return (comparaciones, intercambios);
    }

    // Inserción
    static (int comparaciones, int intercambios) Insercion(int[] arreglo)
    {
        int comparaciones = 0;
        int intercambios = 0;

        for (int i = 1; i < arreglo.Length; i++)
        {
            int actual = arreglo[i];
            int j = i - 1;

            while (j >= 0)
            {
                comparaciones++;

                if (arreglo[j] > actual)
                {
                    arreglo[j + 1] = arreglo[j];
                    intercambios++;
                    j--;
                }
                else
                {
                    break;
                }
            }

            arreglo[j + 1] = actual;

            Console.WriteLine("Iteración Inserción " + i + ": " + string.Join(", ", arreglo));
        }

        return (comparaciones, intercambios);
    }

    // Selección
    static (int comparaciones, int intercambios) Seleccion(int[] arreglo)
    {
        int comparaciones = 0;
        int intercambios = 0;

        for (int i = 0; i < arreglo.Length - 1; i++)
        {
            int indiceMenor = i;

            for (int j = i + 1; j < arreglo.Length; j++)
            {
                comparaciones++;
                if (arreglo[j] < arreglo[indiceMenor])
                {
                    indiceMenor = j;
                }
            }

            // Intercambiar
            if (indiceMenor != i)
            {
                int temp = arreglo[i];
                arreglo[i] = arreglo[indiceMenor];
                arreglo[indiceMenor] = temp;
                intercambios++;
            }

            Console.WriteLine("Iteración Selección " + (i + 1) + ": " + string.Join(", ", arreglo));
        }

        return (comparaciones, intercambios);
    }

 
    // Programa principal
  
    static void Main()
    {
        int cantidad = 0;

        // VALIDACIÓN DE ENTRADA
        while (true)
        {
            try
            {
                Console.Write("¿Cuántos números desea ingresar? ");
                cantidad = int.Parse(Console.ReadLine());

                if (cantidad <= 0)
                {
                    Console.WriteLine("Error: el número debe ser mayor que cero.\n");
                    continue;
                }

                break;
            }
            catch
            {
                Console.WriteLine("Error: entrada no válida. Intente de nuevo.\n");
            }
        }

        int[] datos = new int[cantidad];

        // INGRESO DE DATOS
        for (int i = 0; i < cantidad; i++)
        {
            while (true)
            {
                try
                {
                    Console.Write($"Ingrese el número {i + 1}: ");
                    datos[i] = int.Parse(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.WriteLine("Entrada inválida, debe ser un número entero.\n");
                }
            }
        }

        // COPIAS PARA CADA ALGORITMO
        int[] copiaBurbuja = (int[])datos.Clone();
        int[] copiaInsercion = (int[])datos.Clone();
        int[] copiaSeleccion = (int[])datos.Clone();

        Console.WriteLine("\n--- ORDENAMIENTO BURBUJA ---");
        var resBurbuja = Burbuja(copiaBurbuja);

        Console.WriteLine("\n--- ORDENAMIENTO INSERCIÓN ---");
        var resInsercion = Insercion(copiaInsercion);

        Console.WriteLine("\n--- ORDENAMIENTO SELECCIÓN ---");
        var resSeleccion = Seleccion(copiaSeleccion);

        // RESULTADOS FINALES
        Console.WriteLine("\nRESULTADOS TOTALES");
        Console.WriteLine($"Burbuja → Comparaciones: {resBurbuja.comparaciones}, Intercambios: {resBurbuja.intercambios}");
        Console.WriteLine($"Inserción → Comparaciones: {resInsercion.comparaciones}, Intercambios: {resInsercion.intercambios}");
        Console.WriteLine($"Selección → Comparaciones: {resSeleccion.comparaciones}, Intercambios: {resSeleccion.intercambios}");
    }
}
