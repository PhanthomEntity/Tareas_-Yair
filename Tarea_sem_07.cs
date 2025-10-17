using System;

class ProgramaMatrices
{
    static void Main()
    {
        Console.WriteLine("=== MATRICES EN C# CON CONTROL DE EXCEPCIONES ===");

        int filas = LeerEntero("Ingrese el número de filas: ");
        int columnas = LeerEntero("Ingrese el número de columnas: ");

        double[,] matriz = new double[filas, columnas];

        // Llenado de la matriz con control de errores
        Console.WriteLine("\n=== INGRESO DE DATOS ===");
        for (int i = 0; i < filas; i++)
        {
            for (int j = 0; j < columnas; j++)
            {
                matriz[i, j] = LeerDecimal($"Ingrese el valor para posición [{i},{j}]: ");
            }
        }

        // Mostrar la matriz ingresada
        Console.WriteLine("\n=== MATRIZ INGRESADA ===");
        for (int i = 0; i < filas; i++)
        {
            for (int j = 0; j < columnas; j++)
            {
                Console.Write($"{matriz[i, j],8}");
            }
            Console.WriteLine();
        }

        // Calcular suma por filas
        double[] sumaFilas = new double[filas];
        for (int i = 0; i < filas; i++)
        {
            double suma = 0;
            for (int j = 0; j < columnas; j++)
            {
                suma += matriz[i, j];
            }
            sumaFilas[i] = suma;
        }

        // Calcular suma por columnas
        double[] sumaColumnas = new double[columnas];
        for (int j = 0; j < columnas; j++)
        {
            double suma = 0;
            for (int i = 0; i < filas; i++)
            {
                suma += matriz[i, j];
            }
            sumaColumnas[j] = suma;
        }

        // Mostrar sumas por fila
        Console.WriteLine("\n=== SUMAS POR FILA ===");
        for (int i = 0; i < filas; i++)
        {
            Console.WriteLine($"Fila {i + 1}: {sumaFilas[i]}");
        }

        // Mostrar sumas por columna
        Console.WriteLine("\n=== SUMAS POR COLUMNA ===");
        for (int j = 0; j < columnas; j++)
        {
            Console.WriteLine($"Columna {j + 1}: {sumaColumnas[j]}");
        }

        // Comparación opcional con lista unidimensional
        Console.WriteLine("\n=== COMPARACIÓN OPCIONAL ===");
        Console.WriteLine("Ejemplo de lista unidimensional equivalente:");
        double[] listaEjemplo = { 2.5, 3.0, 4.5 };
        double sumaLista = 0;
        foreach (double num in listaEjemplo)
        {
            sumaLista += num;
        }
        Console.WriteLine("Lista: [2.5, 3.0, 4.5]");
        Console.WriteLine($"Suma total: {sumaLista}");

        Console.WriteLine("\n=== Fin del programa ===");
    }

    // -------------------- MÉTODOS AUXILIARES --------------------

    // Método para leer un número entero con control de errores
    static int LeerEntero(string mensaje)
    {
        int valor;
        while (true)
        {
            Console.Write(mensaje);
            string entrada = Console.ReadLine();

            try
            {
                valor = Convert.ToInt32(entrada);
                if (valor <= 0)
                {
                    Console.WriteLine("Por favor, ingrese un número entero positivo.");
                    continue;
                }
                return valor;
            }
            catch
            {
                Console.WriteLine("Error: Entrada no válida. Intente de nuevo con un número entero.");
            }
        }
    }

    // Método para leer un número decimal con control de errores
    static double LeerDecimal(string mensaje)
    {
        double valor;
        while (true)
        {
            Console.Write(mensaje);
            string entrada = Console.ReadLine();

            try
            {
                valor = Convert.ToDouble(entrada);
                return valor;
            }
            catch
            {
                Console.WriteLine("Error: Entrada no válida. Intente de nuevo con un número decimal.");
            }
        }
    }
}
